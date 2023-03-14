

public abstract class AbstractFileReader : IFileReader
{


    //abstract class in case that the file readers would get some shared functionality in the future.
    public abstract string ReadFile(string filePath, bool isFileEncrypted, FileDataDecryptor fileDataDecryptor);
    

}