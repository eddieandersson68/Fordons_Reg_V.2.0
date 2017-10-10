using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
// Eddies branch

namespace FordonsReg
{
   public class Program
    {
        private MainMenu menu;
        //Programstart
        static void Main(string[] args)
        {
            
            Program p = new Program();
            p.menu = new MainMenu();
            ProgramHandler.ReturText();
            Console.ForegroundColor = ConsoleColor.Gray;
            //Printar ut progoramet
            p.menu.PrintMenu();
            
            Console.ReadKey();            
        }
    }
}
