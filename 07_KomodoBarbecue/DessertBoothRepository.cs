using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KomodoBarbecue
{
    class DessertBoothRepository
    {
        List<DessertBooth> _listOfDessertBooths = new List<DessertBooth>();

        //CREATE
        public void AddDessertBooth(DessertBooth item)
        {
            _listOfDessertBooths.Add(item);
        }

        //READ
        public List<DessertBooth> ListDessertBooths()
        {
            return _listOfDessertBooths;
        }
    }
}
