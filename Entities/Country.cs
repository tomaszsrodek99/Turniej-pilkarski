using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Entities
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Trener")]
        public int? CoachID { get; set; }

        [StringLength(35, MinimumLength = 4, ErrorMessage = "Długość musi wynosić między 4 a 35 liter.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Pole może zawierać tylko litery. Nazwa musi rozpoczynać się wielką literą.")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Nazwa drużyny")]
        public string CountryName { get; set; }

        [StringLength(1)]
        public string Grupa { get; set; }

        [ForeignKey("CoachID")]
        public virtual Coach Coach { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
    public enum Group
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H
    }
}
