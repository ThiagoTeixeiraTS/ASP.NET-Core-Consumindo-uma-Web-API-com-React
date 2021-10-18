using System.ComponentModel.DataAnnotations;

namespace AlunosApi.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80,ErrorMessage ="Erro Tamanho invalido!")]
        public string Nome { get; set; }
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Erro Tamanho Email Invalido!")]

        public string Email { get; set; }
        [Required]
        public int Idade { get; set; }
    }
}
