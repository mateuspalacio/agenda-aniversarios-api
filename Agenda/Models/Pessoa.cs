using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Agenda.Models
{
    public class Pessoa
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "O nome não pode ser vazio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O dia do nascimento não pode ser vazio.")]
        [Range(1,31, ErrorMessage = "O dia de nascimento deve estar entre 1 e 31.")]
        public int DiaNascimento { get; set; }
        [Required(ErrorMessage = "O mês não pode ser vazio.")]
        [Range(1,12, ErrorMessage = "O mês de nascimento deve estar entre 1 e 12.")]
        public int MesNascimento { get; set; }
    }
}
