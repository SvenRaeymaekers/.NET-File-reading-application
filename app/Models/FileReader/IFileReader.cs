
public interface IFileReader
{
    string ReadFile(string filePath, bool isFileEncrypted, FileDataDecryptor fileDataDecryptor);


}
