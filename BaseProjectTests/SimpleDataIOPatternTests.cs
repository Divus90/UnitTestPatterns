using BaseProject.People;
using NUnit.Framework;
using System.Linq;

namespace BaseProjectTests
{
    [TestFixture]
    public class SimpleDataIOPatternTests
    {
        private PeopleRepository _peopleRepository;
        private PeopleViewModel _sut;

        [SetUp]
        public void SetUp()
        {
            _peopleRepository = new PeopleRepository();
            var peopleService = new PeopleService(_peopleRepository);
            _sut = new PeopleViewModel(peopleService);
            _sut.GetPeople();
        }

        [TearDown]
        public void TearDown()
        {
            _peopleRepository.Rollback();
        }

        [Test]
        public void ShouldHaveNewPersonInDbAfterAddingOne()
        {
            // arrange
            var newPerson = new PersonDto("PName", "PSurnam", 30);

            // act
            _sut.People.Add(newPerson);
            _sut.SavePeople();

            // assert
            var actualPerson = _peopleRepository.GetAll().Single(p => p.Name == "PName");
            Assert.NotNull(actualPerson);
        }

        [Test]
        public void ShouldRemovePersonInDBAfterRemovingOne()
        {
            // arrange
            var personToDelete = _sut.People.First();

            // act
            _sut.People.Remove(personToDelete);
            _sut.SavePeople();

            // assert
            var actualPerson = _peopleRepository.GetAll().Single(p => p.Name == personToDelete.Name);
            Assert.IsNull(actualPerson);
        }
    }
}
