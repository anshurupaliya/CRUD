using CRUD.DbContext;
using CRUD.RepositoryContracts;
//using Fluent.Infrastructure.FluentModel;

namespace CRUD.Repositories
{

    public class CountryRepository : RepositoryContracts.ICountryRepositories
    {
        private readonly ApplicationDbContext _db;

        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Country AddCountry(Country country)
        {
            _db.Country.Add(country);
            _db.SaveChanges();
            return country;
        }

        public List<Country> GetAllCountry()
        {
            return _db.Country.ToList();
        }

        public Country GetCountryById(Guid Id)
        {
            return _db.Country.FirstOrDefault(index => index.Id == Id);
        }

        public Country GetCountryByName(string Name)
        {
            return _db.Country.FirstOrDefault(index => index.Name == Name);
        }
    }
}
