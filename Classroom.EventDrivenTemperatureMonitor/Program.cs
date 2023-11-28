namespace Classroom.EventDrivenTemperatureMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TemperatureMonitor temperature = new TemperatureMonitor();
            temperature.OnMaxTemperature += HighTemperature;
            temperature.OnMinTemperature += LowTemperature;

            temperature.IncreaseTemperature(16);
            temperature.IncreaseTemperature(46);

            temperature.DecreaseTemperature(70);
        }
        private static void HighTemperature(int t)
        {
            Console.WriteLine($" High Temperature Alert! Temperature has exceeded {t} °C.");
        }
        private static void LowTemperature(int t)
        {
            Console.WriteLine($"Low Temperature Alert! Temperature has dropped below {t}°C.\r\n");
        }
    }
}