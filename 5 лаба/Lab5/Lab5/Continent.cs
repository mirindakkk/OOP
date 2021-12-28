using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Continent : Country
    {
        new public string Name { get; set; }
        Country[] countrys;
        public Country this[int index]
        {
            get
            {
                return this.countrys[index];
            }
            set
            {
                this.countrys[index] = value;
            }
        }
        public Continent(string nm, Country[] cnt) : base(nm)
        {
            this.Name = nm;
            this.countrys = cnt;
        }
    }
}
