
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
        string fileType = Console.ReadLine().ToLower().Replace(".","");
        return fileType;
    }

    public bool IsFileEncrypted()
    {

        Console.WriteLine("Is your File Encrypted? Please reply with \"Yes\" or \"No\". \n");
        string isEncryptedString = Console.ReadLine().ToLower();
        isEncryptedString = ReturnYesOrNoAnswerFromUser(isEncryptedString);

        return isEncryptedString.Equals("yes") ? true : false;
    }

    public string GetUserRole()
    {
        Console.WriteLine("What role do you have? Please reply with \"Admin\" or \"User\". \n");
        string userRole = Console.ReadLine().ToLower();
        while ((!userRole.Equals("admin")) && (!userRole.Equals("user")))
        {
            Console.WriteLine("Please reply with \"Admin\" or \"User\" \n.");
            userRole = Console.ReadLine().ToLower();
        }
        return userRole;
    }

    public string ReturnYesOrNoAnswerFromUser(string userInput)
    {
        if ((userInput.ToLower().Equals("yes")) || (userInput.ToLower().Equals("no")))
        {
            return userInput;
        }
        else
        {
            while ((!userInput.Equals("yes")) && (!userInput.Equals("no")))
            {
                Console.WriteLine("Please reply with \"Yes\" or \"No\" \n");
                userInput = Console.ReadLine().ToLower();
            }
            return userInput;
        }

    }

}
