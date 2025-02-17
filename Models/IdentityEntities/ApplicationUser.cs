using Microsoft.AspNetCore.Identity;

namespace CRUD.Models.IdentityEntities
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string? PersonName {  get; set; }
    }
}
