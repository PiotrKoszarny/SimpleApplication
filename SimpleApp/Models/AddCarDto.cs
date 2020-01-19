using System;
using System.Collections.Generic;

namespace SimpleApp.Models
{
    public class AddCarDto
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Mileage { get; set; }
        public IEnumerable<AddImgFileDto> Photos { get; set; }
    }
}
