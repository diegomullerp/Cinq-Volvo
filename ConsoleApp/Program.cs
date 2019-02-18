using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool notExit = true;
            while (notExit)
            {
                Console.Clear();
                Console.WriteLine("-----------Menu--------------------");
                Console.WriteLine();

                Console.WriteLine("1 - Insert New Vehicle");
                Console.WriteLine();
                Console.WriteLine("2 - Edit a existing Vehicle");
                Console.WriteLine();
                Console.WriteLine("3 - Delete a existing Vehicle");
                Console.WriteLine();
                Console.WriteLine("4 - List all Vehicles");
                Console.WriteLine();
                Console.WriteLine("5 - Find Vehicle by chassis");
                Console.WriteLine();
                Console.WriteLine("6 - Exit");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Please type your option: ");

                string key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        New(); break;
                    case "2":
                        Edit(); break;
                    case "3":
                        Delete(); break;
                    case "4":
                        List(); break;
                    case "5":
                        FindByChassis(); break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Do you want to exit the application (Y/N)?");
                        string exitConfirmation = Console.ReadLine();
                        if (exitConfirmation.ToUpper() == "Y")
                            notExit = false;
                        break;
                    default:
                        break;
                }
            }
        }

        static void New()
        {
            try
            {
                Vehicle vehicle = new Vehicle();
                Console.Clear();
                Console.WriteLine("Insert New Vehicle");
                Console.WriteLine();
                Console.WriteLine("Chassis Number: ");
                int chassisNumber;
                if (int.TryParse(Console.ReadLine(), out chassisNumber))
                    vehicle.ChassisNumber = chassisNumber;

                Console.WriteLine("Chassis Series: ");
                vehicle.ChassisSeries = Console.ReadLine();

                Console.WriteLine("Type of Vehicle: (1 - Bus, 2 - Car, 3 - Truck) ");
                int vehicleType;
                if (int.TryParse(Console.ReadLine(), out vehicleType))
                    vehicle.Type = vehicleType;

                Console.WriteLine("Number of Passengers: ");
                int numberOfPassengers;
                if (int.TryParse(Console.ReadLine(), out numberOfPassengers))
                    vehicle.NumberOfPassengers = (Byte)numberOfPassengers;

                Console.WriteLine("Color: ");
                vehicle.Color = Console.ReadLine();

                Vehicle vehicleExist = new Vehicle(chassisNumber);
                if (vehicleExist.Id > 0)
                {
                    throw new Exception("Vehicle already exist, please type another chassis number!");
                }

                    vehicle.Save();
                Console.WriteLine("Vehicle was sucessfully saved!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Write("Press any key to go back to menu");
                Console.ReadLine();
            }
        }
        static void Edit()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Edit an existing Vehicle");
                Console.WriteLine();

                Console.WriteLine("Please type the Chassis Number of the Vehicle: ");

                int chassisNumber;
                if (int.TryParse(Console.ReadLine(), out chassisNumber))
                {
                    Vehicle vehicle = new Vehicle(chassisNumber);
                    if (vehicle.Id > 0)
                    {
                        Console.WriteLine("Vehicle found!");
                        Console.WriteLine("Please enter the new color for the vehicle");
                        vehicle.Color = Console.ReadLine();
                        vehicle.Edit();
                        Console.WriteLine("Vehicle color was sucessfully updated!");
                    }
                    else
                        Console.WriteLine("Vehicle not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying to Edit Vehicle, please get in contact with support IT.");
            }
            finally
            {
                Console.Write("Press any key to go back to menu");
                Console.ReadLine();
            }

        }
        static void Delete()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Delete an existing Vehicle");
                Console.WriteLine();
                Console.WriteLine("Please type the Chassis Number of the Vehicle: ");
                Vehicle vehicle = new Vehicle();
                int chassisNumber;
                if (int.TryParse(Console.ReadLine(), out chassisNumber))
                    vehicle.ChassisNumber = chassisNumber;

                vehicle.ChassisNumber = chassisNumber;
                vehicle.Delete();
                Console.WriteLine("Vehicle was deleted sucessfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying to Delete Vehicle, please get in contact with support IT.");
            }
            finally
            {
                Console.Write("Press any key to go back to menu");
                Console.ReadLine();
            }
        }
        static void List()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("List of Vehicle");
                Console.WriteLine();
                List<Vehicle> vehicles = new Vehicle().GetAll();

                foreach (Vehicle vehicle in vehicles)
                {
                    Console.WriteLine("Chassis Number: " + vehicle.ChassisNumber + " ｜ Chassis Series: " + vehicle.ChassisSeries + " ｜ Number of Passengers: " + vehicle.NumberOfPassengers + " ｜ Type: " + (VehicleType)vehicle.Type + " ｜ Color: " + vehicle.Color);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying to List Vehicles, please get in contact with support IT.");
            }
            finally
            {
                Console.Write("Press any key to go back to menu");
                Console.ReadLine();
            }
        }
        static void FindByChassis()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Find Vehicle");
                Console.WriteLine();
                Console.WriteLine("Please type the Chassis Number of the Vehicle: ");

                int chassisNumber;
                if (int.TryParse(Console.ReadLine(), out chassisNumber))
                {
                    Vehicle vehicle = new Vehicle(chassisNumber);
                    if (vehicle.Id > 0)
                    {
                        Console.WriteLine("Vehicle found!");
                        Console.WriteLine(vehicle.ChassisNumber + " " + vehicle.ChassisSeries + " " + vehicle.NumberOfPassengers + " " + vehicle.Type + " " + vehicle.Color);
                    }
                    else
                        Console.WriteLine("Vehicle not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying to Find Vehicle, please get in contact with support IT.");
            }
            finally
            {
                Console.Write("Press any key to go back to menu");
                Console.ReadLine();
            }
        }

        enum VehicleType
        {
            Bus = 1,
            Car = 2,
            Truck = 3
        }
    }
}
