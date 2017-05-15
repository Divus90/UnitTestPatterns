using System.Collections.Generic;

namespace BaseProject.People
{
    public interface IPeopleService
    {
        List<PersonDto> GetAll();
        void Save(List<PersonDto> people);
    }
}