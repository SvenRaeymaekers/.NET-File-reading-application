using System.IO;

CLIHelperClass helper = new CLIHelperClass();

startFileReadingApplication(helper);

static void startFileReadingApplication(CLIHelperClass helper)
{
    bool isUserReadingAnotherFile = true;
    FileController fileController = new FileController();

    string userRole = helper.GetUserRole();
    while (isUserReadingAnotherFile)
    {
        try
        {

            string filePath = helper.GetFilePathFromUser();
            //encrypted files might have different file extensions: e.g. base64 encryption results in .txt files. 
            //Therefor, initial type file is required as input.
            string fileType = helper.GetFileTypeFromUser();
            bool isFileEncrypted = helper.IsFileEncrypted();

            string fileContent = fileController.ProcessFile(filePath, fileType, isFileEncrypted, userRole);
            Console.WriteLine(fileContent);
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while reading your file: " + e.Message);

        }
        finally
        {
            Console.WriteLine("Would you like to read another file? Please answer with \"Yes\" or \"No\" \n");
            string isUserReadingAnotherFileString = Console.ReadLine().ToLower();
            //check and enforce correct user input
            isUserReadingAnotherFileString = helper.ReturnYesOrNoAnswerFromUser(isUserReadingAnotherFileString);
            isUserReadingAnotherFile = isUserReadingAnotherFileString.Equals("yes") ? true : false;
        }
    }
    //exit the program
    Console.WriteLine("Thank you for using the file reader application!");

}

