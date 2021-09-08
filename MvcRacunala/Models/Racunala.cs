using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRacunala.Models
{
    public class Racunala
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Naziv { get; set; }

        [Display(Name = "Datum Izdavanja")]
        [DataType(DataType.Date)]
        public DateTime DatumIzdavanja { get; set; }

        [Required]
        [StringLength(30)]
        public string Vrsta { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cijena { get; set; }
        public string Stanje { get; set; }
    }
}
