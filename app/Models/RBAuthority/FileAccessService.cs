using System.Xml;
using System.Collections.Generic;

public class FileAccessService
{

    

    private Dictionary<string, List<string>> _allowedFilesByRole;

    public FileAccessService(string allowedFilesByRoleFilePath)
    {
        this._allowedFilesByRole = readUserRolesFromXML(allowedFilesByRoleFilePath);

    }

    public bool IsUserAllowedToReadFile(string role, string fileType)
    {
        bool isUserAllowed = false;
        
        if (this._allowedFilesByRole[role].Contains(fileType))
        {
            isUserAllowed = true;
        }

        return isUserAllowed;
    }


    private Dictionary<string, List<string>> readUserRolesFromXML(string allowedFilesByRoleFilePath)
    {
        

        string currentDirectory = Directory.GetCurrentDirectory();
        //string allowedFilesByRolePathAbsolute = Path.Combine(currentDirectory, allowedFilesByRoleFilePath);
        string allowedFilesByRolePathAbsolute = currentDirectory + allowedFilesByRoleFilePath;
        Dictionary<string, List<string>> allowedFilesByRole = new Dictionary<string, List<string>>();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(allowedFilesByRolePathAbsolute);


        //get all roles nodes within the file
        XmlNodeList nodes = xmlDoc.GetElementsByTagName("role");

        foreach (XmlNode roleNode in nodes)
        {

            // get value of name attribute from role and store as string roleName
            string roleName = roleNode.Attributes["name"].Value;
            List<string> allowedFilesForRole = new List<string>();

            foreach (XmlElement allowedFileTypeNode in roleNode.SelectNodes("allowedFiles/fileType"))
            {

                string fileType = allowedFileTypeNode.InnerText;
                allowedFilesForRole.Add(fileType);
            }
            allowedFilesByRole.Add(roleName, allowedFilesForRole);


        }
        return allowedFilesByRole;
    }
}