using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Entities
{
    public class Coach
    {
        [Key]
        public int CoachID { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Imię trenera")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Pole może zawierać tylko litery. Nazwa musi rozpoczynać się wielką literą.")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "Długość musi wynosić między 4 a 40 liter.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Nazwisko Trenera")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Pole może zawierać tylko litery. Nazwa musi rozpoczynać się wielką literą.")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "Długość musi wynosić między 4 a 40 liter.")]
        public string Lastname { get; set; }
    }
}
