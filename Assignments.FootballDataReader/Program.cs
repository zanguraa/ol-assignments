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

                var mostGoalScorerCountry = await MostGoalScorerCountryAsync(data);
                Console.WriteLine("---------------------------");

                Console.WriteLine("Most Goal Scorer Country:");
                foreach (var goalscorer in mostGoalScorerCountry)
                {
                    Console.WriteLine(goalscorer);
                }

                var lessGoallScorerCountry = await LessGoalScorerCountryAsync(data);
                Console.WriteLine("---------------------------");
                Console.WriteLine("Less Goal Scorer Country:");
                foreach (var goalscorer in lessGoallScorerCountry)
                {
                    Console.WriteLine(goalscorer);

                }

                var avgHomeGoals = await AvgHomeGoalByCountryAsync(data);
                Console.WriteLine("---------------------------");


                foreach (var avgGoal in avgHomeGoals)
                {
                    Console.WriteLine($"{avgGoal}");
                }



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

                        if (int.TryParse(values[3], out int homeScore) && int.TryParse(values[4], out int awayScore))
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

        public static async Task<List<string>> MostGoalScorerCountryAsync(List<Match> data)
        {
            try
            {
                var mostGoalScorerCountry = await Task.Run(() =>
                {
                    var goalScorerByCountry = data
                        .GroupBy(match => match.Country)
                        .Select(group => new
                        {
                            Country = group.Key,
                            TotalGoals = group.Sum(match => match.HomeScore + match.AwayScore)
                        })
                        .OrderByDescending(x => x.TotalGoals)
                        .FirstOrDefault();

                    return goalScorerByCountry != null
                        ? new List<string> { $"{goalScorerByCountry.Country}: {goalScorerByCountry.TotalGoals} goals" }
                        : new List<string> { "No matches available" };
                });

                return mostGoalScorerCountry;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating most goal scorer country: {ex.Message}");
                return new List<string> { "Error occurred during calculation" };
            }
        }

        public static async Task<List<string>> LessGoalScorerCountryAsync(List<Match> data)
        {
            try
            {
                var lessGoalScorerCountry = await Task.Run(() =>
                {
                    var goalScorerByCountry = data
                        .GroupBy(match => match.Country)
                        .Select(group => new
                        {
                            Country = group.Key,
                            TotalGoals = group.Sum(match => match.HomeScore + match.AwayScore)
                        })
                        .OrderBy(x => x.TotalGoals)
                        .FirstOrDefault();

                    return goalScorerByCountry != null
                        ? new List<string> { $"{goalScorerByCountry.Country}: {goalScorerByCountry.TotalGoals} goals" }
                        : new List<string> { "No matches available" };
                });

                return lessGoalScorerCountry;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating less goal scorer country: {ex.Message}");
                return new List<string> { "Error occurred during calculation" };
            }
        }

        public static async Task<List<string>> AvgHomeGoalByCountryAsync(List<Match> data)
        {
            try
            {
                var avgHomeGoalsByCountry = await Task.Run(() =>
                {
                    var result = data
                        .GroupBy(match => match.Country)
                        .Select(group => new
                        {
                            Country = group.Key,
                            AvgHomeGoals = group.Average(match => match.HomeScore)
                        })
                        .OrderByDescending(x => x.AvgHomeGoals)
                        .Select(x => $"{x.Country}: Avg Home Goals Scored - {x.AvgHomeGoals:F2}")
                        .Take(10).ToList();

                    return result.Any()
                        ? result
                        : new List<string> { "No matches available" };
                });

                return avgHomeGoalsByCountry;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating average home goals by country: {ex.Message}");
                return new List<string> { "Error occurred during calculation" };
            }
        }




    }
}
