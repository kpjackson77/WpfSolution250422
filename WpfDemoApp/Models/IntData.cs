using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemoApp.Models
{
    class IntData
    {
        private int _val;

        public int Val
        {
            get { return _val; }
            set { if (_val != value)
                {
                    if (value < 0 || value > 50) throw new OverflowException("Value out of range!");
                    _val = value;
                }
            }
        }

    }
}
