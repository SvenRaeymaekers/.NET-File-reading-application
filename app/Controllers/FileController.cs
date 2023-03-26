using System;
using System.Xml;
using System.Collections.Generic;


public class FileController
{

    //relative path to roles and corresponding file reading rights. Keep this a relative path.
    private static string _allowedFilesByRoleFilePath = "\\config\\security.xml";

    private readonly FileReaderFactory _fileReaderFactory;

    // array that defines the currently supported file types that can be read
    private string[] _allowedFileTypes = { "txt", "xml", "json" };

    // string that defines the decryption strategy that is being used.
    private string _decryptionStrategy = "base64";


    public FileController()
    {
        this._fileReaderFactory = new FileReaderFactory();

    }

    //the main function of this controller. This function is being called for every file that the user is reading.
    public string ProcessFile(string filePath, string fileType, bool isFileEncrypted, string userRole)
    {

        //input & authorization check before starting business logic
        CheckValidArguments(fileType,filePath,userRole);
        CheckIfUserIsAllowedToReadFile(fileType, userRole);
        

        // Create the fileReader depending on fileType & create filedatadecryptor with decryptionstrategy that is defined by string _decryptionStrategy
        IFileReader fileReader = GetFileReaderByFileType(fileType);
        FileDataDecryptor fileDataDecryptor = new FileDataDecryptor(GetDescryptionStrategy(_decryptionStrategy));
        
        //Read the file content. The Decryption functionality is provided in the ReadFile method of FileReader, so isFileEncrypted + fileDataDecryptor is required as parameter
        string fileContent = fileReader.ReadFile(filePath, isFileEncrypted, fileDataDecryptor);

        return fileContent;
    }

    private void CheckValidArguments(string fileType, string filePath, string userRole){
        //is the provided file type currently supported
        if (!_allowedFileTypes.Contains(fileType))
        {
            throw new ArgumentException("The file type you are trying to read is currently not supported.", fileType);
        }

        //does the file exist?
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The file path you provided does not exist.", filePath);
        }
    }

    private void CheckIfUserIsAllowedToReadFile(string fileType, string userRole){
        FileAccessService fileAccessService = new FileAccessService(_allowedFilesByRoleFilePath);
        if (!fileAccessService.IsUserAllowedToReadFile(userRole, fileType))
        {
            throw new UnauthorizedAccessException("You are not authorized to read this type of file.");
        }

    }

    private IFileReader GetFileReaderByFileType(string fileType)
    {
        switch (fileType)
        {
            case "txt":
                return _fileReaderFactory.CreateTxtFileReader();
            case "json":
                return _fileReaderFactory.CreateJsonFileReader();
            case "xml":
                return _fileReaderFactory.CreateXmlFileReader();
            default:
                //this is actually already checked in ProcessFile method but just in case
                throw new ArgumentException("The file type you are trying to read is currently not supported.");
        }
    }

    private IDecryptionStrategy GetDescryptionStrategy(string decryptionStrategy)
    {
        switch (decryptionStrategy)
        {
            case "base64":
                return new Base64DecryptionStrategy();
            default:
                //for internal purposes since the decryption algorithm is defined internally,
                //but might be useful when a user provides which decryption algorithm should be used.
                throw new ArgumentException("The decryption strategy is not supported:", decryptionStrategy);
        }
    }
}