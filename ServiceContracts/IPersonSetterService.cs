using CRUD.DbContext;

namespace CRUD.ServiceContracts
{
    public interface IPersonSetterService
    {
        public void AddPerson(Person person);
        public void UpdatePerson(Person person);
    }
}
