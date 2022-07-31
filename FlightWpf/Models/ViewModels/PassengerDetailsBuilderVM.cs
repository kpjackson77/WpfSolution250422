using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightWpf.Models.ViewModels
{
    enum PassengerType { Ordinary, Silver}
    class PassengerDetailsBuilderVM
    {
        private PassengerType _pt = PassengerType.Ordinary;
        public string Title { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public bool IsOrdinary
        {
            get { return _pt == PassengerType.Ordinary; }
            set { _pt = value ? PassengerType.Ordinary : _pt; }
        }
        public bool IsSilver
        {
            get { return _pt == PassengerType.Silver; }
            set { _pt = value ? PassengerType.Silver : _pt; }
        }
        public PassengerDetailsBuilderVM(PassengerDetails pd = null)
        {
            if (pd != null)
            {
                Name = pd.Name;
                Weight = pd.Weight;
                switch (pd.GetType().Name)
                {
                    case "PassengerDetails":
                        IsOrdinary = true;
                        break;
                    case "SilverPassengerDetails":
                        IsSilver = true;
                        break;
                }
            }
        }
        public PassengerDetails Create()
        {
            PassengerDetails pd = null;
            switch (_pt)
            {
                case PassengerType.Ordinary:
                    pd = new PassengerDetails(Name, Weight);
                    break;
                case PassengerType.Silver:
                    pd = new SilverPassengerDetails(Name, Weight);
                    break;
                default:
                    break;
            }
            return pd;
        }
    }
}
