using CoreWCF;
using HelloSoapService.Models;

namespace HelloSoapService.Services;

[ServiceContract]
public interface IPerson
{
    [OperationContract]
    List<Person> GetAll();

    [OperationContract]
    Person? GetById(int id);

    [OperationContract]
    Person Add(Person person);

    [OperationContract]
    Person? Update(int id, Person person);

    [OperationContract]
    bool Delete(int id);
}
