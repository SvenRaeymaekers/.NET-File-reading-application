using Newtonsoft;

public class JsonFileReader : AbstractFileReader
{

    public override string ReadFile(string filePath)
    {
        string fileContent = "";
        try
        {

            StreamReader sr = new StreamReader(filePath);
            string json = sr.ReadToEnd();
            dynamic jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            fileContent = jsonObject;
            sr.Close();
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to " +
            "read your file with the following message: " + e.Message);
        }
        finally
        {

        }
        return fileContent;

    }
}