using System.Xml;
using System.IO;

public class FileHandler
{

    private string[] _allowedFileTypes = { "txt", "xml", "json" };


    // main function of this class that will handle everything about the file and file type.
    //possible problem when you need to add a new file type that you need to add new code to this function
    //is that seen as proper coding? not sure. At this moment no idea how to extract this
    public void ReadFile(string filePath)
    {
        RaiseExceptionIfFileDoesntExist(filePath);
        string fileType = ReturnFileTypeOfFilePath(filePath);
        switch (fileType)
        {
            case "txt":
                ReadTextFile(filePath);
                break;
            case "xml":
                ReadXMLFile(filePath);
                break;
            case "json":
                ReadJSONFile(filePath);
                break;


            default:
                break;
        }

    }


    private string ReturnFileTypeOfFilePath(string filePath)
    {
        string fileExtension = Path.GetExtension(filePath);
        string fileType = fileExtension.Substring(1);
        if (!_allowedFileTypes.Contains(fileType))
        {
            throw new Exception("The file type you provided is currently not allowed. The supported file types are: " + string.Join(",", _allowedFileTypes));
        }
        return fileType;
    }


    private void RaiseExceptionIfFileDoesntExist(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File Path {filePath} does not exist.");
        }
    }

    private void ReadTextFile(string filePath)
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

    private void ReadXMLFile(string filePath)
    {

        XmlDocument doc = new XmlDocument();
        doc.Load(filePath);


        XmlNode root = doc.DocumentElement;

        Console.WriteLine(root.Name);
        PrintXMLNodes(root.ChildNodes);

    }

    private void PrintXMLNodes(XmlNodeList nodes)
    {
        foreach (XmlNode node in nodes)
        {
            if (node.HasChildNodes)
            {
                Console.WriteLine(node.Name);
                //Console.Write("\t");
                PrintXMLNodes(node.ChildNodes);
            }
            else
            {
                Console.WriteLine("{0}: {1}", node.ParentNode.Name, node.InnerText);
            }
        }
    }
    private void ReadJSONFile(string filePath)
    {

    }
}