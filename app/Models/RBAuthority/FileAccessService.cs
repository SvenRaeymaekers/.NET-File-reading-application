using System.Xml;
using System.Collections.Generic;

public class FileAccessService
{

    
    // dictionary that keeps role and it's corresponding allowed file types that the role can read. the config/security.xml file is saved in this dict.
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
        
        // important remark: the parameter allowedFilesByRoleFilePath is a relative path, which has been set in the FileController. Changing the relative path to an absolute will cause fileNotFound
        
        //construct absolute path
        string currentDirectory = Directory.GetCurrentDirectory();
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