using System;



public class FileController
{

    private readonly FileReaderFactory _fileReaderFactory;
    private string[] _allowedFileTypes = { "txt", "xml", "json" };


    public FileController()
    {
        this._fileReaderFactory = new FileReaderFactory();
    }

    public string ProcessFile(string filePath, string fileType, bool isFileEncrypted)
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

        // then, check if user is allowed to read the file, so inject the model of 


        IFileReader fileReader = _fileReaderFactory.CreateFileReader(fileType);
        // if (isEncrypted == true)
        // {
        //     IDecryptionStrategy decryptionStrategy = GetDecryptionStrategy(encryptionAlgorithm);
        //     ContentDecryptor contentDecryptor = new ContentDecryptor(decryptionStrategy);
        //     fileContent = contentDecryptor.DecryptContent(fileContent);
        // }
        FileDataDecryptor fileDataDecryptor = new FileDataDecryptor(new Base64DecryptionStrategy());
        string fileContent = fileReader.ReadFile(filePath, isFileEncrypted, fileDataDecryptor);

        return fileContent;
    }
}