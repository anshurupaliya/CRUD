using CRUD.DbContext;
using CRUD.ServiceContracts;


namespace CRUD.Services
{
    public class PersonDeleterService:IPersonDeleterService
    {
        private readonly RepositoryContracts.IPersonRepositories _personRepository;

        public PersonDeleterService(RepositoryContracts.IPersonRepositories db)
        {
            _personRepository = db;
            
        }

        public void RemovePerson(Person person)
        {
            _personRepository.DeletePersonById(person.Id);
        }
    }
}
