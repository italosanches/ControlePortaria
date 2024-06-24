using ControlePortaria.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ControlePortaria.ViewModel
{
    public class PortariaViewModel
    {
        public IEnumerable<Pessoa> PessoaAtivas { get; set; } 
        public IEnumerable<Carro> CarrosAtivos { get; set; }

        [Required(ErrorMessage ="Pessoa é obrigatorio.")]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Carro é obrigatorio.")]
        public int CarroId { get; set; }

        [Required]
        [Display(Name = "Data e horario de saida.")]
        public DateTime HorarioSaida { get; set; }

        [Display(Name = "Data e horario de chegada.")]
        public DateTime HorarioChegada { get; set; }

        [Required]
        [Precision(18, 2)]
        [Display(Description = "Kilometragem de saida")]
        public decimal KilometragemSaida { get; }

        [Precision(18, 2)]
        [Range(minimum: 0, maximum: 999999, ErrorMessage = "Valor deve ser maior que {1} e menor que {2}")]
        [Display(Description = "Kilometragem de chegada")]
        public decimal KilometragemChegada { get; set; }

        //[Required]
        public byte[] FotoKilometragem { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Tamanho deve ser menor que 50 caracteres.")]
        public string Destino { get; set; }

    }
}
