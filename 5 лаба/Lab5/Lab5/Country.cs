using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Country
    {
        public string Name { get; set; }
        virtual public void WriteVoid()
        {
            Console.WriteLine("Virtual void");
        }
        public Country(string nm)
        {
            this.Name = nm;
        }
    }
}
