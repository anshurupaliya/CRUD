using CRUD.DbContext;
using static CRUD.Services.PersonService;

namespace CRUD.ServiceContracts
{
    public interface IPersonService
    {
        public List<Person> GetPersons();
        public List<Person> GetFilteredPerson(string? key, string? value);
        public List<Person> GetSortedPerson(string? column, string sortBy);
        public void AddPerson(Person person);
        public void RemovePerson(Person person);
        public void UpdatePerson(Person person);
    }
}
