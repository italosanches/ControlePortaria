using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePortaria.Models
{
    [Table("Carro")]
    public class Carro
    {
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

    }
}
