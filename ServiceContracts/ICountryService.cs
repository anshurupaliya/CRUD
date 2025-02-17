using CRUD.DbContext;

namespace CRUD.ServiceContracts
{
    public interface ICountryService
    {
        List<Country> GetAll();
        Country Add(Country country);
    }
}
