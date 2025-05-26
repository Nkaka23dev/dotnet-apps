using CoreWCF;
using HelloSoapService.Models;

namespace HelloSoapService.Services;

[ServiceBehavior]
public class PersonService : IPerson
{
   private static readonly List<Person> _people = new()
        {
            new Person { Id = 1, Name = "Alice", Age = 30 },
            new Person { Id = 2, Name = "Bob", Age = 25 }
        };

    private static int _nextId = 3;

        public List<Person> GetAll() => _people;

        public Person? GetById(int id) => _people.FirstOrDefault(p => p.Id == id);

        public Person Add(Person person)
        {
            person.Id = _nextId++;
            _people.Add(person);
            return person;
        }

        public Person? Update(int id, Person person)
        {
            var existing = _people.FirstOrDefault(p => p.Id == id);
            if (existing == null) return null;

            existing.Name = person.Name;
            existing.Age = person.Age;
            return existing;
        }

        public bool Delete(int id)
        {
            var existing = _people.FirstOrDefault(p => p.Id == id);
            if (existing == null) return false;

            _people.Remove(existing);
            return true;
        }
}