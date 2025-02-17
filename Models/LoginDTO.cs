using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
