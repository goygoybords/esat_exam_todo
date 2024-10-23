using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;
using Todo.Domain;

namespace Todo.Application.Common.Services;

public class PersonServices(ITodoContext todoContext) : IPersonServices
{
    private readonly ITodoContext _todoContext = todoContext;

    public async Task<IEnumerable<Person>> GetPersonListAsync(CancellationToken cancellationToken)
    {
        return await _todoContext.Persons
        .Select(person => new Person
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            MiddleName = person.MiddleName,
            DateOfBirth = person.DateOfBirth
        })
        .ToListAsync(cancellationToken);
    }

    public async Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken)
    {
        var person = await _todoContext.Persons
            .AsNoTracking()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (person == null)
            throw new KeyNotFoundException($"Person with Id {id} not found.");

        return person;
    }

    public async Task<Person> AddPersonAsync(Person person, CancellationToken cancellationToken)
    {
        if (person == null)
            throw new ArgumentNullException(nameof(person), "Person cannot be null.");
        
        _todoContext.Persons.Add(person);

        await _todoContext.SaveChangesAsync(cancellationToken);

        return person;
    }

    public async Task<Person> UpdatePersonAsync(int id, Person person, CancellationToken cancellationToken)
    {
        if (person == null)
            throw new ArgumentNullException(nameof(person), "Person cannot be null.");

        var existingPerson = await _todoContext.Persons.Where(o => o.Id == id).FirstOrDefaultAsync(cancellationToken);
        if (existingPerson == null)
           throw new ArgumentNullException("existing Person cannot be null.");

        existingPerson.FirstName = person.FirstName;
        existingPerson.LastName = person.LastName;
        existingPerson.MiddleName = person.MiddleName;
        existingPerson.DateOfBirth = person.DateOfBirth;

        await _todoContext.SaveChangesAsync(cancellationToken);
        return person;
    }
}