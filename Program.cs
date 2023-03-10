using System.IO;

String filePath;
String IsEncrypted;

Console.WriteLine("Please provide the path name of the file you would like to read.\n");
// filePath = Console.ReadLine();
filePath = "app/resources/sample.txt";
Console.WriteLine("Is your File Encrypted?\n");
IsEncrypted = "Yes";



FileReaderFactory fileReaderFactory = new FileReaderFactory();
IFileReader fileReader = fileReaderFactory.CreateFileReader(filePath);
string fileContent = fileReader.ReadFile(filePath);

if(IsEncrypted == "Yes"){
    IDecryptionStrategy reverseStringDecryptionStrategy = new ReverseStringStrategy();
    ContentDecryptor contentDecryptor = new ContentDecryptor(reverseStringDecryptionStrategy);
    fileContent = contentDecryptor.DecryptContent(fileContent);
}

Console.WriteLine(fileContent);

