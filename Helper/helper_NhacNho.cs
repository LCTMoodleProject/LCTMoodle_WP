using Microsoft.Phone.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class helper_NhacNho
    {
        /// <summary>
        /// Tạo nhắc nhở, truyền vào ngày, giờ, nội dung nhắc
        /// </summary>
        /// <param name="dt_Ngay">biến thời gian, ngày và giờ</param>
        /// <param name="ts_Gio">biến giờ đc lấy ra từ ngày</param>
        /// <param name="str_NoiDung">nội dung báo</param>
        public static void DatNhacNho(DateTime dt_Ngay, DateTime ts_Gio, string str_NoiDung)
        {
            TimeSpan ts_Gio_Day = ts_Gio.TimeOfDay;
            dt_Ngay = dt_Ngay.Date + ts_Gio_Day;
            if (ScheduledActionService.Find("TodoReminder") != null)
            {
                ScheduledActionService.Remove("TodoReminder");
            }
            Reminder _Reminder = new Reminder("TodoReminder")
            {
                BeginTime = dt_Ngay,
                Title = "Nhắc nhở từ LCTMoodle",
                Content = str_NoiDung,
            };
            ScheduledActionService.Add(_Reminder);
        }
        /// <summary>
        /// Bỏ tiến trình nhắc nhở trong ActionService
        /// </summary>
        public static void BoNhacNho()
        {
            try
            {
                ScheduledActionService.Remove("TodoReminder");
            }
            catch
            {
                //khi không tìm thấy nhắc nhở
            }
        }
        /// <summary>
        /// Kiểm tra xem thời gian được đặt lần trc đó là bao nhiêu (nếu có đặt)
        /// </summary>
        /// <returns>trả về thời gian được đặt trước đó</returns>
        public static DateTime KiemTraThoiGianNhacNho()
        {
            DateTime dt;
            ScheduledAction OldReminder = ScheduledActionService.Find("TodoReminder");
            if (OldReminder != null)
            {
                dt = OldReminder.BeginTime;
            }
            else
            {
                dt = DateTime.Now;
            }
            return dt;
        }
    }
}
