using System.ComponentModel.DataAnnotations;

namespace Universidade.Models
{
    public class Curso
    {
        [Key]
        public int CursoID { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Nome { get; set; }

        [MaxLength(1024, ErrorMessage = "Excede o limite de caracteres!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public int Semestres { get; set; }

        [Required (ErrorMessage = "Esse campo é obrigatório!")]
        [Range (1, int.MaxValue, ErrorMessage = "A mensalidade deve ser maior que R$ 0.00!")]
        public decimal Mensalidade { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "ID da Universidade inválido!")]
        public int InstituicaoeID { get; set; }

        public Instituicao Instituicao { get; set; }

    }
}
