﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class ElectricCar : Car
    {
        public TimeSpan ChargingTime { get; set; }
        public int NominalRange { get; set; }

        public ElectricCar() { }

        public ElectricCar(string manufacturer, string model, DateTime yearMade, int topSpeed, double acceleration, TimeSpan chargingTime, int nominalRange)
        {
            Manufacturer = manufacturer;
            Model = model;
            YearMade = yearMade;
            TopSpeed = topSpeed;
            Acceleration = acceleration;
            ChargingTime = chargingTime;
            NominalRange = nominalRange;
        }
    }
}
