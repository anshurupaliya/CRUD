using CRUD.DbContext;


namespace CRUD.ServiceContracts
{
    public interface IPersonDeleterService
    {
        public void RemovePerson(Person person);
    }
}
