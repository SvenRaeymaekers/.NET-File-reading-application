
using System.Text;

using System.Xml.Linq;

public class XmlFileReader : AbstractFileReader
{



    public override string ReadFile(string filePath, bool isFileEncrypted, FileDataDecryptor fileDataDecryptor)
    {

        try
        {

            string xmlString = File.ReadAllText(filePath);
            if (isFileEncrypted)
            {
                xmlString = fileDataDecryptor.DecryptContent(xmlString);
            }

            //simple reading of xml file. if required, more advanced functionality can be coded here. (e.g. looping over XMLNodes)

            XDocument doc = XDocument.Parse(xmlString);
            return doc.ToString();
        }
        catch (Exception)
        {
            throw new Exception("Something went wrong while reading your XML-file.");
        }
    }

}