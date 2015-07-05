using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class helper_DangNhap
    {
        public static bool KiemTraSoLanNhapSai(int i_SoLanSai)
        {
            bool kq = true;
            if (DocFileDangNhap() != "")
            {
                if (i_SoLanSai == 1)
                {
                    kq = false;
                }
            }
            else
            {
                if (i_SoLanSai > 3)
                {
                    kq = false;
                }
            }
            return kq;
        }
        public static void GhiFileDangNhap(int i_SoLanSai)
        {
            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
            StreamWriter sw = new StreamWriter(new IsolatedStorageFileStream("DangNhapSai.txt", FileMode.Append, isf));
            sw.WriteLine(i_SoLanSai);
            sw.Close();
        }
        public static string DocFileDangNhap()
        {
            string str_NoiDung = "";
            try
            {
                IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
                StreamReader sr = new StreamReader(new IsolatedStorageFileStream("DangNhapSai.txt", FileMode.Open, isf));
                str_NoiDung = sr.ReadToEnd();
                sr.Close();
            }
            catch
            {
                //khi không tìm thấy file
            }
            return str_NoiDung;
        }
    }
}
