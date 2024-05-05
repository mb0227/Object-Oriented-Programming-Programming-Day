using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;

namespace OceanNavigation
{
    internal class Program
    {
        static List<Ship> shipList = new List<Ship>();
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                header();
                int choice = menu();
                if (choice == 1)
                {
                    addShip();
                }
                else if (choice == 2)
                {
                    viewShipPosition();
                }
                else if (choice == 3)
                {
                    viewShipSerialNumber();
                }
                else if (choice == 4)
                {
                    changeShipPosition();
                }
                else
                {
                    break;
                }
            } while (option != 5);
        }
        static int menu()
        {
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship position");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static void header()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
   ______ _________ 
  / __/ // /  _/ _ \
 _\ \/ _  // // ___/
/___/_//_/___/_/    
                    ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void addShip()
        {
            Console.Clear();
            Console.Write("Enter Ship Number: ");
            string shipNumber = Console.ReadLine();
            Console.WriteLine("Enter Ship Latitude: ");
            Angle Latitude = ReadAngle();
            Console.WriteLine("Enter Ship Longitude: ");
            Angle Longitude = ReadAngle();
            Ship ship = new Ship(shipNumber,Latitude,Longitude);
            shipList.Add(ship);
            Console.WriteLine("Ship Added Successfully");
            Console.WriteLine("TAP KEYBORAD KEY!!");
            Console.ReadKey();
        }
        static Angle ReadAngle()
        {
            Console.Write("Enter the Degree: ");
            int degrees = int.Parse(Console.ReadLine());
            Console.Write("Enter the Minute: ");
            float minutes = float.Parse(Console.ReadLine());
            Console.Write("Enter the Direction: ");
            char direction = char.Parse(Console.ReadLine());
            return new Angle(degrees, minutes, direction);
        }
        static void viewShipPosition()
        {
            Console.Clear();
            Console.Write("Enter Ship Serial Number to find its position: ");
            string serialNumber = Console.ReadLine();

            Ship foundShip = null;
            foreach (Ship ship in shipList)
            {
                if (ship.shipNumber == serialNumber)
                {
                    foundShip = ship;
                    break;
                }
            }

            if (foundShip != null)
            {
                Console.WriteLine(foundShip.printPosition());
            }
            else
            {
                Console.WriteLine("Ship not found.");
            }
            Console.ReadKey();
        }
        static void viewShipSerialNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the ship latitude: ");
            Angle latitude = ReadAngle(); 
            Console.WriteLine("Enter the ship longitude: ");
            Angle longitude = ReadAngle();

            Ship foundShip = null;
            foreach (Ship ship in shipList)
            {
                if ((ship.Latitude.degrees == latitude.degrees) && (ship.Latitude.minutes == latitude.minutes) && (ship.Latitude.direction == latitude.direction) && (ship.Longitude.degrees == longitude.degrees) && (ship.Longitude.minutes == longitude.minutes) && (ship.Longitude.direction == longitude.direction))
                {
                    foundShip = ship;
                    break;
                }
            }

            if (foundShip != null)
            {
                Console.WriteLine(foundShip.printSerialNumber());
            }
            else
            {
                Console.WriteLine("Ship not found.");
            }
            Console.ReadKey();
        }
        static void changeShipPosition()
        {
            Console.Clear();
            Console.WriteLine("Enter Ship's serial number whose position you want to change: ");
            string serialNumber = Console.ReadLine();

            Ship ship = shipList.Find(s => s.shipNumber == serialNumber);
            if (ship != null)
            {
                Console.WriteLine("Enter Ship Latitude:");
                Angle latitude = ReadAngle();

                Console.WriteLine("Enter Ship Longitude:");
                Angle longitude = ReadAngle();

                ship.Latitude = latitude;
                ship.Longitude = longitude;

                Console.WriteLine("Ship position changed successfully.");
            }
            else
            {
                Console.WriteLine("Ship not found.");
            }
            Console.ReadKey();

        }
    }
}
