using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseProject.Vehicles
{
    public class VehiclesViewModel
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesViewModel(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IEnumerable<VehicleDto> Vehicles { get; set; }

        public void GetVehicles()
        {
            Vehicles = _vehicleService.GetVehicles();
        }

        public VehicleDetails GetDetailsOfVehicle(VehicleDto vehicle)
        {
            var vehicleDetailProvider = new VehicleDetailProvidersFactory().Create(vehicle);
            return vehicleDetailProvider.Get();
        }

        public void SendVehicles()
        {
            _vehicleService.SendVehicleData(Vehicles.FirstOrDefault());
        }
    }
}
