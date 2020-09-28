using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class ElectricCarRepository
    {
        private List<ElectricCar> _listOfElectricCars = new List<ElectricCar>();

        //CREATE
        public void AddElectricCar(ElectricCar item)
        {
            _listOfElectricCars.Add(item);
        }

        //READ
        public List<ElectricCar> GetElectricCar()
        {
            return _listOfElectricCars;
        }

        //UPDATE
        public bool UpdateElectricCar(string model, ElectricCar newContent)
        {
            // Find the content
            ElectricCar oldContent = GetElectricCarByModel(model);

            //Update the content
            if (oldContent != null)
            {
                oldContent.Manufacturer = newContent.Manufacturer;
                oldContent.Model = newContent.Model;
                oldContent.YearMade = newContent.YearMade;
                oldContent.TopSpeed = newContent.TopSpeed;
                oldContent.Acceleration = newContent.Acceleration; 
                oldContent.ChargingTime = newContent.ChargingTime;
                oldContent.NominalRange = newContent.NominalRange;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveElectricCar(string model)
        {
            ElectricCar content = GetElectricCarByModel(model);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfElectricCars.Count;
            _listOfElectricCars.Remove(content);

            if (initialCount > _listOfElectricCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER
        public ElectricCar GetElectricCarByModel(string model)
        {
            foreach (ElectricCar item in _listOfElectricCars)
            {
                if (item.Model.ToString().ToLower() == model)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
