using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseProject.People
{
    public class PeopleRepository : IPeopleRepository
    {
        public PeopleRepository()
        {
            People = BuildBaseList();
        }

        public List<Person> People { get; set; }

        public IEnumerable<Person> GetAll()
        {
            return People;
        }

        public void Save(List<PersonDto> people)
        {
            People = people.Select(p => new Person
            {
                Age = p.Age,
                Name = p.Name,
                Surname = p.Surname
            }).ToList();
        }

        private static List<Person> BuildBaseList()
        {
            return new List<Person>
            {
                new Person
                {
                    Age = 10,
                    Name = "Mark",
                    Surname = "Pornant"
                },
                new Person
                {
                    Age = 50,
                    Name = "Elizabeth",
                    Surname = "Contry"
                },
                new Person
                {
                    Age = 28,
                    Name = "Salmon",
                    Surname = "Pewder"
                },
                new Person
                {
                    Age = 35,
                    Name = "Mathew",
                    Surname = "Link"
                },
            };
        }

        public void Rollback()
        {
            People = BuildBaseList();
        }

    }
}