using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Realization : AbstractClass
    {
        override public void WriteAbstract()
        {
            Console.WriteLine("AbstractMethod");
        }
        override public void WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterfaceMethod Abstract");
        }
    }
}
