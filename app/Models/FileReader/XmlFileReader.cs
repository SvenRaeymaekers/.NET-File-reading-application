


using System.Xml;

public class XmlFileReader : AbstractFileReader
{


    //printing functionality has to be improved, nice structure necessary.
    public override void ReadFile(string filePath)
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
                
                PrintXMLNodes(node.ChildNodes);
            }
            else
            {
                Console.WriteLine("{0}: {1}", node.ParentNode.Name, node.InnerText);
            }
        }
    }
}