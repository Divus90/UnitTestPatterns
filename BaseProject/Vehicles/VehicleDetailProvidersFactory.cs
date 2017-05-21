namespace BaseProject.Vehicles
{
    public class VehicleDetailProvidersFactory
    {
        public IVehicleDetailsProvider Create(VehicleDto vehicle)
        {
            if (vehicle == null)
            {
                return new NullDetailsProvider();
            }
            switch (vehicle.VehicleType)
            {
                case VehicleType.Boat:
                    return new BoatDetailsProvider();
                case VehicleType.Car:
                    return new CarDetailsProvider();
                case VehicleType.Motorcycle:
                    return new MotorcycleDetailsProvider();
                default:
                    return new NullDetailsProvider();
            }
        }
    }

    public class BoatDetailsProvider : IVehicleDetailsProvider
    {
        public VehicleDetails Get()
        {
            return new VehicleDetails
            {
                CanFly = false,
                CanSwim = true,
                WheelCount = 0
            };
        }
    }

    public class MotorcycleDetailsProvider : IVehicleDetailsProvider
    {
        public VehicleDetails Get()
        {
            return new VehicleDetails
            {
                CanFly = false,
                CanSwim = false,
                WheelCount = 2
            };
        }
    }

    public class CarDetailsProvider : IVehicleDetailsProvider
    {
        public VehicleDetails Get()
        {
            return new VehicleDetails
            {
                CanFly = false,
                CanSwim = false,
                WheelCount = 4
            };
        }
    }

    public class NullDetailsProvider : IVehicleDetailsProvider
    {
        public VehicleDetails Get()
        {
            return null;
        }
    }

    public interface IVehicleDetailsProvider
    {
        VehicleDetails Get();
    }
}