using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApp.DataAccess.Entity
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ProductionDate { get; set; }

        public double Mileage { get; set; }
    }
}
