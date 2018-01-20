using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintKD.Files
{
    class FilesWork
    {
        //new to add show dialog 
        private static void LoadDll()
        {
           // string file = Directory.GetCurrentDirectory() + "\\Biblioteka.dll"; //dll file in debug/release directiry
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "Liblaries |*.dll"
            };
            var a = Assembly.LoadFile(openFile.FileName);

            foreach (var t in a.GetTypes())
            {
                if (t.IsClass && t.IsPublic && typeof(DrawingShapes.IShape).IsAssignableFrom(t))
                {
                    var o = Activator.CreateInstance(t);
                    var w = (DrawingShapes.IShape)o;
                }
            }
        }

        //move here save load
        public static ImageSource BitmapFromUri(Uri source)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = source;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            return bitmap;
        }

        public ImageBrush LoadFile()
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "Png files|*.png|Jpeg files|*.jpg|Bitmaps|*.bmp"
            };
            ImageBrush brush = new ImageBrush();
            if (openFile.ShowDialog() == true)
            {
                brush.ImageSource = BitmapFromUri(new Uri(openFile.FileName, UriKind.Relative));
                return brush;
            }
            return null;
        }

        public void SaveFile(Canvas cPaint)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Png files|*.png|Jpeg files|*.jpg|Bitmaps|*.bmp"
            };
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)cPaint.RenderSize.Width, (int)cPaint.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(cPaint);
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
            if (dialog.ShowDialog() == true)
            {
                using (var fs = System.IO.File.OpenWrite((dialog.FileName)))
                {
                    pngEncoder.Save(fs);
                }
            }
        }
    }
}
