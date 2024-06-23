using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePortaria.Models.Enums;

namespace ControlePortaria.Models
{
    [Table("Carro")]
    public class Carro
    {
        public Carro()
        {
            
        }
        public Carro(int carroID, string carroPlaca, string carroModelo, int kilometragem, Fabricante fabricante)
        {
            CarroPlaca = carroPlaca;
            CarroModelo = carroModelo;
            Kilometragem = kilometragem;
            CarroDisponivel = true;
            Fabricante = fabricante;
        }
        public int CarroID { get; set; }

        [Required(ErrorMessage ="Placa é obrigatoria")]
        [StringLength(10)]
        public string CarroPlaca {  get; set; }

        [Required(ErrorMessage = "Modelo é obrigatoria")]
        [StringLength(10)]
        public string CarroModelo {  get; set; }

        [Required]
        public int Kilometragem { get; set; } = 0;

        public bool CarroDisponivel { get; set; } = true;

        [Required(ErrorMessage = "Fabricante é obrigatorio")]
        public Fabricante Fabricante { get; set; }

        private void VerificarDados<T>(T obj)
        {
            if (obj == null) throw new ArgumentNullException("Objeto nulo");
            if(typeof(T) == typeof(string)) 
            {
                string textValidation = obj.ToString();
                var nameof1 = nameof(obj);
                if(string.IsNullOrEmpty(textValidation)) 
                    throw new ArgumentNullException($" {nameof1} esta nulo");
                    
            };
        }
        

    }
}
