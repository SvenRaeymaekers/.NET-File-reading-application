using Newtonsoft;
using Newtonsoft.Json.Linq;

public class JsonFileReader : AbstractFileReader
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

            JObject jsonObject = JObject.Parse(fileContent);
            fileContent = jsonObject.ToString();
            return fileContent;
        }
        catch (Exception)
        {
            throw new Exception("Something went wrong while reading your JSON-file.");
        }

    }

}