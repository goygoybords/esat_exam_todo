using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;
using Todo.Domain;

namespace Todo.Application.Common.Services;

public class PersonServices(ITodoContext todoContext) : IPersonServices
{
    private readonly ITodoContext _todoContext = todoContext;

    public async Task<IEnumerable<Person>> GetPersonListAsync(CancellationToken cancellationToken)
    {
        var persons = await _todoContext.Persons.ToListAsync(cancellationToken);

        return persons;
    }

    public async Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken)
    {
        var person = await _todoContext.Persons.Where(o => o.Id == id).FirstOrDefaultAsync(cancellationToken);

        return person;
    }

    public async Task<Person> AddPersonAsync(Person person, CancellationToken cancellationToken)
    {
        _todoContext.Persons.Add(person);

        await _todoContext.SaveChangesAsync(cancellationToken);

        return person;
    }

    public async Task<Person> UpdatePersonAsync(int id, Person person, CancellationToken cancellationToken)
    {
        var existingPerson = await _todoContext.Persons.Where(o => o.Id == id).FirstOrDefaultAsync(cancellationToken);
        if (existingPerson == null)
        {
            return null;
        }

        existingPerson.FirstName = person.FirstName;
        existingPerson.LastName = person.LastName;
        existingPerson.MiddleName = person.MiddleName;
        existingPerson.DateOfBirth = person.DateOfBirth;

        await _todoContext.SaveChangesAsync(cancellationToken);
        return person;
    }
}