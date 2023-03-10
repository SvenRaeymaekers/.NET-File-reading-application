using Newtonsoft;

public class JsonFileReader : AbstractFileReader
{

    public override void ReadFile(string filePath)
    {
        try
        {

            StreamReader sr = new StreamReader(filePath);
            string json = sr.ReadToEnd();
            dynamic jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            Console.WriteLine(jsonObject);
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
        Console.WriteLine("Json file has been read.");
    }
}