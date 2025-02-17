using CRUD.DbContext;
using CRUD.ServiceContracts;


namespace CRUD.Services
{
    public class PersonSetterService:IPersonSetterService
    {
        private readonly RepositoryContracts.IPersonRepositories _personRepository;

        public PersonSetterService(RepositoryContracts.IPersonRepositories db)
        {
            _personRepository = db;
            
        }

        

        public void AddPerson(Person person)
        {
            _personRepository.AddPerson(person);;
        }
        public void UpdatePerson(Person person)
        {
            _personRepository.UpdatePerson(person);
        }
    }
}
