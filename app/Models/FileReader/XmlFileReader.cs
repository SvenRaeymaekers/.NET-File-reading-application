
using System.Text;

using System.Xml;

public class XmlFileReader : AbstractFileReader
{


    //printing functionality has to be improved
    public override string ReadFile(string filePath, bool isFileEncrypted, FileDataDecryptor fileDataDecryptor)
    {

        string xmlString = File.ReadAllText(filePath);
        if (isFileEncrypted)
        {
            xmlString = fileDataDecryptor.DecryptContent(xmlString);
        }
    
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlString);
        XmlNode root = doc.DocumentElement;
        Console.WriteLine(root.Name);
        StringBuilder fileContent = new StringBuilder();
        retrieveXMLContent(root.ChildNodes, fileContent);
        return fileContent.ToString();
    }
    private void retrieveXMLContent(XmlNodeList nodes, StringBuilder fileContent)
    {
        foreach (XmlNode node in nodes)
        {
            fileContent.AppendLine(node.ParentNode.Name.ToString() + ": " + node.InnerText.ToString());

            if (node.HasChildNodes)
            {
                fileContent.AppendLine(node.Name);

                retrieveXMLContent(node.ChildNodes, fileContent);
            }
           
        }
    }
}