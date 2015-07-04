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
    public partial class view_DangKy : PhoneApplicationPage
    {
        public view_DangKy()
        {
            InitializeComponent();
            btnDangKy.IsHitTestVisible = false;
            btnDangKy.Opacity = 0.6;
        }
        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            if (txt_email.Text == "" || txt_acc.Text == "" || pb_mk.Password == "" || pb_mk_re.Password == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin vào các trường còn trống");
            }
            else
            {
                if (ValidateEmail(txt_email.Text))
                {
                    if (ValidateAcc(txt_acc.Text))
                    {
                        if (ValidatePass(pb_mk.Password))
                        {
                            if (pb_mk.Password == pb_mk_re.Password)
                            {
                                MessageBox.Show("Đăng kí thành công");
                            }
                            else
                            {
                                MessageBox.Show("Mật khẩu chưa trùng");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu dài ít nhất 6 ký tự, gồm chữ thường, chữ hoa, số và không chứa ký tự đặc biệt");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập không bắt đầu bằng số và không chứa ký tự đặc biệt");
                    }
                }
                else
                {
                    MessageBox.Show("Sai định dạng mail");
                }
            }
        }
        public static bool ValidateEmail(string str)
        {
            return Regex.IsMatch(str, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }
        public static bool ValidateAcc(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]([a-zA-Z0-9]|\.|-){1,14}$");
        }
        public static bool ValidatePass(string str)
        {
            return Regex.IsMatch(str, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\d]).{6,20}$");
        }
        private void ckc_dk_Click(object sender, RoutedEventArgs e)
        {
            if (ckc_dk.IsChecked == true)
            {
                btnDangKy.IsHitTestVisible = true;
                btnDangKy.Opacity = 1;
            }
            else
            {
                btnDangKy.IsHitTestVisible = false;
                btnDangKy.Opacity = 0.6;
            }
        }
        #region Xử lý ô pass
        private void PasswordLostFocus(object sender, RoutedEventArgs e)
        {
            CheckPasswordWatermark();
        }

        public void CheckPasswordWatermark()
        {
            var passwordEmpty = string.IsNullOrEmpty(pb_mk.Password);
            pb_mk_hint.Opacity = passwordEmpty ? 100 : 0;
            pb_mk.Opacity = passwordEmpty ? 0 : 100;
        }

        private void PasswordGotFocus(object sender, RoutedEventArgs e)
        {
            pb_mk_hint.Opacity = 0;
            pb_mk.Opacity = 100;
        }
        #endregion

        #region Xử lý ô nhập lại pass
        private void PasswordLostFocus_re(object sender, RoutedEventArgs e)
        {
            CheckPasswordWatermark_re();
        }

        public void CheckPasswordWatermark_re()
        {
            var passwordEmpty = string.IsNullOrEmpty(pb_mk_re.Password);
            pb_mk_re_hint.Opacity = passwordEmpty ? 100 : 0;
            pb_mk_re.Opacity = passwordEmpty ? 0 : 100;
        }

        private void PasswordGotFocus_re(object sender, RoutedEventArgs e)
        {
            pb_mk_re_hint.Opacity = 0;
            pb_mk_re.Opacity = 100;
        }
        #endregion
    }
}