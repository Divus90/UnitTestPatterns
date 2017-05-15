using System.Collections.Generic;

namespace BaseProject.Vehicles
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleHttpFactory _vehicleHttpServiceFactory;

        public VehicleService(IVehicleHttpFactory vehicleHttpServiceFactory)
        {
            _vehicleHttpServiceFactory = vehicleHttpServiceFactory;
        }

        public IEnumerable<VehicleDto> GetVehicles()
        {
            return new List<VehicleDto>
            {
                new VehicleDto
                {
                    Model = "Audi A4"
                }
            };
        }

        public void SendVehicleData(VehicleDto vehicle)
        {
            var vehicleHttpService = _vehicleHttpServiceFactory.Create();
            vehicleHttpService.SendVehicleData();
        }
    }
}