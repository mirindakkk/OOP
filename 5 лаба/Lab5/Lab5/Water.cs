using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Water : Ocean
    {
        Ocean[] oceans;
        public Ocean this[int index]
        {
            get
            {
                return this.oceans[index];
            }

            set
            {
                this.oceans[index] = value;
            }
        }
        public Water(Ocean[] oc, string nm) : base(nm, oc)
        {
            this.oceans = oc;
        }
    }
}
