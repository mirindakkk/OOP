using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public partial class Planet
    {
        AbstractClass[] abstractclass;
        int size = 0;
        public string Name { get; set; }
        public Water water;
        public Land land;
        public AbstractClass this[int index]
        {
            get
            {
                return abstractclass[index];
            }
            set
            {
                abstractclass[index] = value;
            }
        }
        public Planet()
        {

        }

        public Planet(Water wt, Land ld)
        {
            this.water = wt;
            this.land = ld;
        }

        public void Add(AbstractClass abstr)
        {
            abstractclass[size++] = abstr;
        }

        public void Delete(AbstractClass abstr)
        {
            for (int i = 0; i < size; i++)
            {
                if (abstractclass[i].Equals(abstr))
                {
                    abstractclass[i] = null;
                    size--;
                    break;
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
        }

        public void WriteArray()
        {
            if (size == 0)
            {
                Console.WriteLine("Empty");
            }
            for (int i = 0; i < this.size; i++)
            {
                this.abstractclass[i].WriteAbstract();
            }
        }
    }

}
