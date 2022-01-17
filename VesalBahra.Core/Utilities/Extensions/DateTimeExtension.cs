using System;
using System.Globalization;

namespace VesalBahar.Core.Utilities.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            if (dateTime == new DateTime()) return "";
            PersianCalendar persian = new PersianCalendar();
            var r = persian.GetYear(dateTime).ToString("00") + "/" +
                persian.GetMonth(dateTime).ToString("00") + "/" +
                persian.GetDayOfMonth(dateTime).ToString("00");

            return r;
        }
    }
}
