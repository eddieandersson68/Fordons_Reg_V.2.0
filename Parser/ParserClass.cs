using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class ParserClass
    {
        public List<string> Vehicles (List<string> VehicleList)
        {
            List<string> Vehiclesprint = new List<string>();

            foreach ( var item in VehicleList)
            {
                var itemsplit = item.Split(':').ToList();
                Vehiclesprint.AddRange(itemsplit);
            }
            //Console.WriteLine(Vehiclesprint.ToString());
            return Vehiclesprint;

        }
    }
}
