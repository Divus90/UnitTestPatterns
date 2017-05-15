using System.Collections.Generic;

namespace BaseProject.Vehicles
{
    public interface IVehicleService
    {
        IEnumerable<VehicleDto> GetVehicles();
        void SendVehicleData(VehicleDto vehicle);
    }
}