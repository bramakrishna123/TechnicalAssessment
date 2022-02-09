

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            int newHeight = 1600;
            int newWidth = 1200;
            string imagePath = $@"D:\SITECORE\{DateTime.Now.ToString("yyyyMMddHHmmss")}.jpg";
            string imageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTlkn_Yn-5A6PdDshvUOP2fjOtWL1yB1F_CQICJ1l7UegeoXcoIGbPrMJQ1J6aV-_avO4s&usqp=CAU";

            Stream stream = GetImageStream(imageUrl);
            if (stream!=null)
            {
                Image originalImage = System.Drawing.Image.FromStream(stream, true, true);
                Image resizedImage = resizeImage(originalImage, newHeight, newWidth);
                resizedImage.Save(imagePath);
            }
        }

        private Stream GetImageStream(string url) {
            try {
                WebClient client = new WebClient();
                return client.OpenRead(url);
            }
            catch { }
            return null;
        }

        public Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

    }
}
