using System;
using System.Collections.Generic;

namespace BaseProject.People
{
    public class PeopleViewModel
    {
        private readonly IPeopleService _peopleService;

        public PeopleViewModel(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public List<PersonDto> People { get; set; }

        public void GetPeople()
        {
            People = _peopleService.GetAll();
        }

        public void SavePeople()
        {
            _peopleService.Save(People);
        }
    }
}