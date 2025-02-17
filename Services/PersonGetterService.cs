using CRUD.DbContext;
using CRUD.ServiceContracts;


namespace CRUD.Services
{
    public class PersonGetterService:IPersonGetterService
    {
        private readonly RepositoryContracts.IPersonRepositories _personRepository;

        public PersonGetterService(RepositoryContracts.IPersonRepositories db)
        {
            _personRepository = db;
            
        }

        public  List<Person> GetPersons()
        {
            return _personRepository.GetAllPerson();
        }

        public List<Person> GetFilteredPerson(string? key,string? value)
        {
            if(string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
            {
                return  GetPersons();
            }
            else
            {
                List<Person> filtered = GetPersons();
                switch (key)
                {
                    case "Id":
                        return _personRepository.GetFilteredPerson(index=>index.Id==Guid.Parse(value)).ToList();
                        break;
                    case "FirstName":
                        return _personRepository.GetFilteredPerson(index => index.FirstName == value).ToList();
                        break;
                    case "LastName":
                        return _personRepository.GetFilteredPerson(index => index.LastName == value).ToList();
                        break;
                    case "Email":
                        return _personRepository.GetFilteredPerson(index => index.Email == value).ToList();
                        break;
                    case "CountryObject":
                        return _personRepository.GetFilteredPerson((index) => index.CountryObject.Name == value).ToList();
                        break;
                    default:
                        return GetPersons();
                }
            }
        }

        public List<Person> GetSortedPerson(string? column,string sortBy)
        {
            if (string.IsNullOrEmpty(column))
            {
                return  GetPersons();
            }
            else
            {
                switch (column)
                {
                    case "Id":
                        if(sortBy == "ASC")
                        {
                            return GetPersons().OrderBy((index) => index.Id).ToList();
                        }
                        else
                        {
                            return  GetPersons().OrderByDescending((index) => index.Id).ToList();
                        }
                        break;
                    case "FirstName":
                        if (sortBy == "ASC")
                        {
                            return GetPersons().OrderBy((index) => index.FirstName).ToList();
                        }
                        else
                        {
                            return GetPersons().OrderByDescending((index) => index.FirstName).ToList();
                        }
                        break;
                    case "LastName":
                        if (sortBy == "ASC")
                        {
                            return GetPersons().OrderBy((index) => index.LastName).ToList();
                        }
                        else
                        {
                            return GetPersons().OrderByDescending((index) => index.LastName).ToList();
                        }
                        break;
                    case "Email":
                        if (sortBy == "ASC")
                        {
                            return GetPersons().OrderBy((index) => index.Email).ToList();
                        }
                        else
                        {
                            return GetPersons().OrderByDescending((index) => index.Email).ToList();
                        }
                        break;
                    case "CountryObject":
                        if (sortBy == "ASC")
                        {
                            return GetPersons().OrderBy((index) => index.CountryObject.Name).ToList();
                        }
                        else
                        {
                            return GetPersons().OrderByDescending((index) => index.CountryObject.Name).ToList();
                        }
                        break;
                    default:
                        return GetPersons();
                }
            }
        }
    }
}
