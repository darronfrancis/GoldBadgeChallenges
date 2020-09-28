using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class HybridCarRepository
    {
        private List<HybridCar> _listOfHybridCars = new List<HybridCar>();

        //CREATE
        public void AddHybridCar(HybridCar item)
        {
            _listOfHybridCars.Add(item);
        }

        //READ
        public List<HybridCar> GetHybridCar()
        {
            return _listOfHybridCars;
        }

        //UPDATE
        public bool UpdateHybridCar(string model, HybridCar newContent)
        {
            // Find the content
            HybridCar oldContent = GetHybridCarByModel(model);

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
        public bool RemoveHybridCar(string model)
        {
            HybridCar content = GetHybridCarByModel(model);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfHybridCars.Count;
            _listOfHybridCars.Remove(content);

            if (initialCount > _listOfHybridCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER
        public HybridCar GetHybridCarByModel(string model)
        {
            foreach (HybridCar item in _listOfHybridCars)
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
