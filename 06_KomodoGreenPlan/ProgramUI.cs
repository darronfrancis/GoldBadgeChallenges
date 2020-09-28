using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    class ProgramUI
    {
        private GasCarRepository _gasCarList = new GasCarRepository();
        private ElectricCarRepository _electricCarList = new ElectricCarRepository();
        private HybridCarRepository _hybridCarList = new HybridCarRepository();

        public void Run()
        {
            SeedList();
            Menu();
        }

        private void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "1. List Cars\n" +
                    "2. Add a Car\n" +
                    "3. Update a Car\n" +
                    "4. Delete a Car\n" +
                    "5. Quit");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("What list of cars would you like to see?");
                        Console.WriteLine("1. See List of Gas Cars\n" +
                            "2. See List of Hybrid Cars\n" +
                            "3. See List of Electric Cars");
                        userInput = int.Parse(Console.ReadLine());
                        switch(userInput)
                        {
                            case 1:
                                ListGasCars();
                                break;
                            case 2:
                                ListHybridCars();
                                break;
                            case 3:
                                ListElectricCars();
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("What type of car would you like to add?");
                        Console.WriteLine("1. Add a Gas Car\n" +
                            "2. Add a Hybrid Car\n" +
                            "3. Add an Electric Car");
                        userInput = int.Parse(Console.ReadLine());
                        switch (userInput)
                        {
                            case 1:
                                AddGasCar();
                                break;
                            case 2:
                                AddHybridCar();
                                break;
                            case 3:
                                AddElectricCar();
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("What type of car would you like to update?");
                        Console.WriteLine("1. Update a Gas Car\n" +
                            "2. Update a Hybrid Car\n" +
                            "3. Update an Electric Car");
                        userInput = int.Parse(Console.ReadLine());
                        switch (userInput)
                        {
                            case 1:
                                UpdateGasCar();
                                break;
                            case 2:
                                UpdateHybridCar();
                                break;
                            case 3:
                                UpdateElectricCar();
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("What type of car would you like to delete?");
                        Console.WriteLine("1. Delete a Gas Car\n" +
                            "2. Delete a Hybrid Car\n" +
                            "3. Delete an Electric Car");
                        userInput = int.Parse(Console.ReadLine());
                        switch (userInput)
                        {
                            case 1:
                                DeleteGasCar();
                                break;
                            case 2:
                                DeleteHybridCar();
                                break;
                            case 3:
                                DeleteElectricCar();
                                break;
                        }
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Menu();
                        break;
                }
            }
        }

        private void ListGasCars()
        {
            Console.Clear();
            List<GasCar> listOfGasCars = _gasCarList.GetGasCar();
            Console.Clear();
            Console.WriteLine("Manufacturer * Model * Year * Top Speed * Acceleration");
            foreach (var item in listOfGasCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration}");
            }
            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }
        private void ListElectricCars()
        {
            Console.Clear();
            List<ElectricCar> listOfElectricCars = _electricCarList.GetElectricCar();
            Console.Clear();
            Console.WriteLine("Manufacturer * Model * Year * Top Speed * Acceleration * Charging Time * Nominal Range");
            foreach (var item in listOfElectricCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration} * {item.ChargingTime} * {item.NominalRange}");
            }
            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }
        private void ListHybridCars()
        {
            Console.Clear();
            List<HybridCar> listOfHybridCars = _hybridCarList.GetHybridCar();
            Console.Clear();
            Console.WriteLine("Manufacturer * Model * Year * Top Speed * Acceleration * Charging Time * Nominal Range");
            foreach (var item in listOfHybridCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration} * {item.ChargingTime} * {item.NominalRange}");
            }
            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }

        private void AddGasCar()
        {
            GasCar newGasCar = new GasCar();
            Console.Clear();

            Console.WriteLine("Manufacturer:");
            newGasCar.Manufacturer = Console.ReadLine();
            Console.WriteLine("Model:");
            newGasCar.Model = Console.ReadLine();
            Console.WriteLine("Year:");
            string year = Console.ReadLine();
            newGasCar.YearMade = DateTime.Parse($"01/01/{year}");
            Console.WriteLine("Top Speed:");
            newGasCar.TopSpeed = int.Parse(Console.ReadLine());
            Console.WriteLine("Acceleration to 60mph in Seconds:");
            newGasCar.Acceleration = double.Parse(Console.ReadLine());
            
            _gasCarList.AddGasCar(newGasCar);

            Console.Clear();
            Console.WriteLine($"\nYou've added a new gas car.\n" +
                $"Manufacturer: {newGasCar.Manufacturer}\n" +
                $"Model: {newGasCar.Model}\n" +
                $"Year: {newGasCar.YearMade.Year}\n" +
                $"Top Speed: {newGasCar.TopSpeed}\n" +
                $"Acceleration: {newGasCar.Acceleration}\n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        private void AddElectricCar()
        {
            ElectricCar newElectricCar = new ElectricCar();
            Console.Clear();

            Console.WriteLine("Manufacturer:");
            newElectricCar.Manufacturer = Console.ReadLine();
            Console.WriteLine("Model:");
            newElectricCar.Model = Console.ReadLine();
            Console.WriteLine("Year:");
            string year = Console.ReadLine();
            newElectricCar.YearMade = DateTime.Parse($"01/01/{year}");
            Console.WriteLine("Top Speed:");
            newElectricCar.TopSpeed = int.Parse(Console.ReadLine());
            Console.WriteLine("Acceleration to 60mph in Seconds:");
            newElectricCar.Acceleration = double.Parse(Console.ReadLine());
            Console.WriteLine("Charging Time (hours:minutes):");
            newElectricCar.ChargingTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("Nominal Range:");
            newElectricCar.NominalRange = int.Parse(Console.ReadLine());

            _electricCarList.AddElectricCar(newElectricCar);

            Console.Clear();
            Console.WriteLine($"\nYou've added a new electric car.\n" +
                $"Manufacturer: {newElectricCar.Manufacturer}\n" +
                $"Model: {newElectricCar.Model}\n" +
                $"Year: {newElectricCar.YearMade.Year}\n" +
                $"Top Speed: {newElectricCar.TopSpeed}\n" +
                $"Acceleration: {newElectricCar.Acceleration}\n" +
                $"Charging Time: {newElectricCar.ChargingTime}\n" +
                $"Nominal Range: {newElectricCar.NominalRange}\n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        private void AddHybridCar()
        {
            HybridCar newHybridCar = new HybridCar();
            Console.Clear();

            Console.WriteLine("Manufacturer:");
            newHybridCar.Manufacturer = Console.ReadLine();
            Console.WriteLine("Model:");
            newHybridCar.Model = Console.ReadLine();
            Console.WriteLine("Year:");
            string year = Console.ReadLine();
            newHybridCar.YearMade = DateTime.Parse($"01/01/{year}");
            Console.WriteLine("Top Speed:");
            newHybridCar.TopSpeed = int.Parse(Console.ReadLine());
            Console.WriteLine("Acceleration to 60mph in Seconds:");
            newHybridCar.Acceleration = double.Parse(Console.ReadLine());
            Console.WriteLine("Charging Time (hours:minutes):");
            newHybridCar.ChargingTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("Nominal Range:");
            newHybridCar.NominalRange = int.Parse(Console.ReadLine());

            _hybridCarList.AddHybridCar(newHybridCar);

            Console.Clear();
            Console.WriteLine($"\nYou've added a new electric car.\n" +
                $"Manufacturer: {newHybridCar.Manufacturer}\n" +
                $"Model: {newHybridCar.Model}\n" +
                $"Year: {newHybridCar.YearMade.Year}\n" +
                $"Top Speed: {newHybridCar.TopSpeed}\n" +
                $"Acceleration: {newHybridCar.Acceleration}\n" +
                $"Charging Time: {newHybridCar.ChargingTime}\n" +
                $"Nominal Range: {newHybridCar.NominalRange}\n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void UpdateGasCar()
        {
            Console.Clear();
            List<GasCar> listOfGasCars = _gasCarList.GetGasCar();
            Console.WriteLine("Manufacturer * Model * Year * Top Speed * Acceleration");
            foreach (var item in listOfGasCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration}");
            }
            Console.WriteLine($"\nWhich model of car would you like to update?");
            string model = Console.ReadLine().ToLower();
            GasCar car = _gasCarList.GetGasCarByModel(model);
            
            Console.Clear();
            Console.WriteLine($"You are editing info for the {car.Model}.  Please enter the updated info:");
            Console.WriteLine($"Updated Manufacturer ({car.Manufacturer}):");
            car.Manufacturer = Console.ReadLine();
            Console.WriteLine($"Model ({car.Model}):");
            car.Model = Console.ReadLine();
            Console.WriteLine($"Year Made ({car.YearMade.Year}):");
            string year = Console.ReadLine();
            car.YearMade = DateTime.Parse($"01/01/{year}");
            Console.WriteLine($"Top Speed ({car.TopSpeed}):");
            car.TopSpeed = int.Parse(Console.ReadLine());
            Console.WriteLine($"Acceleration ({car.Acceleration}):");
            car.Acceleration = double.Parse(Console.ReadLine());
            
            _gasCarList.UpdateGasCar(model, car);

            Console.Clear();
            Console.WriteLine($"You've added a new electric car.\n" +
                $"Manufacturer: {car.Manufacturer}\n" +
                $"Model: {car.Model}\n" +
                $"Year: {car.YearMade.Year}\n" +
                $"Top Speed: {car.TopSpeed}\n" +
                $"Acceleration: {car.Acceleration}\n");

            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }
        private void UpdateElectricCar()
        {
            Console.Clear();
            List<ElectricCar> listOfElectricCars = _electricCarList.GetElectricCar();
            Console.WriteLine("Manufacturer * Model * Year * Top Speed * Acceleration * Charging Time * Nominal Range");
            foreach (var item in listOfElectricCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration} * {item.ChargingTime} * {item.NominalRange}");
            }
            Console.WriteLine($"\nWhich model of car would you like to update?");
            string model = Console.ReadLine().ToLower();
            ElectricCar car = _electricCarList.GetElectricCarByModel(model);
            
            Console.Clear();
            Console.WriteLine($"You are editing info for the {car.Model}.  Please enter the updated info:");
            Console.WriteLine($"Updated Manufacturer ({car.Manufacturer}):");
            car.Manufacturer = Console.ReadLine();
            Console.WriteLine($"Model ({car.Model}):");
            car.Model = Console.ReadLine();
            Console.WriteLine($"Year Made ({car.YearMade.Year}):");
            string year = Console.ReadLine();
            car.YearMade = DateTime.Parse($"01/01/{year}");
            Console.WriteLine($"Top Speed ({car.TopSpeed}):");
            car.TopSpeed = int.Parse(Console.ReadLine());
            Console.WriteLine($"Acceleration ({car.Acceleration}):");
            car.Acceleration = double.Parse(Console.ReadLine());
            Console.WriteLine($"Charging Time ({car.ChargingTime} hours:minutes):");
            car.ChargingTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine($"Nominal Range ({car.NominalRange}):");
            car.NominalRange = int.Parse(Console.ReadLine());

            _electricCarList.UpdateElectricCar(model, car);

            Console.Clear();
            Console.WriteLine($"You've added a new electric car.\n" +
                $"Manufacturer: {car.Manufacturer}\n" +
                $"Model: {car.Model}\n" +
                $"Year: {car.YearMade.Year}\n" +
                $"Top Speed: {car.TopSpeed}\n" +
                $"Acceleration: {car.Acceleration}\n" +
                $"Charging Time: {car.ChargingTime.Hours}\n" +
                $"Nominal Range: {car.NominalRange}");
            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }
        private void UpdateHybridCar()
        {
            Console.Clear();
            List<HybridCar> listOfHybridCars = _hybridCarList.GetHybridCar();
            Console.WriteLine("Manufacturer * Model * Year * Top Speed * Acceleration * Charging Time * Nominal Range");
            foreach (var item in listOfHybridCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration} * {item.ChargingTime} * {item.NominalRange}");
            }
            Console.WriteLine($"\nWhich model of car would you like to update?");
            string model = Console.ReadLine().ToLower();
            HybridCar car = _hybridCarList.GetHybridCarByModel(model);

            Console.Clear();
            Console.WriteLine($"You are editing info for the {car.Model}.  Please enter the updated info:");
            Console.WriteLine($"Updated Manufacturer ({car.Manufacturer}):");
            car.Manufacturer = Console.ReadLine();
            Console.WriteLine($"Model ({car.Model}):");
            car.Model = Console.ReadLine();
            Console.WriteLine($"Year Made ({car.YearMade.Year}):");
            string year = Console.ReadLine();
            car.YearMade = DateTime.Parse($"01/01/{year}");
            Console.WriteLine($"Top Speed ({car.TopSpeed}):");
            car.TopSpeed = int.Parse(Console.ReadLine());
            Console.WriteLine($"Acceleration ({car.Acceleration}):");
            car.Acceleration = double.Parse(Console.ReadLine());
            Console.WriteLine($"Charging Time ({car.ChargingTime} hours:minutes):");
            car.ChargingTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine($"Nominal Range ({car.NominalRange}):");
            car.NominalRange = int.Parse(Console.ReadLine());

            _hybridCarList.UpdateHybridCar(model, car);

            Console.Clear();
            Console.WriteLine($"You've added a new hybrid car.\n" +
                $"Manufacturer: {car.Manufacturer}\n" +
                $"Model: {car.Model}\n" +
                $"Year: {car.YearMade.Year}\n" +
                $"Top Speed: {car.TopSpeed}\n" +
                $"Acceleration: {car.Acceleration}\n" +
                $"Charging Time: {car.ChargingTime.Hours}\n" +
                $"Nominal Range: {car.NominalRange}");
            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }

        private void DeleteGasCar()
        {
            Console.Clear();
            List<GasCar> listOfGasCars = _gasCarList.GetGasCar();
            Console.Clear();
            Console.WriteLine("Manufacturer * Model * Year * Top Speed * Acceleration");
            foreach (var item in listOfGasCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration}");
            }
            Console.WriteLine($"\nWhich model of car would you like to delete?");
            string model = Console.ReadLine().ToLower();
            _gasCarList.RemoveGasCar(model);

            Console.Clear();
            Console.WriteLine("Your car has been deleted.  Current Gas Cars:");
            foreach (var item in listOfGasCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration}");
            }

            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }
        private void DeleteElectricCar()
        {
            Console.Clear();
            List<ElectricCar> listOfElectricCars = _electricCarList.GetElectricCar();
            Console.Clear();
            Console.WriteLine("Manufacturer * Model * Year * Top Speed * Acceleration * Charging Time * Nominal Range");
            foreach (var item in listOfElectricCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration} * {item.ChargingTime} * {item.NominalRange}");
            }
            Console.WriteLine($"\nWhich model of car would you like to delete?");
            string model = Console.ReadLine().ToLower();
            _electricCarList.RemoveElectricCar(model);

            Console.Clear();
            Console.WriteLine("Your car has been deleted.  Current Electric Cars:");
            foreach (var item in listOfElectricCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration} * {item.ChargingTime} * {item.NominalRange}");
            }

            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }
        private void DeleteHybridCar()
        {
            Console.Clear();
            List<HybridCar> listOfHybridCars = _hybridCarList.GetHybridCar();
            Console.Clear();
            Console.WriteLine("Manufacturer * Model * Year * Top Speed * Acceleration * Charging Time * Nominal Range");
            foreach (var item in listOfHybridCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration} * {item.ChargingTime} * {item.NominalRange}");
            }
            Console.WriteLine($"\nWhich model of car would you like to delete?");
            string model = Console.ReadLine().ToLower();
            _hybridCarList.RemoveHybridCar(model);

            Console.Clear();
            Console.WriteLine("Your car has been deleted.  Current Electric Cars:");
            foreach (var item in listOfHybridCars)
            {
                Console.WriteLine($"{item.Manufacturer} * {item.Model} * {item.YearMade.Year} * {item.TopSpeed} * {item.Acceleration} * {item.ChargingTime} * {item.NominalRange}");
            }

            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }

        private void SeedList()
        {
            GasCar gasCar1 = new GasCar("Toyota", "Prius Eco", DateTime.Parse("01-01-2020"), 124, 9.9, TimeSpan.Parse("0"), 269);
            GasCar gasCar2 = new GasCar("Honda", "Insight", DateTime.Parse("01-01-2020"), 100, 9.2, TimeSpan.Parse("0"), 250);
            GasCar gasCar3 = new GasCar("Honda", "Accord", DateTime.Parse("01-01-2019"), 98, 8.9, TimeSpan.Parse("0"), 153);
            ElectricCar electricCar1 = new ElectricCar("Audi", "e-tron 55", DateTime.Parse("01-01-2018"), 124, 5.7, TimeSpan.Parse("8:30"), 269);
            ElectricCar electricCar2 = new ElectricCar("Volkswagon", "ID.4", DateTime.Parse("01-01-2020"), 100, 9.8, TimeSpan.Parse("9:00"), 250);
            ElectricCar electricCar3 = new ElectricCar("BMW", "i3", DateTime.Parse("01-01-2019"), 98, 8, TimeSpan.Parse("6:00"), 153);
            HybridCar hybridCar1 = new HybridCar("Volvo", "XC60 T8", DateTime.Parse("01-01-2017"), 124, 5.7, TimeSpan.Parse("3:30"), 600);
            HybridCar hybridCar2 = new HybridCar("Lexus", "LC500h", DateTime.Parse("01-01-2017"), 168, 4.8, TimeSpan.Parse("9:00"), 250);
            HybridCar hybridCar3 = new HybridCar("Toyota", "Corolla Hybrid", DateTime.Parse("01-01-2018"), 98, 8, TimeSpan.Parse("6:00"), 153);

            _gasCarList.AddGasCar(gasCar1);
            _gasCarList.AddGasCar(gasCar2);
            _gasCarList.AddGasCar(gasCar3);
            _electricCarList.AddElectricCar(electricCar1);
            _electricCarList.AddElectricCar(electricCar2);
            _electricCarList.AddElectricCar(electricCar3);
            _hybridCarList.AddHybridCar(hybridCar1);
            _hybridCarList.AddHybridCar(hybridCar2);
            _hybridCarList.AddHybridCar(hybridCar3);
        }
    }
}
