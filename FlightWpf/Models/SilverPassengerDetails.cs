using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightWpf.Models
{
    public class SilverPassengerDetails:PassengerDetails
    {
        public SilverPassengerDetails():this("", 0){}
        public SilverPassengerDetails(string n, int w):base(n,w){}
        public override string ToString()
        {
            return "Silver: "+base.ToString();
        }
    }
}
