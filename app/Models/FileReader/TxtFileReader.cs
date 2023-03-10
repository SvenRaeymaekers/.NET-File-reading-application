

public class TxtFileReader : AbstractFileReader
{


    public override void ReadFile(string filePath)
    {
        string input_line;
        try
        {

            StreamReader sr = new StreamReader(filePath);
            input_line = sr.ReadLine();
            Console.WriteLine("Reading your text file now:\n");
            while (input_line != null)
            {
                
                Console.WriteLine(input_line);
                input_line = sr.ReadLine();
            }
            Console.WriteLine("\n");
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
        Console.WriteLine("Text file has been read.");
    }

}