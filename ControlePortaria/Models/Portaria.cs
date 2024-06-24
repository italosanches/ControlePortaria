using ControlePortaria.Repository;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePortaria.Models
{
    public class Portaria
    {
        public Portaria()
        {
            
        }
        public Portaria(int pessoaId,int carroId,DateTime horaSaida,string destino)
        {
            PessoaID = pessoaId;
            CarroID = carroId;
            HorarioSaida = horaSaida;
            Destino = destino;
        }

        [Key]
        public int PortariaID { get; set; }
        [Required]
        public int PessoaID { get; set; }
        [Required]
        public int CarroID { get; set; }

        [Required]
        [Display(Name ="Data e horario de saida.")]
        public DateTime HorarioSaida { get; set; }

        [Display(Name = "Data e horario de chegada.")]
        public DateTime HorarioChegada { get; set; }

        [Required]
        [Precision(18, 2)]
        [Range(minimum: 0, maximum: 999999, ErrorMessage = "Valor deve ser maior que {1} e menor que {2}")]
        [Display(Description = "Kilometragem de saida")]
        public decimal KilometragemSaida => Carro.CarroKilometragem;
        
        [Precision(18, 2)]
        [Range(minimum: 0, maximum: 999999, ErrorMessage = "Valor deve ser maior que {1} e menor que {2}")]
        [Display(Description ="Kilometragem de chegada")]
        public decimal KilometragemChegada { get; set; }

        //[Required]
        public byte[] FotoKilometragem { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Tamanho deve ser menor que 50 caracteres.")]
        public string Destino { get; set; }

        [Required]
        public virtual Pessoa Pessoa{ get; set; }

        [Required]
        public virtual Carro Carro { get; set; }
    }
}
