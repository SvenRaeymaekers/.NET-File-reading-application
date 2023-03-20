using System.IO;

CLIHelperClass helper = new CLIHelperClass();


startFileReadingApplication(helper);

string[] allowedFileTypes = { "txt", "xml", "json" };

static void startFileReadingApplication(CLIHelperClass helper)
{
    bool isUserReadingAnotherFile = true;
    FileController fileController = new FileController();

    while (isUserReadingAnotherFile)
    {
        try
        {
            
            string filePath = helper.GetFilePathFromUser();
            string fileType = helper.GetFileTypeFromUser();
            bool isFileEncrypted = helper.IsFileEncrypted();
            // role based auth input: what role are you. 
            string fileContent = fileController.ProcessFile(filePath, fileType, isFileEncrypted);
            Console.WriteLine(fileContent);
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while reading your file: " + e.Message);

        }
        finally
        {
            Console.WriteLine("Would you like to read another file? Please answer with \"Yes\" or \"No\" \n");
            string isUserReadingAnotherFileString = Console.ReadLine();
            //check and enforce correct user input
            isUserReadingAnotherFileString = helper.ReturnYesOrNoAnswerFromUser(isUserReadingAnotherFileString);
            isUserReadingAnotherFile = isUserReadingAnotherFileString.Equals("yes") ? true : false;
        }
    }
    //exit the program
    Console.WriteLine("Thank you for using the file reader application!");
    
}

