using System.Text;

public class TxtFileReader : AbstractFileReader
{


    public override string ReadFile(string filePath)
    {
        string input_line;
        StringBuilder fileContent = new StringBuilder();
        try
        {

            StreamReader sr = new StreamReader(filePath);
            input_line = sr.ReadLine();

            while (input_line != null)
            {

                fileContent.AppendLine(input_line);
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
        return fileContent.ToString();
    }

}