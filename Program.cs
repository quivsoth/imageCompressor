using System.Text;
using System.Runtime.CompilerServices;
using System.Net.Mime;
using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace imageCompressor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Image Compression");

            var encoder = new PngEncoder
            {
                BitDepth = PngBitDepth.Bit8,
                ColorType = PngColorType.RgbWithAlpha
            };

            using (Image<Rgba32> image = Image.Load<Rgba32>("j.jpeg"))
            {       
                image.Mutate(x => x
                    .Resize(0, 1100)); 

                PngEncoder enc = new PngEncoder();
    // enc.CompressionLevel = 9;
    enc.ColorType = PngColorType.Palette;
    enc.BitDepth = PngBitDepth.Bit8;

                image.Save("output.png", enc); // Automatic encoder selected based on extension.
            }
        }
    }
}