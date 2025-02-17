using CRUD.Models.IdentityEntities;
using Microsoft.EntityFrameworkCore;


namespace CRUD.DbContext
{
    public class ApplicationDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Country> Country { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Person>()
            //.HasOne(p => p.CountryObject)
            //.WithMany() // You could specify the reverse navigation property in the Country class
            //.HasForeignKey(p => p.CountryId)
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Person>().ToTable("Person");
            List<Person> list = new List<Person>()
                {
                    new Person()
                    {
                        Id=Guid.Parse("83F7E22D-60FA-4695-9255-6FFE0F18E9C5"),FirstName="Anshu",LastName="Rupaliya",Email="anshurupaliya07@gmail.com",CountryId=Guid.Parse("BF9A4997-AEB5-4265-A49E-9902D46E8D8F")
                    },
                    new Person()
                    {
                        Id=Guid.Parse("BFEDC27E-E17D-4751-B3BE-0C43C95A625A"),FirstName="Pinal",LastName="Raghvani",Email="p07@gmail.com",CountryId=Guid.Parse("BF9A4997-AEB5-4265-A49E-9902D46E8D8F")
                    },
                    new Person()
                    {
                        Id=Guid.Parse("EC455B72-B4FB-4BE9-AFB7-A059ADC021B5"),FirstName="Vipul",LastName="Raghvani",Email="p07@gmail.com",CountryId=Guid.Parse("28F23AEE-A5D9-4F9B-B66C-78326A8ADE74")
                    },
                };
            foreach (var item in list)
            {
                modelBuilder.Entity<Person>().HasData(item);
            }

            List<Country> list2 = new List<Country>(){
                    new Country()
                    {
                        Id = Guid.Parse("BF9A4997-AEB5-4265-A49E-9902D46E8D8F"),
                        Name = "India"
                    },
                    new Country()
                    {
                        Id = Guid.Parse("D20C0E98-1719-4D9A-950A-EDC9D87D6E06"),
                        Name = "America"
                    },
                    new Country()
                    {
                        Id = Guid.Parse("28F23AEE-A5D9-4F9B-B66C-78326A8ADE74"),
                        Name = "Uk"
                    }
                };
            foreach (var item in list2)
            {
                modelBuilder.Entity<Country>().HasData(item);
            }
        }
    }
}
