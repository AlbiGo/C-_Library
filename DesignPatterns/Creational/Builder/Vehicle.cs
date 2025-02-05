//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DesignPatterns.Creational.Builder
//{
//    public class Vehicle
//    {
//        private int _vehicleType;
//        private List<VehiclePart> vehicleParts = new List<VehiclePart>();

//        public Vehicle(int VehicleType)
//        {
//            _vehicleType = VehicleType;
//            vehicleParts.Add(new VehiclePart()
//            {
//                Id = 1,
//                Name = ((VehiclePartType)1).ToString()
//            });
//            vehicleParts.Add(new VehiclePart()
//            {
//                Id = 2,
//                Name = ((VehiclePartType)2).ToString()
//            });
//            vehicleParts.Add(new VehiclePart()
//            {
//                Id = 3,
//                Name = ((VehiclePartType)3).ToString()
//            });
//            vehicleParts.Add(new VehiclePart()
//            {
//                Id = 4,
//                Name = ((VehiclePartType)4).ToString()
//            });
//        }

//        public VehiclePart this[int index]
//        {
//            get { return vehicleParts.Where(p => p.Id == index).FirstOrDefault(); }
//            set 
//            {
//                vehicleParts.Where(p => p.Id == index).FirstOrDefault().Name = value.Name; 
//            }
//        }

//        public void Show()
//        {
//            Console.WriteLine("\n---------------------------");
//            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
//            Console.WriteLine(" Frame : {0}", vehicleParts[0].Name);
//            Console.WriteLine(" Engine : {0}", vehicleParts[1].Name);
//            Console.WriteLine(" #Wheels: {0}", vehicleParts[2].Name);
//            Console.WriteLine(" #Doors : {0}", vehicleParts[3].Name);
//        }
//    }

//    public abstract class VehicleBuilder
//    {
//        protected Vehicle vehicle;
//        // Gets vehicle instance
//        public Vehicle Vehicle
//        {
//            get { return vehicle; }
//        }
//        // Abstract build methods
      
//        public virtual void BuildFrame()
//        {
//            vehicle[1].Name = "Frame";
//        }
//        public virtual void BuildEngine()
//        {
//            vehicle[2].Name = "cc";
//        }
//        public virtual void BuildWheels()
//        {
//            vehicle[3].Name = "0";
//        }
//        public virtual void BuildDoors()
//        {
//            vehicle[4].Name = "0";
//        }
//    }

//    public class Shop
//    {
//        // Builder uses a complex series of steps
//        public void Construct(VehicleBuilder vehicleBuilder)
//        {
//            vehicleBuilder.BuildFrame();
//            vehicleBuilder.BuildEngine();
//            vehicleBuilder.BuildWheels();
//            vehicleBuilder.BuildDoors();
//        }
//    }

//    public class MotorCycleBuilder : VehicleBuilder
//    {
//        public MotorCycleBuilder()
//        {
//            vehicle = new Vehicle((int)VehicleType.Bike);
//        }
//        public override void BuildFrame()
//        {
//            vehicle[1].Name = "MotorCycle Frame";
//        }
//        public override void BuildEngine()
//        {
//            vehicle[2].Name = "500 cc";
//        }
//        public override void BuildWheels()
//        {
//            vehicle[3].Name = "2";
//        }
//        public override void BuildDoors()
//        {
//            vehicle[4].Name = "0";
//        }
//    }


//    public class VehiclePart
//    {
//        public int Id { get; set; } 
//        public string Name { get; set; }
//    }

//    public enum VehiclePartType
//    {
//        frame = 1,
//        engine = 2,
//        wheels = 3,
//        doors = 4,
//    }


//    public enum VehicleType
//    {
//        None = 1,
//        Car = 2,
//        Scooter = 3,
//        Bike = 4,
//    }

//}
