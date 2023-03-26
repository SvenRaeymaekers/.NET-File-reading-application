using System;
using System.Xml;
using System.Collections.Generic;


public class FileController
{
    private static string allowedFilesByRoleFilePath = "\\config\\security.xml";
    private readonly FileReaderFactory _fileReaderFactory;
    private string[] _allowedFileTypes = { "txt", "xml", "json" };


    public FileController()
    {
        this._fileReaderFactory = new FileReaderFactory();

    }

    public string ProcessFile(string filePath, string fileType, bool isFileEncrypted, string userRole)
    {

        //check if file exists, if not, throw exception.
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The file path you provided does not exist.", filePath);
        }
        fileType = fileType.Replace(".", "").ToLower();
        if (!_allowedFileTypes.Contains(fileType))
        {
            throw new ArgumentException("The file type you provided is not supported at this moment.", fileType);
        }

        FileAccessService fileAccessService = new FileAccessService(allowedFilesByRoleFilePath);
        if (!fileAccessService.IsUserAllowedToReadFile(userRole, fileType))
        {
            throw new UnauthorizedAccessException("You are not authorized to read this type of file.");
        }

        FileDataDecryptor fileDataDecryptor = new FileDataDecryptor(new Base64DecryptionStrategy());
        IFileReader fileReader = GetCorrectFileReader(fileType);
        string fileContent = fileReader.ReadFile(filePath, isFileEncrypted, fileDataDecryptor);

        return fileContent;
    }

    private IFileReader GetCorrectFileReader(string fileType)
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
                //the code in FileController already returns an exception if the file tye is not supported 
                //to prevent warning/error: 
                throw new ArgumentException("The file type you are trying to read is currently not supported.");
        }
    }
}