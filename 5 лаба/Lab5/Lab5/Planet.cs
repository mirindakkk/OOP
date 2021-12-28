using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Planet : Interface1, Interface2 
    {
        void Interface1.WriteInterfaceMethod()
            {
            Console.WriteLine("WriteInterface1Method Planet");
            }

        void Interface2.WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterface2Method Planet");
        }

        string Name { get; set; }
        Water water;
        Land land;
        public Planet()
        {

        }
        public Planet(Water wt, Land ld)
        {
            this.water = wt;
            this.land = ld;
        }
    }
}
