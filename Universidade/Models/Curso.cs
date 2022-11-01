using System.ComponentModel.DataAnnotations;

namespace Universidade.Models
{
    public class Curso
    {
        [Key]
        public int CursoID { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public int Semestres { get; set; }

    }
}
