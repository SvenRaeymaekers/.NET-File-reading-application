
using System.Text;

using System.Xml;

public class XmlFileReader : AbstractFileReader
{


    //printing functionality has to be improved, nice structure necessary.
    public override string ReadFile(string filePath)
    {
        StringBuilder fileContent = new StringBuilder();
        XmlDocument doc = new XmlDocument();
        doc.Load(filePath);


        XmlNode root = doc.DocumentElement;

        
        Console.WriteLine(root.Name);

        PrintXMLNodes(root.ChildNodes,fileContent);
        return fileContent.ToString();
    }
    private string PrintXMLNodes(XmlNodeList nodes, StringBuilder fileContent)
    {
        foreach (XmlNode node in nodes)
        {
            if (node.HasChildNodes)
            {
                fileContent.AppendLine(node.Name);
                
                PrintXMLNodes(node.ChildNodes,fileContent);
            }
            else
            {
                fileContent.AppendLine(node.ParentNode.Name.ToString() + ": " + node.InnerText.ToString());
            }
        }
        return fileContent.ToString();
    }
}