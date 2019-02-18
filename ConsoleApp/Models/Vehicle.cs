using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Vehicle
    {
        enum VehicleType
        {
            Bus = 1,
            Car = 2,
            Truck = 3
        }
        public int Id { get; set; }
        public string ChassisSeries { get; set; }
        public int ChassisNumber { get; set; }
        public int Type { get; set; }
        public byte NumberOfPassengers { get; set; }
        public string Color { get; set; }


        public Vehicle()
        {

        }
        public Vehicle(int chassisNumber)
        {
            Vehicle vehicle = VehicleService.GetVehicleByChassisNumber(chassisNumber).Result;
            this.Id = vehicle.Id;
            this.NumberOfPassengers = vehicle.NumberOfPassengers;
            this.Type = vehicle.Type;
            this.Color = vehicle.Color;
            this.ChassisSeries = vehicle.ChassisSeries;
            this.ChassisNumber = vehicle.ChassisNumber;
        }
        public void Save()
        {
            try
            {
                Validations();
                VehicleService vehicleService = new VehicleService();
                vehicleService.SaveVehicle(this);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public List<Vehicle> GetAll()
        {
            try
            {
                VehicleService vehicleService = new VehicleService();
                return vehicleService.GetAll();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete()
        {
            try
            {
                VehicleService vehicleService = new VehicleService();
                vehicleService.Delete(this);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit()
        {
            try
            {
                VehicleService vehicleService = new VehicleService();
                vehicleService.EditVehicle(this);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Validations()
        {
            if (this.NumberOfPassengers != 1 && this.Type == (int)VehicleType.Truck)
                throw new Exception("Number of passengers must be 1 if type is Truck");
            if (this.NumberOfPassengers != 42 && this.Type == (int)VehicleType.Bus)
                throw new Exception("Number of passengers must be 42 if type is Truck");
            if (this.NumberOfPassengers != 4 && this.Type == (int)VehicleType.Car)
                throw new Exception("Number of passengers must be 4 if type is car");
        }
    }
}
