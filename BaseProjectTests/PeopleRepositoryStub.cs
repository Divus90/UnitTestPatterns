using System.Collections.Generic;
using BaseProject.People;

namespace BaseProjectTests
{
    public class PeopleRepositoryStub : IPeopleRepository
    {
        public PeopleRepositoryStub()
        {
            People = new List<Person>
            {
                new Person
                {
                    Age = 10,
                    Name = "NewName",
                    Surname = "NewSurname"
                }
            };
        }

        public IList<Person> People { get; set; }

        public IEnumerable<Person> GetAll()
        {
            return People;
        }

        public void Save(List<PersonDto> people)
        {
            // do nothing
            // since this is stub object
            // it should not incorporate any logic
        }
    }
}