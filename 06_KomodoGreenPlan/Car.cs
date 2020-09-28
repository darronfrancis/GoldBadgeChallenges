using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class Car
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime YearMade { get; set; }
        public int TopSpeed { get; set; }
        public double Acceleration { get; set; }

        public Car() { }
    }
}
