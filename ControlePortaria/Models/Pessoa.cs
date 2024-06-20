using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePortaria.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key]
        public int PessoaId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Nome")]
        public string PessoaNome { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(15)]
        [Phone]
        public string PessoaTelefone { get; set; }
    }
}
