using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.EventDrivenTemperatureMonitor
{
    public delegate void MyDelegate(int temperature);

    internal class TemperatureMonitor
    {
        public event MyDelegate OnMaxTemperature;
        public event MyDelegate OnMinTemperature;

        private const int LowTemp = -10;
        private const int HighTemp = 45;
        private int _currTemperature = 0;

        public void IncreaseTemperature(int temperature)
        {
            _currTemperature += temperature;
            if (_currTemperature > HighTemp)
            {
                OnMaxTemperature(_currTemperature - HighTemp);
            }
            Console.WriteLine($"Current Temperature: {_currTemperature} ");
        }
        public void DecreaseTemperature(int temperature)
        {
            _currTemperature -= temperature;
            if (_currTemperature < LowTemp)
            {
                OnMinTemperature(_currTemperature - LowTemp);
            }
            Console.WriteLine($"Current Temperature: {_currTemperature} ");
        }
    }
}
