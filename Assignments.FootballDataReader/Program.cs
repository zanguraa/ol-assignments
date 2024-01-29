namespace Assignments.FootballDataReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(executablePath, "football_results.csv");
            var data = FootballData(filePath);

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
          

        }

        public static List<Match> FootballData(string filePath)
        {
            List<string> footballData = File.ReadAllLines(filePath).ToList();
            footballData.RemoveAt(0);

            List<Match> footballObject = new List<Match>();

            foreach (string football in footballData)
            {
                string[] values = football.Split(',');

                if (values[3] != "NA" && values[4] != "NA" &&
                    int.TryParse(values[3], out int homeScore) && int.TryParse(values[4], out int awayScore))
                {
                    Match match = new Match(
                        date: DateTime.Parse(values[0]),
                        homeTeam: values[1],
                        awayTeam: values[2],
                        homeScore: homeScore,
                        awayScore: awayScore,
                        tournament: values[5],
                        city: values[6],
                        country: values[7],
                        neutral: bool.Parse(values[8]));

                    footballObject.Add(match);
                }

                else
                {
                    Console.WriteLine("Error: Invalid score values in a row");
                }

            }

            return footballObject;
        }




    }
}