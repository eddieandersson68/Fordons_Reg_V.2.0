using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using FordonsReg.Enums;

namespace FordonsReg
{
    public class MainMenu
    {

        ProgramHandler handler = new ProgramHandler();
        private bool programIsOn = true;

        static void SetConsoleSize()
        {
            System.Console.SetWindowPosition(0, 0);   // sets window position to upper left
            System.Console.SetBufferSize(400, 200);   // make sure buffer is bigger than window
            System.Console.SetWindowSize(120, 58);   //set window size to almost full screen 
                                                      //width - maxSet(127,57) (width, height)

            //System.Console.ResetColor(); //resets fore and background colors to default
        }

        public void PrintMenu()
        {
            while (programIsOn == true)
            {
                Welcome();

                Console.WriteLine("\n\n-- Please Select --\n");
                Console.WriteLine("1. Print/Create Cars");
                Console.WriteLine("2. Print/Create Boats");
                Console.WriteLine("3. Print/Create Motorcykles");
                Console.WriteLine("4. Print all Vehicles in m/s");
                Console.WriteLine("5. Search for vehicle");
                Console.WriteLine("6. Exit program ");
                Console.WriteLine("7. EasterEgg");
                Console.WriteLine("");
                Console.WriteLine("Please select 1-7, and hit enter");

                int.TryParse(Console.ReadLine(), out int choice);


                switch (choice)
                {
                    case 1:
                        {
                            handler.CreateVehicle(VehicleType.Car);
                            break;
                        }
                    case 2:
                        {
                            handler.CreateVehicle(VehicleType.Boat);
                            break;
                        }
                    case 3:
                        {
                            handler.CreateVehicle(VehicleType.Motorcycle);
                            break;
                        }
                    case 4:
                        {
                            Converter.PrintSpeedInMetersPerSecond(handler.Carlist, handler.Boatslist, handler.Mclist);
                            Console.WriteLine("\nPress any key to continue main");
                            Console.ReadKey();
                            Console.Clear();
                            //MainMenu.Print();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("\nSearch for vehicle name");
                            string SearchQuery = Console.ReadLine();
                            handler.FindVehicleNames(SearchQuery);
                            ContinueText();
                            break;
                        }
                    case 6:
                        {
                            programIsOn = false;
                            Environment.Exit(0);
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            SetConsoleSize();
                            string dirpath = Directory.GetCurrentDirectory().ToString();
                            string line;
                            StreamReader sr = new StreamReader(dirpath + "\\GodInv.txt");
                            line = sr.ReadLine();

                            while (line != null)
                            {
                                Thread.Sleep(100);
                                Console.WriteLine(line);
                                line = sr.ReadLine();
                            }
                            sr.Close();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            string o = "Happy Easter! Press any Key to Exit! ";
                            Console.SetCursorPosition((Console.WindowWidth - o.Length) / 2, Console.CursorTop);
                            Console.WriteLine(o);
                            Console.ResetColor();
                            Console.ReadKey();

                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            //Console.WriteLine("\a");
                            NotCorrectNr();
                            break;
                        }
                }

            }
        }

        public static void ContinueText() // Method to tell the user to go back to main menu
        {
            string k = " \nHit any key to go back to main menu";
            Console.SetCursorPosition((Console.WindowWidth - k.Length) / 2, Console.CursorTop);
            Console.WriteLine(k);
            Console.ReadKey();
            Console.Clear();
            //MainMenu.Print();
            //Console.WriteLine("\nHit any key to continue: ");
        }

        public static void Welcome() // Just a welcome message upon start of the program
        {
            string s = "Welcome to our garage sim";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
        }
        public static void Error() // Displays an error when the user has not fooled the instuction correctly
        {
            //Console.WriteLine("\a");
            Console.ForegroundColor = ConsoleColor.Red;
            string e = "An exception occured! Sorry! ";
            Console.SetCursorPosition((Console.WindowWidth - e.Length) / 2, Console.CursorTop);
            Console.WriteLine(e);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Going back to main!");
            Thread.Sleep(1000);
            Console.Clear();
            //MainMenu.Print();
        }

        public static void NotCorrectNr() // Tells the user that he/she has not typed in a number between 1-8
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("\a");
            string p = "You typed the wrong key, please select between 1-8 ";
            Console.SetCursorPosition((Console.WindowWidth - p.Length) / 2, Console.CursorTop);
            Console.WriteLine(p);
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(3000);
            Console.Clear();
            //MainMenu.Print();

        } public static void NotPlusOrMinus() // Tells the user that he/she has not press - OR +
        {
            //Console.WriteLine("\a");
            Console.ForegroundColor = ConsoleColor.Red;
            string y = "That's not + OR -, try again";
            Console.SetCursorPosition((Console.WindowWidth - y.Length) / 2, Console.CursorTop);
            Console.WriteLine(y);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void NotXOrIndex()
        {
            //Console.WriteLine("\a");
            Console.ForegroundColor = ConsoleColor.Red;
            string g = "That's not x OR a valid  Index nr, try again";
            Console.SetCursorPosition((Console.WindowWidth - g.Length) / 2, Console.CursorTop);
            Console.WriteLine(g);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void NotIndexOrEdit()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string o = "That's not a valid index Nr or the word edit";
            Console.SetCursorPosition((Console.WindowWidth - o.Length) / 2, Console.CursorTop);
            Console.WriteLine(o);
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(2000);
            Console.Clear();
        }
        public  void WrongSpeed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string v = "You have not entered an valid speed.\n";
            Console.SetCursorPosition((Console.WindowWidth - v.Length) / 2, Console.CursorTop);
            Console.WriteLine(v);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
