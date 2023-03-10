
public class FileReaderFactory
{


    public IFileReader CreateFileReader(string filePath)
    {

        //check if the file exists
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The file path you provided does not exist.", filePath);
        }


        string fileType = Path.GetExtension(filePath).Substring(1).ToLower();
        switch (fileType)
        {
            case "txt":
                return new TxtFileReader();
            case "xml":
                return new XmlFileReader();
            case "json":
                return new JsonFileReader();
            default:
                throw new ArgumentException($"Reading files of type {fileType} is currently not supported.");
        }
    }


}