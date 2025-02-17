using CRUD.DbContext;

namespace CRUD.RepositoryContracts
{
    public interface ICountryRepositories
    {
        Country AddCountry(Country country);
        List<Country> GetAllCountry();
        Country GetCountryById(Guid Id);
        Country GetCountryByName(string Name);

    }
}
