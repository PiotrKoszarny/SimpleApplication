using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApp.DataAccess.Entity
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ProductionDate { get; set; }
        public double Mileage { get; set; }
        public string FilePath { get; set; }
    }
}
