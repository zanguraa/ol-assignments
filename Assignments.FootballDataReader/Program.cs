namespace Assignments.FootballDataReader
{
    internal class Program
    {
       static async Task Main(string[] args)
        {
            try
            {
                string executablePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(executablePath, "football_results.csv");
                var data = await FootballDataAsync(filePath);

                int matchCount = await AllMatchCount(data);

                Console.WriteLine($"Total matches: {matchCount}");

               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static async Task<List<Match>> FootballDataAsync(string filePath)
        {
            List<Match> footballObject = new List<Match>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    await reader.ReadLineAsync(); 

                    while (!reader.EndOfStream)
                    {
                        string football = await reader.ReadLineAsync();
                        string[] values = football.Split(',');

                        if (values.Length >= 9 && values[3] != "NA" && values[4] != "NA" &&
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
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }

            return footballObject;
        }

        public static async Task<int> AllMatchCount(List<Match> data)
        {
            return await Task.Run(() => data.Count);
        }

    }
}
