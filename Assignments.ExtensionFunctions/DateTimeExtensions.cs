using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.ExtensionFunctions
{
    public static class DateTimeExtensions
    {
        public static DateTime DateTimeMin(this DateTime dateTime1, DateTime dateTime2)
        {
            if (dateTime1 == dateTime2) return dateTime1;
            else if (dateTime1 > dateTime2) return dateTime2;
            else return dateTime1;
        }

        public static DateTime DateTimeMax(this DateTime dateTime1, DateTime dateTime2)
        {
            if (dateTime1 == dateTime2) return dateTime1;
            else if (dateTime1 > dateTime2) return dateTime1;
            else return dateTime2;
        }

        public static DateTime BeginingOfMonth(this DateTime dateTime1) 
        {
            return new DateTime(dateTime1.Year, dateTime1.Month, 1);
        }

        public static DateTime EndOfMonth(this DateTime dateTime1)
        {
            return new DateTime(dateTime1.Year, dateTime1.Month, DateTime.DaysInMonth(dateTime1.Year, dateTime1.Month));
        }
    }
}
