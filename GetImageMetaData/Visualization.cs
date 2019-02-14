using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Vision.Contract;
using Color = System.Windows.Media.Color;
using Face = Microsoft.ProjectOxford.Face.Contract.Face;
using Point = System.Windows.Point;

namespace GetImageMetaData
{
    public class Visualization
    {
        private static SolidColorBrush _sLineBrush = new SolidColorBrush(new Color { R = 255, G = 185, B = 0, A = 255 });

        private static readonly Typeface STypeface = new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal,
            FontWeights.Bold, FontStretches.Normal);

        private static BitmapSource DrawOverlay(BitmapSource baseImage, Action<DrawingContext, double> drawAction)
        {
            double annotationScale = baseImage.PixelHeight / 320;

            var visual = new DrawingVisual();
            var drawingContext = visual.RenderOpen();

            drawingContext.DrawImage(baseImage, new System.Windows.Rect(0, 0, baseImage.Width, baseImage.Height));

            drawAction(drawingContext, annotationScale);

            drawingContext.Close();

            var outputBitmap = new RenderTargetBitmap(
                baseImage.PixelWidth, baseImage.PixelHeight,
                baseImage.DpiX, baseImage.DpiY, PixelFormats.Pbgra32);

            outputBitmap.Render(visual);

            return outputBitmap;
        }

        public static BitmapSource DrawTags(BitmapSource baseImage, Tag[] tags)
        {
            if (tags == null) return baseImage;
            // when tag is selected
            Action<DrawingContext, double> drawAction = (drawingContext, annotationScale) =>
            {
                double y = 0;
                foreach (var tag in tags)
                {
                    // Create formatted text--in a particular font at a particular size
#pragma warning disable CS0618 // Type or member is obsolete
                    var ft = new FormattedText(tag.Name,
                        CultureInfo.CurrentCulture, FlowDirection.LeftToRight, STypeface, 42 * annotationScale,
                        Brushes.Black);
#pragma warning restore CS0618 // Type or member is obsolete
                    // Instead of calling DrawText (which can only draw the text in a solid colour), we
                    // convert to geometry and use DrawGeometry, which allows us to add an outline. 
                    var geom = ft.BuildGeometry(new Point(10 * annotationScale, y));
                    drawingContext.DrawGeometry(_sLineBrush, new Pen(Brushes.Black, 2 * annotationScale), geom);
                    // Move line down
                    y += 42 * annotationScale;
                }
            };

            return DrawOverlay(baseImage, drawAction);
        }

        public static BitmapSource DrawFaces(BitmapSource baseImage, Face[] faces, EmotionScores[] emotionScores,
            string[] celebName, List<string> _id)
        {
            if (faces == null) return baseImage;

            Action<DrawingContext, double> drawAction = (drawingContext, annotationScale) =>
            {
                for (var i = 0; i < faces.Length; i++)
                {
                    var face = faces[i];
                    if (face.FaceRectangle == null) continue;

                    var faceRect = new System.Windows.Rect(
                        face.FaceRectangle.Left, face.FaceRectangle.Top,
                        face.FaceRectangle.Width, face.FaceRectangle.Height);
                    var text = "";

                    if (face.FaceAttributes != null)
                        if (_id[i] != "Unidentified")
                        {
                            _sLineBrush = new SolidColorBrush(new Color { R = 0, G = 185, B = 0, A = 255 });
                            text = _id[i];
                        }
                        else
                        {
                            _sLineBrush = new SolidColorBrush(new Color { R = 255, G = 185, B = 0, A = 255 });
                            text = _id[i] + "  (";
                            text += Aggregation.SummarizeFaceAttributes(face.FaceAttributes) + ")";
                        }

                    if (emotionScores?[i] != null) text += Aggregation.SummarizeEmotion(emotionScores[i]);

                    if (celebName?[i] != null) text += celebName[i];

                    faceRect.Inflate(6 * annotationScale, 6 * annotationScale);

                    var lineThickness = 4 * annotationScale;


                    drawingContext.DrawRectangle(
                        Brushes.Transparent,
                        new Pen(_sLineBrush, lineThickness),
                        faceRect);

                    if (text != "")
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        var ft = new FormattedText(text,
                            CultureInfo.CurrentCulture, FlowDirection.LeftToRight, STypeface,
                            16 * annotationScale, Brushes.Black);
#pragma warning restore CS0618 // Type or member is obsolete

                        var pad = 3 * annotationScale;

                        var ypad = pad;
                        var xpad = pad + 4 * annotationScale;
                        var origin = new Point(
                            faceRect.Left + xpad - lineThickness / 2,
                            faceRect.Top - ft.Height - ypad + lineThickness / 2);
                        var rect = ft.BuildHighlightGeometry(origin).GetRenderBounds(null);
                        rect.Inflate(xpad, ypad);

                        drawingContext.DrawRectangle(_sLineBrush, null, rect);
                        drawingContext.DrawText(ft, origin);
                    }
                }
            };

            return DrawOverlay(baseImage, drawAction);
        }
    }
}
