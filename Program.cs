using System.IO;


FileHandler fileHandler = new FileHandler();
String filePath;
Console.WriteLine("Please provide the path name of the file you would like to read.\n");
//filePath = Console.ReadLine();
filePath = "resources/sample.xml";
fileHandler.ReadFile(filePath);

