using CRUD.DbContext;
using System.Linq.Expressions;

namespace CRUD.RepositoryContracts
{
    public interface IPersonRepositories
    {
        Person AddPerson(Person person);
        List<Person> GetAllPerson();
        List<Person> GetFilteredPerson(Expression<Func<Person,bool>> predicate);
        bool DeletePersonById(Guid Id);
        Person GetPersonById(Guid Id);
        Person GetPersonByName(string Name);
        Person UpdatePerson(Person person);
    }
}
