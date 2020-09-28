using System;
using System.Collections.Generic;
using KomodoGreenPlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoGreenPlanTests
{
    [TestClass]
    public class KomodoGreenTests
    {
        GasCarRepository gasCarRepository = new GasCarRepository();
        ElectricCarRepository electricCarRepository = new ElectricCarRepository();
        HybridCarRepository hybridCarRepository = new HybridCarRepository();

        
        [TestMethod]
        public void AddNewGasCar()
        {
            GasCar gasCar1 = new GasCar("Toyota", "Prius Eco", DateTime.Parse("01-01-2020"), 124, 9.9, TimeSpan.Parse("0"), 269);

            gasCarRepository.AddGasCar(gasCar1);
        }
        [TestMethod]
        public void AddNewElectricCar()
        {
            ElectricCar electricCar1 = new ElectricCar( "Audi", "e-tron 55", DateTime.Parse("1/1/2018"), 124, 5.7, TimeSpan.Parse("8:5"), 269);

            electricCarRepository.AddElectricCar(electricCar1);
        }
        [TestMethod]
        public void AddNewHybridCar()
        {
            HybridCar hybridCar1 = new HybridCar("Volvo", "XC60 T8", DateTime.Parse("01-01-2017"), 124, 5.7, TimeSpan.Parse("3:30"), 600);

            hybridCarRepository.AddHybridCar(hybridCar1);
        }

        [TestMethod]
        public void GetGasCars()
        {
            gasCarRepository.GetGasCar();
        }
        [TestMethod]
        public void GetElectricCars()
        {
            electricCarRepository.GetElectricCar();
        }
        [TestMethod]
        public void GetHybridCars()
        {
            hybridCarRepository.GetHybridCar();
        }

        [TestMethod]
        public void UpdateGasCar()
        {
            GasCar newGasCar = new GasCar("Honda", "Clarity Gas", DateTime.Parse("1/1/2018"), 114, 9, TimeSpan.Parse("9:5"), 89);

            gasCarRepository.UpdateGasCar("e-tron 55", newGasCar);
        }
        [TestMethod]
        public void UpdateElectricCar()
        {
            ElectricCar newElectricCar = new ElectricCar("Honda", "Clarity Electric", DateTime.Parse("1/1/2018"), 114, 9, TimeSpan.Parse("9:5"), 89);

            electricCarRepository.UpdateElectricCar("e-tron 55", newElectricCar);
        }
        [TestMethod]
        public void UpdateHybridCar()
        {
            HybridCar hybridCar2 = new HybridCar("Lexus", "LC500h", DateTime.Parse("01-01-2017"), 168, 4.8, TimeSpan.Parse("9:00"), 250);

            hybridCarRepository.UpdateHybridCar("XC60 T8", hybridCar2);
        }

        [TestMethod]
        public void DeleteGasCar()
        {
            gasCarRepository.RemoveGasCar("e-tron 55");
        }
        [TestMethod]
        public void DeleteElectricCar()
        {
            electricCarRepository.RemoveElectricCar("e-tron 55");
        }

        [TestMethod]
        public void DeleteHybridCar()
        {
            hybridCarRepository.RemoveHybridCar("XC60 T8");
        }
    }
}
