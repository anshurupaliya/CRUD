using System.ComponentModel.DataAnnotations;

namespace CRUD.DbContext
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> Person { get;set; }
    }
}
