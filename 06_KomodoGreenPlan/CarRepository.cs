using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class CarRepository
    {
        private List<Car> _listOfCars = new List<Car>();

        //CREATE
        public void AddCar(Car item)
        {
            _listOfCars.Add(item);
        }

        //READ
        public List<Car> GetCar()
        {
            return _listOfCars;
        }

        //UPDATE
        public bool UpdateCar(string model, Car newContent)
        {
            // Find the content
            Car oldContent = GetCarByModel(model);

            //Update the content
            if (oldContent != null)
            {
                oldContent.Manufacturer = newContent.Manufacturer;
                oldContent.Model = newContent.Model;
                oldContent.YearMade = newContent.YearMade;
                oldContent.TopSpeed = newContent.TopSpeed;
                oldContent.Acceleration = newContent.Acceleration;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveCar(string model)
        {
            Car content = GetCarByModel(model);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfCars.Count;
            _listOfCars.Remove(content);

            if (initialCount > _listOfCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER
        public Car GetCarByModel(string model)
        {
            foreach (Car item in _listOfCars)
            {
                if (item.Model.ToString() == model)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
