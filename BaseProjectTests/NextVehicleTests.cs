using BaseProject.Vehicles;
using NUnit.Framework;

namespace BaseProjectTests
{
    [TestFixture]
    public class NextVehicleTests
    {
        private VehiclesViewModel _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new VehiclesViewModel(new VehicleService(new VehicleHttpMockFactory()));
        }

        [Test]
        public void should()
        {
            // arrange
            VehicleDto vehicle = null;

            // act
            _sut.GetDetailsOfVehicle(vehicle);

            // assert

        }
    }
}
