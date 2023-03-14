
public class FileReaderFactory
{


    public IFileReader CreateFileReader(string fileType)
    {

        switch (fileType)
        {
            case "txt":
                return new TxtFileReader();
            case "xml":
                return new XmlFileReader();
            case "json":
                return new JsonFileReader();
            default:
                //checking whether the file type is currently supported is already implemented in controller
                // but let's assume this acts like a double-check
                throw new ArgumentException($"Reading files of type {fileType} is currently not supported.");
        }
    }
}