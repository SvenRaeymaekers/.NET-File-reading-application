
public class FileReaderFactory
{

    public IFileReader CreateJsonFileReader()
    {
        return new JsonFileReader();
    }
    public IFileReader CreateTxtFileReader()
    {
        return new TxtFileReader();
    }
    public IFileReader CreateXmlFileReader()
    {
        return new XmlFileReader();
    }

}