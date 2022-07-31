using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightWpf.Models
{
    public class PassengerDetails
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public PassengerDetails():this("",0){}
        public PassengerDetails( string n, int w)
        {
            Name = n;
            Weight = w;
        }
        public override string ToString()
        {
            return $"Name: {Name}, baggage weight: {Weight}";
        }
    }
}
