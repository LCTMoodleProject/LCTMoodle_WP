using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class helper_HinhAnh 
    {
        public static byte[] layHinhMacDinh_NguoiDung()
        {
            string _DuongDan = "HinhAnh/HeThong/default_NguoiDung.png";

            if (File.Exists(@_DuongDan))
            {
                FileStream fs = File.OpenRead(@_DuongDan);
                byte[] hinhAnh = new byte[fs.Length];
                fs.Read(hinhAnh, 0, Convert.ToInt32(fs.Length));
                return hinhAnh;
            }
            return null;
        }
    }
}
