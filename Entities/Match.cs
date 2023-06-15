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
        [Required]
        [Display(Name = "Data")]
        public DateTime? MatchDate { get; set; }

        [Required]
        [Display(Name = "Gospodarze")]
        public int HomeId { get; set; }
        [Display(Name = "Bramki gospodarzy")]
        public int? HomeScore { get; set; }

        [Required]
        [Display(Name = "Goście")]
        public int VisitorId { get; set; }
        [Display(Name = "Bramki gości")]
        public int? VisitorScore { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Szczebel rozgrywek")]
        public string PlayStage { get; set; }

        [Display(Name = "Bramki gospodarzy - karne")]
        public int? HomeScoreP { get; set; }
        [Display(Name = "Bramki gości - karne")]
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
