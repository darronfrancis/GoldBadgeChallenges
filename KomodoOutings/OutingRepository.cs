using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    public class OutingRepository
    {
        private List<Outing> _listOfOutings = new List<Outing>();

        //CREATE
        public void AddOuting(Outing item)
        {
            _listOfOutings.Add(item);
        }

        //READ
        public List<Outing> GetOuting()
        {
            return _listOfOutings;
        }

        //HELPER
        public Outing GetOutingByType(string type)
        {
            foreach (Outing item in _listOfOutings)
            {
                if (item.EventType.ToString() == type)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
