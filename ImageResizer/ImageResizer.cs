using System.Drawing;
using System.Drawing.Imaging;

namespace ImageResizer
{
    internal class ImageResizer
    {
        public static void resize(string target, string output, int width, int height)
        {
            try
            {
                FileStream file = File.OpenRead(target);
                Image image = Image.FromStream(file);
                byte[] imagesBytes = toByteArray(image, width, height);
                writeToDisk(imagesBytes, output);
            } 
            catch(Exception e)
            {
                Console.WriteLine("Could'nt process the images");
                Console.WriteLine(e.Message);
            }
        }

        private static byte[] toByteArray(Image image, int width, int height)
        {
            Bitmap resized = new Bitmap(image, new Size(width, height));
            using var imageStream = new MemoryStream();
            resized.Save(imageStream, ImageFormat.Jpeg);
            return imageStream.ToArray();
        }

        private static void writeToDisk(byte[] data, string output)
        {
            using (var stream = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.Write, 4096))
            {
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
