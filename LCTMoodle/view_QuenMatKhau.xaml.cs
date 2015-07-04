using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text.RegularExpressions;

namespace LCTMoodle
{
    public partial class view_QuenMatKhau : PhoneApplicationPage
    {
        public view_QuenMatKhau()
        {
            InitializeComponent();
        }
        private void btnNhanMail_Click(object sender, RoutedEventArgs e)
        {
            if (txt_email_quenmk.Text != "")
            {
                if (ValidateEmail(txt_email_quenmk.Text))
                {
                    if (Exits_Mail_From_DB(txt_email_quenmk.Text))
                    {
                        MessageBox.Show("Thành công, bạn vui lòng check mail");
                    }
                    else
                    {
                        MessageBox.Show("Mail chưa đăng ký");
                    }
                }
                else
                {
                    MessageBox.Show("Sai định dạng email");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mail vào");
            }
        }
        public static bool ValidateEmail(string str)
        {
            return Regex.IsMatch(str, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }
        public static bool Exits_Mail_From_DB(string str)
        {
            bool kq = false;
            List<string> db = new List<string>();
            string huy = "huyphong@gmail.com";
            string hong = "hongphu@gmail.com";
            db.Add(huy);
            db.Add(hong);

            for (int i = 0; i < db.Count(); i++)
            {
                if (db[i] == str)
                {
                    kq = true;
                }
            }
            return kq;
        }
    }
}