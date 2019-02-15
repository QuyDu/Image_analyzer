# Image_analyzer
This project is not intended to be a solution that is to deployed in a Production Environment. The Idea of this project is to engage people in the development of applications utilizing Microsoft Cognitive Services APIs specifically the Face and Vision APIs.
This App consist of methods that tackel a wide variety of limitations that currently exist in the FACE and Visio APIs'
For example
1. File Size is currently limited to 4MB when using the Vision API and 6MB when using the FACE API.
  a. This app includes a method to detec file size and keeping aspect ration and proportions the image is resized below the the max size for the vision API.
2. When using the IdentifyAsync call there is a limit of 10 faceIds that can be submitted
  a. This app has a method which counts the number of faceIds and if more than 10 creates multiple arrays of 10 faceIds to be submitted and each array is than sent to the IdentifyAsync call
3. when Sending an Array of faceIds to the IdentifyAync call the current faceAPI limitation only allows to check for 1 personGroup at a time.
  a. This app has a method to identify how many personGroups are associated with the defined Key and doing and performs a for each to check if the current faceId being analyzed can be matched within any of these personGroups.
  
This app also contains the following methods
1. A method to catagorize images within a directory, identify and organize all photos in to created folders that identify person identified
2. Web scraping, there is a method that reaches out and combs specific websites to build profiles for example the Top 10 Most wanted List from the FBI.GOV site

