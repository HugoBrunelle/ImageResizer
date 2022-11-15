Console.WriteLine("====================================================");
Console.WriteLine("         Image Resizer v1.0 by Hugo Brunelle ");
Console.WriteLine("====================================================");


Console.WriteLine("");
Console.WriteLine("");

Console.Write("\t\tTarget folder: ");
string target = Console.ReadLine();
if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\{target}"))
{
    Console.WriteLine("Folder does not exists");
    return -1;
}

Console.Write("\t\tWidth: ");
string widthString = Console.ReadLine();
int width = 0;
if (!Int32.TryParse(args[1], out width))
{
    Console.WriteLine("Width wrong format");
    return -1;
}

Console.Write("\t\tHeight: ");
string heightString = Console.ReadLine();
int height = 0;
if (!Int32.TryParse(args[2], out height))
{
    Console.Write("Height wrong format");
    return -1;
}

string[] images = Directory.GetFiles(target);
if (images.Length == 0)
{
    Console.WriteLine("No images found inside the folder");
    return -1;
}

string output = $"{Directory.GetCurrentDirectory()}\\output\\thumbnails";
if (!Directory.Exists(output))
{
    Directory.CreateDirectory(output);
}

Console.WriteLine("");
Console.WriteLine("\tAlright young children, Processing images...");

foreach (string img in images)
{
    ImageResizer.ImageResizer.resize(img, $"{output}\\{Path.GetFileName(img)}", width, height);
}

Console.WriteLine("\tResizing Complete !");
Console.WriteLine("");
Console.WriteLine("\tPress any key to continue...");
Console.ReadKey();

return 1;