using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordonsReg
{
    public class AllVehicleNames
    {
        static Random rnd = new Random(DateTime.Now.Millisecond);

        public static string NamingMethod()
        {
            List<String> VehicleNames = new List<string>();

            VehicleNames.Add("Peter");
            VehicleNames.Add("Thaddy");
            VehicleNames.Add("Johnny");
            VehicleNames.Add("Iskar");
            VehicleNames.Add("Matte");
            VehicleNames.Add("Tomas");
            VehicleNames.Add("Jakob");
            VehicleNames.Add("Anders");
            VehicleNames.Add("Filip");
            VehicleNames.Add("John");
            VehicleNames.Add("Simon");
            VehicleNames.Add("Bart");
            
            string Name = VehicleNames[rnd.Next(0, VehicleNames.Count)];
            return Name;
            
        }
        
        public static void PrintQuary(List<IVehicle> quary)
        {
            {
                Console.WriteLine($"You have {quary.Count()} Cars in the list\n");
                foreach (var b in quary)
                {
                    Console.WriteLine($"Car {b.Name} \t{quary.IndexOf(b) + 1} :  {b.Speed} Mph");
                }
            }
        }

    }
}
