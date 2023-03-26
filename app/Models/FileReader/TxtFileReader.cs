using System.Text;

public class TxtFileReader : AbstractFileReader
{


    public override string ReadFile(string filePath, bool isFileEncrypted, FileDataDecryptor fileDataDecryptor)
    {

        try
        {
            string fileContent = File.ReadAllText(filePath);
            //decryption logic
            if (isFileEncrypted)
            {
                fileContent = fileDataDecryptor.DecryptContent(fileContent);

            }

            return fileContent;

        }

        catch (Exception)
        {
            throw new Exception("Something went wrong while reading your txt-file.");
        }

    }

}