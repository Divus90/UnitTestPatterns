using System.Collections.Generic;

namespace BaseProject.People
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetAll();
        void Save(List<PersonDto> people);
    }
}