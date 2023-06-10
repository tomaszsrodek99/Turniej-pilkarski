using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Entities
{
    public class Match
    {
        [Key]
        public int MatchID { get; set; }

        public DateTime? MatchDate { get; set; }

        [Required]
        public int HomeId { get; set; }

        public int? HomeScore { get; set; }

        [Required]
        public int VisitorId { get; set; }

        public int? VisitorScore { get; set; }

        [Required]
        [StringLength(1)]
        public string PlayStage { get; set; }

        [StringLength(1)]
        public string PenaltyScore { get; set; }

        public int? HomeScoreP { get; set; }

        public int? VisitorScoreP { get; set; }
        public virtual Country Home { get; set; }
        public virtual Country Visitor { get; set; }
    }

    public enum Stage
    {
        Grupa,
        [Display(Name = "1/8")]
        OneEighth,
        [Display(Name = "Ćwierćfinał")]
        QuarterFinal,
        [Display(Name = "Półfinał")]
        SemiFinal,
        [Display(Name = "Finał")]
        Final
    }
}
