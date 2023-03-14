
public class CLIHelperClass
{

    public string GetFilePathFromUser()
    {
        Console.WriteLine("Please provide the file path of the file you would like to read.\n");
        string filePath = Console.ReadLine();
        return filePath;
    }

    public string GetFileTypeFromUser()
    {
        Console.WriteLine("Please provide the file type of the file you would like to read.\n");
        string fileType = Console.ReadLine();
        return fileType;
    }

    public bool IsFileEncrypted()
    {

        Console.WriteLine("Is your File Encrypted? Please answer with \"Yes\" or \"No\" \n");
        string isEncryptedString = Console.ReadLine().ToLower();
        isEncryptedString = ReturnYesOrNoAnswerFromUser(isEncryptedString);

        return isEncryptedString.Equals("yes") ? true : false;
    }



    public string ReturnYesOrNoAnswerFromUser(string userInput)
    {
        if ((userInput.Equals("yes")) || (userInput.Equals("no")))
        {
            return userInput;
        }
        else
        {
            while ((!userInput.Equals("yes")) && (!userInput.Equals("no")))
            {
                Console.WriteLine("Please answer with \"Yes\" or \"No\" \n");
                userInput = Console.ReadLine().ToLower();
            }
            return userInput;
        }

    }

}
