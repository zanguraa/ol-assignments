using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.ExtensionFunctions
{
    public static class StringExtensions
    {
        public static bool IsNumber(this string str)
        {
            return double.TryParse(str, out  var number);   
        }

        public static bool IsDate(this string str)
        {
            return DateTime.TryParse(str, out var date);
        }
    }
}
