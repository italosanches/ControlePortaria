using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePortaria.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ControlePortaria.Models
{
    [Table("Carro")]
    public class Carro
    {
        public Carro()
        {
            
        }
        public Carro(string carroPlaca, string carroModelo, decimal Carrokilometragem, Fabricante fabricante)
        {
            CarroPlaca = VerificarPlaca(carroPlaca);
            CarroModelo = VerificarModelo(carroModelo);
            CarroKilometragem = VerificarKM(Carrokilometragem);
            CarroDisponivel = true;
            Fabricante = fabricante;
        }
        public int CarroID { get; set; }

        [Display(Name ="Placa")]
        [Required(ErrorMessage ="Placa é obrigatoria.")]
        [StringLength(10)]
        public string CarroPlaca {  get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Modelo é obrigatorio.")]
        [StringLength(10)]
        public string CarroModelo {  get; set; }

 
        [Required(ErrorMessage = "Kilometragem é obrigatoria.")]
        [Precision(18, 2)]
        [Range(minimum: 0, maximum: 999999, ErrorMessage = "Valor deve ser maior que {1} e menor que {2}")]
        [Display(Name = "Kilometragem atual")]
        public decimal CarroKilometragem { get; set; }

        public bool CarroDisponivel { get; set; } = true;

        [Required(ErrorMessage = "Fabricante é obrigatorio")]
        public Fabricante Fabricante { get; set; }

        private string VerificarPlaca(string placa)
        {
            if (string.IsNullOrEmpty(placa)) { throw new ArgumentNullException("Placa não pode ser vazia."); }
            return placa.Trim().ToUpper();
        }
        private string VerificarModelo(string modelo)
        {
            if (string.IsNullOrEmpty(modelo)) { throw new ArgumentNullException("Placa não pode ser vazia."); }
            return modelo.ToUpper();
        }

        private decimal VerificarKM(decimal km)
        {
            if(km < 0){ throw new ArgumentException("Kilometragem incorreta, nao pode ser negativo."); }
            return km;
        }




    }
}
