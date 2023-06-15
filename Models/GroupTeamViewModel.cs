using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Models
{
    public class GroupTeamViewModel
    {      
        [Display(Name = "Nazwa drużyny")]
        public string CountryName { get; set; }
        [Display(Name = "Bramki zdobyte")]
        public int GoalsFor { get; set; }
        [Display(Name = "Bramki stracone")]
        public int GoalsAgainst { get; set; }      
        [Display(Name = "Rozegrane mecze")]
        public int MatchesPlayed { get; set; }
        [Display(Name = "Punkty")]
        public int Points { get; set; }
        [Display(Name = "Grupa")]
        public string Group { get; set; }
    }

}
