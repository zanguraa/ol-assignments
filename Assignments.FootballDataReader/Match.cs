using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.FootballDataReader
{
    public class Match
    {
        public DateTime Date { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public string Tournament { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool Neutral { get; set; }

        public Match(DateTime date, string homeTeam, string awayTeam, int homeScore, int awayScore, string tournament, string city, string country, bool neutral )
        {
            Date = date;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = homeScore;
            AwayScore = awayScore;
            Tournament = tournament;
            City = city;
            Country = country;
            Neutral = neutral;
        }

         public override string ToString()
    {
        return $"{Date.ToShortDateString()} - {HomeTeam} vs {AwayTeam}, Score: {HomeScore}-{AwayScore}, Tournament: {Tournament}, Location: {City}, {Country}, Neutral: {Neutral}";
    }

    }
}
