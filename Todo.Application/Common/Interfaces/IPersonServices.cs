using Todo.Domain;

namespace Todo.Application.Common.Interfaces;

public interface IPersonServices
{
    Task<IEnumerable<Person>> GetPersonListAsync(CancellationToken cancellationToken);
    Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken);
    Task<Person> AddPersonAsync(Person person, CancellationToken cancellationToken);
    Task<Person> UpdatePersonAsync(int id, Person person, CancellationToken cancellationToken);
}
