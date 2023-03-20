using System;
using System.Xml;
using System.Collections.Generic;


public class FileController
{
    private static string userRolesAuthorizationFilePath = "/config/.security.xml";
    private readonly FileReaderFactory _fileReaderFactory;
    private string[] _allowedFileTypes = { "txt", "xml", "json" };


    public FileController()
    {
        this._fileReaderFactory = new FileReaderFactory();
        this._roleBasedAuthorization = 
    }

    public string ProcessFile(string filePath, string fileType, bool isFileEncrypted)
    {

        //check if file exists, if not, throw exception.
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The file path you provided does not exist.", filePath);
        }
        fileType = fileType.Replace(".", "").ToLower();
        if (!_allowedFileTypes.Contains(fileType))
        {
            throw new ArgumentException("The file type you provided is not supported at this moment.", fileType);
        }

        //check if user is allowed to read the file
        


        IFileReader fileReader = _fileReaderFactory.CreateFileReader(fileType);
        // if (isEncrypted == true)
        // {
        //     IDecryptionStrategy decryptionStrategy = GetDecryptionStrategy(encryptionAlgorithm);
        //     ContentDecryptor contentDecryptor = new ContentDecryptor(decryptionStrategy);
        //     fileContent = contentDecryptor.DecryptContent(fileContent);
        // }
        FileDataDecryptor fileDataDecryptor = new FileDataDecryptor(new Base64DecryptionStrategy());
        string fileContent = fileReader.ReadFile(filePath, isFileEncrypted, fileDataDecryptor);

        return fileContent;
    }


    public Dictionary<string, string[]> readUserRolesFromXML(){


        Dictionary<string, string[]> roles = new Dictionary<string, string[]>();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(userRolesAuthorizationFilePath);
        

        //get all roles nodes within the file
        XmlNodeList nodes = xmlDoc.GetElementsByTagName("role");

        foreach (XmlNode role in nodes){

            // get value of name attribute from role and store as string roleName

            foreach (XmlDocument allowdFileTypeNode in role.SelectSingleNode("allowedFiles")){
                //string allowedRoleFileTypes
                //foreach fileType value in the allowdFileTypeNode, append to array
                // store in dictionairy for roleName
            }
    
        }


        return roles;




    }




}