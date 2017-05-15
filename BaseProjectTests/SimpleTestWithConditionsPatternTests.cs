using BaseProject.People;
using NUnit.Framework;
using System.Linq;

namespace BaseProjectTests
{
    [TestFixture]
    public class SimpleTestWithConditionsPatternTests
    {
        private PeopleRepositoryStub _peopleRepository;
        private PeopleViewModel _sut;

        [SetUp]
        public void SetUp()
        {
            _peopleRepository = new PeopleRepositoryStub();
            var peopleService = new PeopleService(_peopleRepository);
            _sut = new PeopleViewModel(peopleService);
        }

        [Test]
        public void ShouldHavePeopleAfterCallingGetAll()
        {
            // arrange

            // act
            _sut.GetPeople();

            // assert
            Assert.IsNotEmpty(_sut.People);
        }

        [Test]
        public void ShouldHaveManyPeopleAfterCallingGetAll_WhenDBHasManyPeople()
        {
            // arrange
            _peopleRepository.People.Add(new Person
            {
                Age = 25,
                Name = "NextName",
                Surname = "NextSurname"
            });

            // act
            _sut.GetPeople();

            // assert
            Assert.AreEqual(2, _sut.People.Count);
        }

        [Test]
        public void ShouldHaveProperPersonFromDatabase()
        {
            // arrange
            var expectedPerson = _peopleRepository.People.OrderBy(p => p.Age).First();

            // act
            _sut.GetPeople();

            // assert
            var actualPerson = _sut.People.OrderBy(p => p.Age).First();
            AssertPeoplaAreSame(expectedPerson, actualPerson);
        }

        private void AssertPeoplaAreSame(Person expectedPerson, PersonDto actualPerson)
        {
            Assert.AreEqual(expectedPerson.Age, actualPerson.Age);
            Assert.AreEqual(expectedPerson.Name, actualPerson.Name);
            Assert.AreEqual(expectedPerson.Surname, actualPerson.Surname);
        }
    }
}
