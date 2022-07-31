using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightWpf.Models.ViewModels
{
    public class PassengerDetailsVM
    {
        public string Title { get; set; }
        public PassengerDetails Passenger { get;}

        public PassengerDetailsVM(PassengerDetails pd)
        {
            Passenger = pd;
        }
    }
}
