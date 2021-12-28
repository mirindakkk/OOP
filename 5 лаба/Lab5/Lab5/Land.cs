using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Land : Continent
    {
        new public string Name { get; set; }
        Continent[] continents;
        Island[] islands;
        new public Continent this[int index]
        {
            get
            {
                return this.continents[index];
            }

            set
            {
                this.continents[index] = value;
            }
        }
        public Land(Continent[] cnt, Island[] isl, string nm) : base(nm, cnt)
        {
            this.islands = isl;
            this.continents = cnt;
        }
    }
}
