using System.Text;

public class TxtFileReader : AbstractFileReader
{


    public override string ReadFile(string filePath, bool isFileEncrypted, FileDataDecryptor fileDataDecryptor)
    {
        string fileContent = File.ReadAllText(filePath);
        if (isFileEncrypted)
        {
            fileContent = fileDataDecryptor.DecryptContent(fileContent);

        }
        return fileContent;
    }

}