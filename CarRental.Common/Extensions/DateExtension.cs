using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Extensions
{
    public static class DateExtension
    {

        //public static DateTime startDate { get; set; }
        //public static DateTime endDate { get; set; }

        public static int Duration(this DateTime startDate, DateTime endDate)
        {
            TimeSpan time = endDate.Subtract(startDate);
            int days = (int)Math.Ceiling(time.TotalDays);
            return days;
        }
    }
}
