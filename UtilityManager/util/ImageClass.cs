using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UtilityManager.util
{
    public class ImageClass
    {
        public static byte[] ReadFile(string sPath)
        {
            byte[] image = null;
            var file = new FileInfo(sPath);
            var numBytes = file.Length;

            var stream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            var br = new BinaryReader(stream);
            image = br.ReadBytes((int) numBytes);
            return image;
        }

        public static void GetImage(byte[] bData, PictureBox pics)
        {
            try
            {
                var imageData = bData;
                Image newImage;
                using (var ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms, true);
                }
                pics.Image = newImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static byte[] ImageToByte(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image ByteToImage(byte[] byteArray)
        {
            var ms = new MemoryStream(byteArray);
            var image = Image.FromStream(ms);
            return image;
        }

    }
}
