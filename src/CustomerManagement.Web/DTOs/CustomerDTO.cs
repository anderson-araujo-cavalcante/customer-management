using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Web.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "O Email é obrigatório.")]
        public string Email { get; set; }

        [DisplayName("Data Nasc.")]
        [Required(ErrorMessage = "A Data de nacimento é obrigatório.")]
        public DateTime BirthDate { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public string Cep { get; set; }
    }
}
