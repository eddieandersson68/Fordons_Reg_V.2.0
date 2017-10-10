using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FordonsReg.Enums;
using ReadAndSaveLib;
using Parser;

namespace FordonsReg
{

    public class ProgramHandler
    {

        public static List<IVehicle> Carlist;
        public static List<IVehicle> Boatslist;
        public static List<IVehicle> Mclist;


        public int userip1 { get; set; }

        public ProgramHandler()
        {
            //if ( != null)
            //{
            //    Converter.PrintSpeedInMetersPerSecond(Carlist, Boatslist, Mclist);
            //}
            //else 
            //{
            Carlist = new List<IVehicle>();
            Boatslist = new List<IVehicle>();
            Mclist = new List<IVehicle>();

        }
        // Create vehicle method
        public void CreateVehicle(VehicleType type)
        {
            string input = "";
            int numberInput;
            switch (type)
            {
                case VehicleType.Car:
                    {
                        Car.Print(Carlist);
                        Console.WriteLine("\nChoose an amount to create or TYPE 'edit' to edit a vehicle and hit enter");
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
                        Console.WriteLine("\nChoose an amount to create or TYPE 'edit' to edit a vehicle and hit enter");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out numberInput))
                        {
                            for (int i = 0; i < numberInput; i++)
                            {
                                Boatslist.Add(new Boat());
                            }
                            Boat.Print(Boatslist);
                        }
                        else if (input.ToLower() == "edit")
                        {
                            EditVehicle(VehicleType.Boat);
                        }
                        else
                        {
                            MainMenu.NotIndexOrEdit();
                        }
                        //Console.Clear();
                        break;

                    }

                case VehicleType.Motorcycle:
                    {
                        Motorcycle.Print(Mclist);
                        Console.WriteLine("\nChoose an amount to create or TYPE 'edit' to edit a vehicle and hit enter");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out numberInput))
                        {
                            for (int i = 0; i < numberInput; i++)
                            {
                                Mclist.Add(new Motorcycle());
                            }
                            Motorcycle.Print(Mclist);
                        }
                        else if (input.ToLower() == "edit")
                        {
                            EditVehicle(VehicleType.Motorcycle);
                        }
                        else
                        {
                            MainMenu.NotIndexOrEdit();
                        }

                        //Console.Clear();
                        break;
                    }
            }

        }

        /// <summary>
        /// Edit functions
        /// </summary>

        #region My VehicleEdit Method
        public void EditVehicle(VehicleType type)
        {
            MainMenu p = new MainMenu();
            int numberInput = 0;
            Console.WriteLine("\nChoose an Index Nr to edit or enter anything to go back to main menu ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out numberInput))
            {
                switch (type)
                {
                    case VehicleType.Car:
                        {
                            if (numberInput < 0 || numberInput > Carlist.Count)
                            {
                                IndexOutOfRange();
                                return;
                            }
                            Console.WriteLine($"\nYou have chosen to edit Car: {numberInput} ");
                            Console.WriteLine("\nWould you like to remove it hit minus and Enter, \notherwise just hit Enter to continue");
                            string minus = Console.ReadLine();
                            if (minus == "-")
                            {
                                Carlist.RemoveAt(numberInput - 1);
                                Console.WriteLine("You removed car {0}", numberInput);
                                Car.Print(Carlist);
                                return;

                            }
                            else
                                NewSpeedPrint();

                            try
                            {
                                int newspeed = int.Parse(Console.ReadLine());

                                if (newspeed >= 0 && newspeed <= 100)
                                {
                                    Carlist[numberInput - 1].setspeed(newspeed);
                                    Car.Print(Carlist);
                                }
                                else
                                {
                                    p.WrongSpeed();
                                    EditVehicle(VehicleType.Car);
                                    Console.ReadKey();
                                }
                            }
                            catch
                            {
                                MainMenu.Error();
                            }
                            break;
                        }

                    case VehicleType.Boat:
                        {
                            Console.WriteLine($"\nYou have chosen to edit Boat: {numberInput} ");
                            Console.WriteLine("\nWould you like to remove it hit minus and Enter, \notherwise just hit Enter to continue");
                            string minus = Console.ReadLine();
                            if (minus == "-")
                            {
                                Boatslist.RemoveAt(numberInput - 1);
                                Console.WriteLine("You removed boat {0}", numberInput);
                                Boat.Print(Boatslist);
                                return;
                            }
                            NewSpeedPrint();

                            try
                            {
                                int newspeed = int.Parse(Console.ReadLine());
                                if (newspeed >= 0 && newspeed <= 100)
                                {
                                    Boatslist[numberInput - 1].setspeed(newspeed);
                                    Boat.Print(Boatslist);
                                }
                                else
                                {
                                    p.WrongSpeed();
                                    EditVehicle(VehicleType.Boat);
                                    Console.ReadKey();
                                }
                            }
                            catch
                            {
                                MainMenu.Error();
                            }
                            break;
                        }

                    case VehicleType.Motorcycle:
                        {
                            Console.WriteLine($"\nYou have chosen to edit Motorcykle: {numberInput} ");
                            Console.WriteLine("\nWould you like to remove it hit minus and Enter, \notherwise just hit Enter to continue");
                            string minus = Console.ReadLine();
                            if (minus == "-")
                            {
                                Mclist.RemoveAt(numberInput - 1);
                                Console.WriteLine("You removed motorcycle {0}", numberInput);
                                Motorcycle.Print(Mclist);
                                return;
                            }
                            NewSpeedPrint();
                            int newspeed = int.Parse(Console.ReadLine());

                            try
                            {
                                if (newspeed >= 0 && newspeed <= 100)
                                {
                                    Mclist[numberInput - 1].setspeed(newspeed);
                                    Motorcycle.Print(Mclist);
                                }

                                else
                                {
                                    p.WrongSpeed();
                                    EditVehicle(VehicleType.Motorcycle);
                                    Console.ReadKey();
                                }
                            }
                            catch
                            {
                                MainMenu.Error();
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
                string e = ("going back to mainmenu.");
                Console.SetCursorPosition((Console.WindowWidth - e.Length) / 2, Console.CursorTop);
                Console.WriteLine(e);
                Thread.Sleep(2000);
                //Console.ReadKey();
                Console.Clear();
                return;
            }
        }
        #endregion
        public static void AllVehicles(List<IVehicle> car, List<IVehicle> boat, List<IVehicle> mc)
        {
            //ProgramHandler VehicleList = new ProgramHandler();

            List<string> Vehcilestring = new List<string>();
            foreach (var i in car)
            {
                Vehcilestring.Add(i.GetType().Name + ":" + i.Speed + ":" + i.Name);
            }
            foreach (var i in boat)
            {
                Vehcilestring.Add(i.GetType().Name + ":" + i.Speed + ":" + i.Name);
            }
            foreach (var i in mc)
            {
                Vehcilestring.Add(i.GetType().Name + ":" + i.Speed + ":" + i.Name);
            }
            ReadAndSaveHandler.Spara(Vehcilestring);
        }
        public static void ReturText()
        {
            //ProgramHandler handler2 = new ProgramHandler();
            ReadAndSaveHandler r = new ReadAndSaveHandler();
            r.Load();

            ParserClass printfromfile = new ParserClass();
            var vehilceread = printfromfile.Vehicles(r.Load());

            for (int i = 0; i < vehilceread.Count(); i += 3)
            {
                if (vehilceread[i] == "Car")
                {

                    Carlist.Add(new Car(int.Parse(vehilceread[i + 1]), vehilceread[i + 2]));
                    //Console.WriteLine(handler2.Carlist[0]);
                    //Console.ReadLine();
                }
                else if (vehilceread[i] == "Boat")
                {
                    Boatslist.Add(new Boat(int.Parse(vehilceread[i + 1]), vehilceread[i + 2]));
                    //Console.WriteLine(handler2.Boatslist[0]);
                    //Console.ReadLine();
                }
                else if (vehilceread[i] == "Motorcycle")
                {
                    Mclist.Add(new Motorcycle(int.Parse(vehilceread[i + 1]), vehilceread[i + 2]));
                    //Console.WriteLine(handler2.Mclist[0]);
                    //Console.ReadLine();

                }
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

        /// <summary>
        /// Search functions
        /// </summary>


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

            if (quaryCars == null && queryBoats == null && queryMc == null)
            {
                Console.WriteLine("Sorry that name doean's exsist in the list");

            }

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
