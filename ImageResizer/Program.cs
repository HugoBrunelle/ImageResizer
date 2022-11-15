Console.WriteLine("====================================================");
Console.WriteLine("         Image Resizer v1.0 by Hugo Brunelle ");
Console.WriteLine("====================================================");


Console.WriteLine("");
Console.WriteLine("");

Console.Write("\t\tTarget folder: ");
string target = Console.ReadLine();

if (target == String.Empty || !Directory.Exists($"{Directory.GetCurrentDirectory()}\\{target}"))
{
    ShowError("Folder does not exists");
    return -1;
}

string[] images = Directory.GetFiles(target);
if (images.Length == 0)
{
    ShowError("No images found inside the folder");
    return -1;
}

Console.Write("\t\tWidth: ");
string widthString = Console.ReadLine();
int width = 0;
if (!Int32.TryParse(widthString, out width))
{
    ShowError("Width wrong format");
    return -1;
}

Console.Write("\t\tHeight: ");
string heightString = Console.ReadLine();
int height = 0;
if (!Int32.TryParse(heightString, out height))
{
    ShowError("Height wrong format");
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

void ShowError(string message)
{
    Console.WriteLine("");
    Console.WriteLine("\t" + message);
    Console.ReadKey();
}

return 1;