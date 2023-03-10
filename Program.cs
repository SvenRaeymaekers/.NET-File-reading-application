using System.IO;

String filePath;
Console.WriteLine("Please provide the path name of the file you would like to read.\n");
// filePath = Console.ReadLine();
filePath = "app/resources/sample.json";
FileReaderFactory fileReaderFactory = new FileReaderFactory();
IFileReader fileReader = fileReaderFactory.CreateFileReader(filePath);
fileReader.ReadFile(filePath);