using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Universidade.Models
{
    public class Instituicao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required (ErrorMessage = "Esse campo é obrigatório!")]
        public string Nome { get; set; }

        [MaxLength(2, ErrorMessage = "Esse campo deve conter 2 caracteres")]
        [MinLength(2, ErrorMessage = "Esse campo deve conter 2 caracteres")]
        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Cidade { get; set; }
             
    }
}
