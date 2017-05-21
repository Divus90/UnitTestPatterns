using BaseProject.Vehicles;
using NUnit.Framework;

namespace BaseProjectTests
{
    [TestFixture]
    public class TemplateMethodTests
    {
        private VehiclesViewModel _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new VehiclesViewModel(new VehicleService(new VehicleHttpMockFactory()));
        }

        [Test]
        public void should_return_null_for_null_object()
        {
            // arrange
            VehicleDto vehicle = null;

            // act
            var expected = _sut.GetDetailsOfVehicle(vehicle);

            // assert
            Assert.IsNull(expected);
        }

        [Test]
        public void should_have_boat_details_for_boat()
        {
            var vehicleType = VehicleType.Boat;
            var expectedDetails = new VehicleDetails
            {
                CanFly = false,
                CanSwim = true,
                WheelCount = 0
            };
            AssertMethodReturnExpectedObjectForType(vehicleType, expectedDetails);
        }
        
        [Test]
        public void should_have_car_details_for_car()
        {
            var vehicleType = VehicleType.Car;
            var expectedDetails = new VehicleDetails
            {
                CanFly = false,
                CanSwim = false,
                WheelCount = 4
            };
            AssertMethodReturnExpectedObjectForType(vehicleType, expectedDetails);
        }

        [Test]
        public void should_have_motorcycle_detailt_for_motorcycle()
        {
            var vehicleType = VehicleType.Motorcycle;
            var expectedDetails = new VehicleDetails
            {
                CanFly = false,
                CanSwim = false,
                WheelCount = 2
            };
            AssertMethodReturnExpectedObjectForType(vehicleType, expectedDetails);
        }

        private void AssertMethodReturnExpectedObjectForType(VehicleType vehicleType, VehicleDetails expected)
        {
            // arrange
            var vehicle = new VehicleDto
            {
                VehicleType = vehicleType
            };

            // act
            var actual = _sut.GetDetailsOfVehicle(vehicle);

            // assert
            Assert.AreEqual(actual.CanFly, expected.CanFly);
            Assert.AreEqual(actual.CanSwim, expected.CanSwim);
            Assert.AreEqual(actual.WheelCount, expected.WheelCount);
        }
    }
}
