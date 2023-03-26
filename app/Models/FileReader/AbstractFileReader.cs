

public abstract class AbstractFileReader : IFileReader
{


    //abstract class in case that more functionality would be shared among all FileReaders in future requirements.
    public abstract string ReadFile(string filePath, bool isFileEncrypted, FileDataDecryptor fileDataDecryptor);
    
}