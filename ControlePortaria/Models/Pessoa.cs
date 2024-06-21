using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePortaria.Models.Enums;
namespace ControlePortaria.Models
{
    [Table("Pessoa")]
    public class Pessoa

    {

        [Key]
        public int PessoaId { get; set; }

        [Required(ErrorMessage ="Nome é obrigatorio.")]
        [StringLength(50)]
        [Display(Name ="Nome")]
        public string PessoaNome { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(15)]
        [Phone]
        public string PessoaTelefone { get; set; }

        [Display(Name ="Status")]
        public PessoaStatus PessoaStatus { get; set; } = PessoaStatus.Ativado;
    }
}
