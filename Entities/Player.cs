using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Entities
{
    public class Player
    {
        public Player()
        {

        }
        [Key]
        public int PlayerID { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int CountryID { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Imię i nazwisko zawodnika")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Długość musi wynosić między 4 a 50 liter.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Pole może zawierać tylko litery. Nazwa musi rozpoczynać się wielką literą.")]
        public string PlayerFullName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Pozycja")]
        public string Position { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Range(15, 58, ErrorMessage = "Minimalny wiek to 15, a maksymalny to 58.")]
        [Display(Name = "Wiek")]
        public int Age { get; set; }

        [StringLength(50, ErrorMessage = "Maksymalna długość to 50 liter.")]
        [Display(Name = "Klub")]
        public string Club { get; set; }

        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
    }
    public enum PositionType
    {
        GK, // Bramkarz
        CB, // Środkowy obrońca
        CM, // Środkowy pomocnik
        ST // Napastnik
    }
}
