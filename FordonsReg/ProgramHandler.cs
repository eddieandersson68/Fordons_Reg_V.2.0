using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FordonsReg.Enums;
namespace FordonsReg
{

    public class ProgramHandler
    {
        public List<IVehicle> Carlist;
        public List<IVehicle> Boatslist;
        public List<IVehicle> Mclist;

        //Hanterar logiken för att skapa objekt, lägga till i listor samt redigera

        public int userip1 { get; set; }

        public ProgramHandler()
        {
            Carlist = new List<IVehicle>();
            Boatslist = new List<IVehicle>();
            Mclist = new List<IVehicle>();
        }
         
        public void EditVehicle(VehicleType type)
        {
            int numberInput = 0;
            Console.WriteLine("\nChoose an Index Nr to edit or enter anything to go back to main menu ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out numberInput))
            {
                switch (type)
                {
                    case VehicleType.Car:
                        {
                            if(numberInput < 0 || numberInput > Carlist.Count -1)
                            {
                                IndexOutOfRange();
                                return;
                            }
                            Console.WriteLine($"\nYou have chosen to edit Car: {numberInput} ");
                            NewSpeedPrint();
                            int newspeed = int.Parse(Console.ReadLine());
                            if (newspeed >= 0 && newspeed <= 100)
                            {
                                Carlist[numberInput - 1].setspeed(newspeed);
                                Car.Print(Carlist);
                            }
                            else
                            {
                                Console.WriteLine("You have not entered an valid speed.");
                                Console.ReadKey();
                            }
                            break;
                        }

                    case VehicleType.Boat:
                        {
                            Console.WriteLine($"\nYou have chosen to edit Boat: {numberInput} ");
                            NewSpeedPrint();
                            int newspeed = int.Parse(Console.ReadLine());
                            if (newspeed >= 0 && newspeed <= 100)
                            {
                                Boatslist[numberInput - 1].setspeed(newspeed);
                                Boat.Print(Boatslist);
                            }
                            else
                            {
                                Console.WriteLine("You have not entered an valid speed.");
                                Console.ReadKey();
                            }
                            break;
                        }

                    case VehicleType.Motorcycle:
                        {
                            Console.WriteLine($"\nYou have chosen to edit Motorcykle: {numberInput} ");
                            NewSpeedPrint();
                            int newspeed = int.Parse(Console.ReadLine());
                            if (newspeed >= 0 && newspeed <= 100)
                            {
                                Mclist[numberInput - 1].setspeed(newspeed);
                                Motorcycle.Print(Mclist);
                            }

                            else
                            {
                                Console.WriteLine("You have not entered an valid speed.");
                                Console.ReadKey();
                            }
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("you have not choosen an valid option.");
                Console.WriteLine("press any key to go back to mainmenu.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }
        public void IndexOutOfRange()
        {
            //Console.WriteLine("\a");
            Console.ForegroundColor = ConsoleColor.Red;
            string e = "Error: You've chosen an index that does not exist ";
            Console.SetCursorPosition((Console.WindowWidth - e.Length) / 2, Console.CursorTop);
            Console.WriteLine(e);
            Console.ForegroundColor = ConsoleColor.Gray;
            string f = "Going back to main!";
            Console.SetCursorPosition((Console.WindowWidth - f.Length) / 2, Console.CursorTop);
            Console.WriteLine(f);
            Thread.Sleep(2000);
            Console.Clear();
        }

        private void NewSpeedPrint() // Just prints what's below
        {
            Console.WriteLine("\nChoose a new speed between 0 - 100: End with enter ");
        }

        public void CreateVehicle(VehicleType type)
        {
            string input = "";
            int numberInput;
            switch (type)
            {
                case VehicleType.Car:
                    {
                        Car.Print(Carlist);
                        Console.WriteLine("\nChoose an amount to create or enter 'edit' to edit and hit enter");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out numberInput))
                        {
                            for (int i = 0; i < numberInput; i++)
                            {
                                Carlist.Add(new Car());
                            }
                            Car.Print(Carlist);

                        }

                        else if (input.ToLower() == "edit")
                        {
                            EditVehicle(VehicleType.Car);
                        }
                        else 
                        {
                            MainMenu.NotIndexOrEdit();
                        }
                        //Console.Clear();
                        break;
                    }

                case VehicleType.Boat:
                    {
                        Boat.Print(Boatslist);

                        Console.WriteLine("\nChoose an amount to create or press i to edit and hit enter");
                        int.TryParse(Console.ReadLine(), out int useramount);

                        for (int i = 0; i < useramount; i++)
                        {
                            Boatslist.Add(new Car());
                        }
                        Boat.Print(Boatslist);
                        //Console.Clear();
                        break;
                    }

                case VehicleType.Motorcycle:
                    {
                        Motorcycle.Print(Mclist);

                        Console.WriteLine("\nChoose an amount to create or press i to edit and hit enter");
                        int.TryParse(Console.ReadLine(), out int useramount);

                        for (int i = 0; i < useramount; i++)
                        {
                            Mclist.Add(new Car());
                        }
                        Motorcycle.Print(Mclist);
                        //Console.Clear();
                        break;
                    }
            }

        }
        public void FindVehicleNames(string searchstring) // Method to search for vehicle names
        {
            /* Takes the parameter called searchstring and checks if it's
            *  value is represented in the 3 different lists. 
            *  If it is */

            var quaryCars = from p in Carlist // Search car list
                            where p.Name.ToLower() == searchstring.ToLower()
                            orderby p.Name
                            select p;


            var queryBoats = from p in Boatslist  // Search  boat list
                             where p.Name.ToLower() == searchstring.ToLower()
                             orderby p.Name
                             select p;

            var queryMc = from p in Mclist // Search MC list
                          where p.Name.ToLower() == searchstring.ToLower()
                          orderby p.Name
                          select p;

            Console.Clear();
            Console.WriteLine("Vehicles");
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("--- Cars---");
            foreach (var item in quaryCars)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("--- Boats---");
            foreach (var item in queryBoats)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("--- Motorcykles---");
            foreach (var item in queryMc)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n-------------------------------");
        }
    }
}
