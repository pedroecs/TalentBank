using System.ComponentModel.DataAnnotations;

namespace TalentBankBackend.Models
{
    public class Candidates
    {
        [Key]
        public int Id { get; set;}
        [Required(ErrorMessage = "Este campo é Obrigatório")]
        [MaxLength(60, ErrorMessage = "Esse campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Esse campo deve conter entre 3 e 60 caracteres")]
        public string Name { get; set;}

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public string Stack { get; set;}

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public string Skill {get; set;}
        public string Graduated { get; set;}

        public string Experience { get; set;}

    }   
}