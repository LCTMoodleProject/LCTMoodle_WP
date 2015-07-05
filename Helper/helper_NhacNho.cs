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
