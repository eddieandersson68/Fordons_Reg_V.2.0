using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FordonsReg
{
    class Boat : IVehicle
    {
        //Class for boats

        public double Speed { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public double setspeed(double userinput)
        {
            Speed = userinput;
            return Speed;
        }

        public Boat(int c, string b)
        {
            Speed = c;
            Name = b;
        }


        public Boat()
        {
            Name = AllVehicleNames.NamingMethod(); // Get random name

            int rngnumb = new Random(DateTime.Now.Millisecond).Next(9, 99); // Set random speed
            Speed = rngnumb;
            Thread.Sleep(1);
        }      
       
        public static void Print(List<IVehicle> boatsinstock)
        {
            Console.WriteLine($"You have {boatsinstock.Count()} Boats in the list\n");
            foreach (var b in boatsinstock)
            {
                Console.WriteLine($"Boat {b.Name} \t{boatsinstock.IndexOf(b)+ 1}: {b.Speed} knots");
            }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} m/s", Name, Converter.PrintSpeedInMetersPerSecond(this));
        }
    }
}
