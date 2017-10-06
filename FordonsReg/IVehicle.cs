using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordonsReg
{
    public interface IVehicle
    {
        //Kontrakt för klasserna


        //Kontrakt för klasserna
        double Speed { get; set; }
        double setspeed(double userinput);
        string Type { get; set; }
        string Name { get; set; }
       
    }
}
