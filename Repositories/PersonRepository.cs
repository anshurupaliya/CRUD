using CRUD.DbContext;
using CRUD.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace CRUD.Repositories
{
    public class PersonRepository : RepositoryContracts.IPersonRepositories
    {
        private readonly DbContext.ApplicationDbContext _db;
        public PersonRepository(DbContext.ApplicationDbContext db)
        {
            _db = db;
        }
        public Person AddPerson(Person person)
        {
            _db.Person.Add(person);
            _db.SaveChanges();
            return person;
        }

        public bool DeletePersonById(Guid Id)
        {
            IEnumerable<Person> person = _db.Person.Where(x => x.Id == Id);
            _db.Person.RemoveRange(person);
            return _db.SaveChanges() > 0 ? true : false;
        }

        public List<Person> GetAllPerson()
        {
            return _db.Person.Include("CountryObject").ToList();
        }

        public List<Person> GetFilteredPerson(Expression<Func<Person, bool>> predicate)
        {
            return _db.Person.Include("CountryObject").Where(predicate).ToList();
        }

        public Person GetPersonById(Guid Id)
        {
            return _db.Person.FirstOrDefault(e => e.Id == Id);
        }

        public Person GetPersonByName(string Name)
        {
            return _db.Person.FirstOrDefault(e => e.FirstName == Name);
        }

        public Person UpdatePerson(Person person)
        {
            Person p = _db.Person.FirstOrDefault(index => index.Id == person.Id);
            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            p.Email = person.Email;
            p.CountryId = person.CountryId;
            p.CountryId = person.CountryId;
            _db.SaveChanges();
            return p;
        }
    }
}
