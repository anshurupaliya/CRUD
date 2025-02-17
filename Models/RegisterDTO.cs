using CRUD.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class RegisterDTO
    {
        [Required]
        public string PersonName {  get; set; }
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword {  get; set; }

        public UserTypeEnum UserType { get; set; }

    }
}
