using CRUD.DbContext;

namespace CRUD.ServiceContracts
{
    public interface IPersonGetterService
    {
        public List<Person> GetPersons();
        public List<Person> GetFilteredPerson(string? key, string? value);
        public List<Person> GetSortedPerson(string? column, string sortBy);
       
    }
}
