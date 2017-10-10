using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndSaveLib
{
    public class ReadAndSaveHandler
    {
        public List<string> Load()
        {
            List<string> Loadddata = new List<string>();
            StreamReader infile = new StreamReader("Vehicle.txt");
            string Loaddata = Directory.GetCurrentDirectory().ToString();
            string rad;
            while ((rad = infile.ReadLine()) != null)
            {
                Loadddata.Add(rad);
            }
            infile.Close();
            return Loadddata;
        }

        public static void Spara(List<string> Savedata)
        {

            StreamWriter outfile = new StreamWriter("Vehicle.txt");
            foreach (var item in Savedata)
            {
                outfile.WriteLine(item);
            }
            outfile.Close();
        }
    }
}
