using System.ComponentModel.DataAnnotations;

namespace TalentBankBackend.Models
{
    public class Vacancies
    {
        [Key]
        public int Id { get; set;}
        
        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public string NameVacancies { get; set; }

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public string Requirements { get; set;}

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public string Stack { get; set;}
        
        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public string Differentials { get; set;}
    }   
}