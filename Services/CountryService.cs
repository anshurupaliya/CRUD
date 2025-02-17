using CRUD.DbContext;
using CRUD.RepositoryContracts;
using CRUD.ServiceContracts;
using System.Collections.Generic;

namespace CRUD.Services
{
    public class CountryService:ICountryService
    {
        private readonly ICountryRepositories _countryRepository;
        public CountryService(ICountryRepositories countryRepositories)
        {
            _countryRepository= countryRepositories;
        }

        public List<Country> GetAll()
        {
            return _countryRepository.GetAllCountry();
        }
        public Country Add(Country country)
        {
           return _countryRepository.AddCountry(country);
        }
    }
}
