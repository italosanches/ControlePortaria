using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePortaria.Models.Enums;
namespace ControlePortaria.Models
{
    [Table("Pessoa")]
    public class Pessoa

    {
        public Pessoa()
        {
        }
        public Pessoa(string nome, string telefone, PessoaStatus status)
        {
            ValidarNome(nome);
            PessoaTelefone = telefone;
            PessoaStatus = status;
        }
        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentNullException("Nome no formato invalido, tente novamte.");
            }
            PessoaNome = nome;
        }

        [Key]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatorio.")]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string PessoaNome { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(15)]
        [Phone]
        public string PessoaTelefone { get; set; }

        [Display(Name = "Status")]
        public PessoaStatus PessoaStatus { get; set; }
    }
}
