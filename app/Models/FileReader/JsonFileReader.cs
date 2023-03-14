using Newtonsoft;
using Newtonsoft.Json.Linq;

public class JsonFileReader : AbstractFileReader
{

    public override string ReadFile(string filePath, bool isFileEncrypted, FileDataDecryptor fileDataDecryptor)
    {
        string fileContent = "";
        try
        {
            string json = File.ReadAllText(filePath);
            if (isFileEncrypted)
            {
                json = fileDataDecryptor.DecryptContent(json);
            }
            JObject jsonObject = JObject.Parse(json);
            fileContent = jsonObject.ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while reading your json-file:" + e.Message);
        }
        return fileContent;

    }


}