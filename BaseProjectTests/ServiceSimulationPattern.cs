using BaseProject.Vehicles;
using NUnit.Framework;

namespace BaseProjectTests
{
    [TestFixture]
    public class ServiceSimulationPattern
    {
        private VehiclesViewModel _sut;
        private VehicleHttpServiceMock _vehicleHttpServiceMock;

        [SetUp]
        public void SetUp()
        {
            var vehicleHttpServiceFactory = new VehicleHttpMockFactory();
            _vehicleHttpServiceMock = vehicleHttpServiceFactory.VehicleServiceMock;
            _sut = new VehiclesViewModel(new VehicleService(vehicleHttpServiceFactory));
            _sut.GetVehicles();
        }

        [Test]
        public void VehicleHttpServiceHasBeenInvoked_WhenSendingVehicleData()
        {
            // arrange

            // act
            _sut.SendVehicles();

            // assert
            Assert.AreEqual(1, _vehicleHttpServiceMock.SendVehicleDataTimesCalled);
        }
    }

    public class VehicleHttpMockFactory : IVehicleHttpFactory
    {
        public VehicleHttpMockFactory()
        {
            VehicleServiceMock = new VehicleHttpServiceMock();
        }

        public IVehicleHttpService Create()
        {
            return VehicleServiceMock;
        }

        public VehicleHttpServiceMock VehicleServiceMock { get; }
    }

    public class VehicleHttpServiceMock : IVehicleHttpService
    {
        public void SendVehicleData()
        {
            SendVehicleDataTimesCalled++;
        }

        public int SendVehicleDataTimesCalled { get; set; }
    }
}
