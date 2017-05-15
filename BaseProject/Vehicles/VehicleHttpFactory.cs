namespace BaseProject.Vehicles
{
    public class VehicleHttpFactory : IVehicleHttpFactory
    {
        public IVehicleHttpService Create()
        {
            return new VehicleHttpService();
        }
    }
}