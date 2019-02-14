using System;
using System.Windows.Forms;

namespace GetImageMetaData
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // TASK  FIX System out of Memory Error when processing video file
            Application.Run(new FrmMain());
        }
    }
}
