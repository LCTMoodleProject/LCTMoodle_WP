using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.IO.IsolatedStorage;

namespace Helper
{
    public static class helper_Captcha
    {
        
        public static String _strCaptcha = "";
        /// <summary>
        /// Sau khi nhập đúng captcha thì tiến hành xóa trắng file
        /// </summary>
        public static void XoaSoLanSai()
        {
            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
            StreamWriter sw = new StreamWriter(new IsolatedStorageFileStream("DangNhapSai.txt", FileMode.Create, isf));
            sw.Write("");
            sw.Close();
        }
        /// <summary>
        /// Lấy 5 ký tự bất kỳ từ chuỗi mã hóa MD5 của 1 ký tự trong hàm GetMD5
        /// </summary>
        /// <returns>5 ký tự bất kì cuối chuỗi</returns>
        public static void LayChuoiNgauNhien()
        {
            Random rand = new Random();
            String str = GetMD5(rand.Next().ToString());
            _strCaptcha = str.Substring(str.Length - 5);
        }
        /// <summary>
        /// Lấy chuỗi mã hóa MD5 của 1 kí tự bất kì
        /// </summary>
        /// <param name="input">kí tự cần mã hóa</param>
        /// <returns>Chuỗi kí tự mã hóa</returns>
        public static String GetMD5(string input)
        {
            MD5 md5Hash = new MD5();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
        /// <summary>
        /// Vẽ hình ảnh cho captcha
        /// </summary>
        /// <returns>hình ảnh dạng byte array</returns>
        public static byte[] drawImage()
        {
            using (MemoryStream mem = new MemoryStream())
            {
                Random rd = new Random();
                string imgBase = rd.Next(1, 5).ToString();
                BitmapImage img = new BitmapImage();
                StreamResourceInfo r = System.Windows.Application.GetResourceStream(new Uri("Image/" + imgBase + ".png", UriKind.Relative));
                img.SetSource(r.Stream);

                WriteableBitmap wb = new WriteableBitmap(img);
                TextBlock tb = new TextBlock();
                tb.FontSize = 40;
                tb.Foreground = new SolidColorBrush(Colors.Gray);
                tb.Text = _strCaptcha;

                TranslateTransform tf = new TranslateTransform();
                tf.X = 40;
                tf.Y = 40;
                wb.Render(tb, tf);
                wb.Invalidate();

                wb.SaveJpeg(mem, wb.PixelWidth, wb.PixelHeight, 0, 100);
                mem.Seek(0, System.IO.SeekOrigin.Begin);

                return mem.ToArray();
            }
        }
    }
}
