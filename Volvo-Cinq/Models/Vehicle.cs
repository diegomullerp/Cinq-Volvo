using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Vehicle
    {
        enum VehicleType
        {
            Bus = 1,
            Car = 2,
            Truck = 3
        }
        [Key]
        public int Id { get; set; }
        public string ChassisSeries { get; set; }
        public int ChassisNumber { get; set; }
        public int Type { get; set; }
        public byte NumberOfPassengers { get; set; }
        public string Color { get; set; }
    }
}
