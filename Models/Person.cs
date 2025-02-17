using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DbContext
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public Guid? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country CountryObject { get; set; }
    }
}
