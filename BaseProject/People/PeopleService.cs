using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseProject.People
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public List<PersonDto> GetAll()
        {
            return _peopleRepository.GetAll().Select(p => new PersonDto(p.Name, p.Surname, p.Age)).ToList();
        }

        public void Save(List<PersonDto> people)
        {
            _peopleRepository.Save(people);
        }
    }
}