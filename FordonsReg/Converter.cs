using Parser;
using ReadAndSaveLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordonsReg
{
    class Converter
    {
        
        //Här konverterar vi mellan hastigheter och m/s
        public static void PrintSpeedInMetersPerSecond(List<IVehicle> car, List<IVehicle> boat, List<IVehicle> mc)
        {
            Console.WriteLine("\n\n-----------------------------------------------------------------------");
            foreach (var b in car)
            {
                Console.WriteLine($"Car {b.Name} \t\t{car.IndexOf(b) + 1}: {b.Speed * 0.44}  m/s");
            }
            Console.WriteLine("-----------------------------------------------------------------------");
            foreach (var b in boat)
            {
                Console.WriteLine($"Boat {b.Name} \t\t{boat.IndexOf(b) + 1}: {b.Speed * 0.51} m/s");
            }
            Console.WriteLine("-----------------------------------------------------------------------");
            foreach (var b in mc)
            {
                Console.WriteLine($"Mc {b.Name} \t\t{mc.IndexOf(b) + 1}: {b.Speed * 0.28} m/s");
            }
            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public static double PrintSpeedInMetersPerSecond(IVehicle vehicle)
        {
            if (vehicle is Car)
            {
                return (vehicle.Speed * 0.44);
            }
            else if (vehicle is Boat)
            {
                return (vehicle.Speed * 0.51);
            }
            else if (vehicle is Motorcycle)
            {
                return (vehicle.Speed * 0.28);
            }
            else
            {
                throw new Exception("No valid object!");
            }
        }
       

    }

}

