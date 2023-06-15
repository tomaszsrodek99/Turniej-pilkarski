using Football.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Models
{
    public class MatchViewModel
    {
        public int MatchId { get; set; }
        public string HomeId { get; set; }
        public string VisitorId { get; set; }
        public string PlayStage { get; set; }
        public int HomeGoals { get; set; }
        public int VisitorGoals { get; set; }
        public DateTime MatchDate { get; set; }
        public int? HomeGoalsP { get; set; }
        public int? VisitorGoalsP { get; set; }
    }
}
