using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FordonsReg
{
    class Motorcycle : IVehicle
    {
        //Class for MC's
        
        public double Speed { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public double setspeed(double userinput)
        {
            Speed = userinput;
            return Speed;
        }

        public Motorcycle(int c, string b)
        {
            Speed = c;
            Name = b;
        }


        public Motorcycle ()
        {
            Name = AllVehicleNames.NamingMethod(); // Get random name
            int rngnumb = new Random(DateTime.Now.Millisecond).Next(9, 99); // Set random speed
            Speed = rngnumb;
            Thread.Sleep(1);
        } 
        
        public static void Print(List<IVehicle> motorcyclesinstock)
        {
            Console.WriteLine($"You have  {motorcyclesinstock.Count()} Motorcykles in the list\n");
            foreach (var b in motorcyclesinstock)
            {
                Console.WriteLine($"Motorcykle {b.Name} \t{motorcyclesinstock.IndexOf(b)+1}: {b.Speed} km/h");
            }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} m/s", Name, Converter.PrintSpeedInMetersPerSecond(this));
        }
    }
}