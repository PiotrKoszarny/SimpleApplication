using System;
using System.Collections.Generic;

namespace SimpleApp.Models
{
    public class GetCarDetailsDto
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Mileage { get; set; }
        public List<string> PhotoUrls { get; set; }
    }
}
