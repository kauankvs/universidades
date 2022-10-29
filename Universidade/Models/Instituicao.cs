using System.ComponentModel.DataAnnotations;

namespace Universidade.Models
{
    public class Instituicao
    {
        [Key]
        public int ID { get; set; }

        [Required (ErrorMessage = "Esse campo é obrigatório!")]
        public string Nome { get; set; }

        [MaxLength(2, ErrorMessage = "Esse campo deve conter 2 caracteres")]
        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Cidade { get; set; }
       
        public ICollection<Curso> Cursos { get; set; }
    }
}
