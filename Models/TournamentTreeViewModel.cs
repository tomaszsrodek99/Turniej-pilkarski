using Football.Entities;
using System.Collections.Generic;

namespace Football.Models
{
    public class TournamentTreeViewModel
    {
        public List<MatchViewModel> QuarterFinalMatches { get; set; }
        public List<MatchViewModel> SemiFinalMatches { get; set; }
        public MatchViewModel FinalMatch { get; set; }
    }
}