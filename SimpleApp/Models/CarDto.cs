﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Mileage { get; set; }
        //public int MyProperty { get; set; }
    }
}
