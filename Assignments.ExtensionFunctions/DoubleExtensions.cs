using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.ExtensionFunctions
{
    public static class DoubleExtensions
    {
        public static double ToPercent(this double value)
        {
            double percent = value * 100;
            return percent;
        }
        public static double RoundDown(this double value)
        {
            int intValue = (int)value;
            return value < 0 ? intValue - 1 : intValue;
        }
        public static decimal ToDecimal(this double value)
        {
            return (decimal)value;
        }
    }
}
