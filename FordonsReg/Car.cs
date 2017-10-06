using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FordonsReg
{
    class Car : IVehicle
    {
        //Class for cars

        public double Speed { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public double setspeed(double userinput)
        {
            Speed = userinput;
            return Speed;
        }

        public Car()
        {
            Name = AllVehicleNames.NamingMethod(); // Get random name

            int rngnumb = new Random(DateTime.Now.Millisecond).Next(9, 99); // Set random speed
            Speed = rngnumb;
            Thread.Sleep(1);
        }

        public static void Print(List<IVehicle> carsinstock)
        {
            Console.WriteLine($"You have {carsinstock.Count()} Cars in the list\n");
            foreach (var b in carsinstock)
            {
                Console.WriteLine($"Car {b.Name} \t{carsinstock.IndexOf(b) + 1} :  {b.Speed} Mph");
            }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}  m/s", Name, Converter.PrintSpeedInMetersPerSecond(this));
        }
        

    }
}
