using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class GasCarRepository
    {
        private List<GasCar> _listOfGasCars = new List<GasCar>();

        //CREATE
        public void AddGasCar(GasCar item)
        {
            _listOfGasCars.Add(item);
        }

        //READ
        public List<GasCar> GetGasCar()
        {
            return _listOfGasCars;
        }

        //UPDATE
        public bool UpdateGasCar(string model, GasCar newContent)
        {
            // Find the content
            GasCar oldContent = GetGasCarByModel(model);

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
        public bool RemoveGasCar(string model)
        {
            GasCar content = GetGasCarByModel(model);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfGasCars.Count;
            _listOfGasCars.Remove(content);

            if (initialCount > _listOfGasCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER
        public GasCar GetGasCarByModel(string model)
        {
            foreach (GasCar item in _listOfGasCars)
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
