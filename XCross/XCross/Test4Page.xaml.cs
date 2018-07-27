using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCross
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test4Page : ContentPage
    {
        public Test4Page()
        {
            InitializeComponent();
            int rows = 128;
            int columns = 128;
            BmpMaker bmpMaker = new BmpMaker(columns, rows);
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    bmpMaker.SetPixel(row, column, 3 * row, 0, 2 * (128 - column));
                }
            }
            ImageSource imageSource = bmpMaker.Generate();
            MainImage.Source = imageSource;
        }
    }
    public class BmpMaker
    {
        const int headerSize = 54;
        readonly byte[] buffer;
        public BmpMaker(int width, int height)
        {
            Width = width;
            Height = height;
            int numPixels = Width * Height;
            int numPixelBytes = 4 * numPixels;
            int fileSize = headerSize + numPixelBytes;
            buffer = new byte[fileSize];
            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.UTF8))
                {
                    binaryWriter.Write(new char[] { 'B', 'M' });
                    binaryWriter.Write(fileSize);
                    binaryWriter.Write((short)0);
                    binaryWriter.Write((short)0);
                    binaryWriter.Write(headerSize); 
                    binaryWriter.Write(40);
                    binaryWriter.Write(Width);
                    binaryWriter.Write(Height);
                    binaryWriter.Write((short)1);
                    binaryWriter.Write((short)32);
                    binaryWriter.Write(0);
                    binaryWriter.Write(numPixelBytes);
                    binaryWriter.Write(0);
                    binaryWriter.Write(0);
                    binaryWriter.Write(0);
                    binaryWriter.Write(0);        
                }
            }
        }
        public int Width
        {
            private set;
            get;
        }
        public int Height
        {
            private set;
            get;
        }
        public void SetPixel(int row, int column, Color color)
        {
            SetPixel(row,
                column,
                (int)(255 * color.R),
                (int)(255 * color.G),
                (int)(255 * color.B),
                (int)(255 * color.A));
        }
        public void SetPixel(int row, int column, int r, int g, int b, int a = 255)
        {
            int index = (row * Width + column) * 4 + headerSize;
            buffer[index + 0] = (byte)b;
            buffer[index + 1] = (byte)g;
            buffer[index + 2] = (byte)r;
            buffer[index + 3] = (byte)a;
        }
        public ImageSource Generate()
        {
            MemoryStream memoryStream = new MemoryStream(buffer);
            ImageSource imageSource = ImageSource.FromStream(() =>
              {
                  return memoryStream;
              });
            return imageSource;
        }
    }
}