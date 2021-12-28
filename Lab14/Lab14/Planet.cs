using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Configuration;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Xml;
using System.Xml.Linq;

namespace Lab14
{
    [DataContract]
    [Serializable]
    public class Planet
    {
        AbstractClass[] abstractclass;
        [DataMember] public int size = 0;
        [DataMember] public string Name { get; set; }
        [DataMember] public Water water;
        [DataMember] public Land land;
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

        public Planet(Water wt, Land ld, string name)
        {
            this.water = wt;
            this.land = ld;
            this.Name = name;
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
