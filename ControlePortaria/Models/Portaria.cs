using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePortaria.Models
{
    public class Portaria
    {
        [Key]
        public int PortariaID { get; set; }
        [Required]
        public int PessoaID { get; set; }
        [Required]
        public int CarroID { get; set; }

        [Required]
        public DateTime HorarioSaida { get; set; }

        [Required]
        public DateTime HorarioChegada { get; set; }

        [Required]
        [Precision(18, 2)]
        [Range(minimum: 0, maximum: 999999, ErrorMessage = "Valor deve ser maior que {0} e menor que {1}")]
        [Display(Description = "Kilometragem de saida")]
        public decimal KilometragemSaida => Carro.Kilometragem;

        [Required]
        [Precision(18, 2)]
        [Display(Description ="Kilometragem de chegada")]
        public decimal KilometragemChegada { get; set; }

        [Required]
        public byte[] FotoKilometragem { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Tamanho deve ser menor que 50 caracteres.")]

        public string Destino { get; set; }

        [Required]
        public virtual Pessoa Pessoa{ get; set; }

        [Required]
        [NotMapped]
        public virtual Carro Carro { get; set; }
    }
}
