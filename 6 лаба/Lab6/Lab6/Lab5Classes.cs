using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Lab6
{
    public abstract class AbstractClass
    {
        abstract public void WriteAbstract();
        abstract public void WriteInterfaceMethod();
    }
    public interface Interface1
    {
        void WriteInterfaceMethod();
    }
    public interface Interface2
    {
        void WriteInterfaceMethod();
    }
    public class Printer
    {
        public static string IAmPrinting(Interface1 someobj)
        {
            return someobj.ToString();
        }
    }
    public class Realization : AbstractClass, Interface1, Interface2
    {
        override public void WriteAbstract()
        {
            Console.WriteLine("AbstractMethod");
        }
        override public void WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterfaceMethod Abstract");
        }
        void Interface1.WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterface1Method Realization");
        }

        void Interface2.WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterface2Method Realization");
        }

    }
    public class Country : AbstractClass
    {
        override public void WriteAbstract()
        {
            Console.WriteLine("AbstractMethod Country");
        }
        override public void WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterfaceMethod Abstract Country");
        }
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
    public class Continent : Country
    {
        new public string Name { get; set; }
        public Country[] countrys;
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
    public class Island : AbstractClass
    {
        override public void WriteAbstract()
        {
            Console.WriteLine("AbstractMethod Island");
        }
        override public void WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterfaceMethod Abstract Island");
        }
        public string Name { get; set; }
        public Island(string nm)
        {
            this.Name = nm;
        }
    }
    public class Land : Continent
    {
        new public string Name { get; set; }
        public Continent[] continents;
        public Island[] islands;
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
    public class Sea : AbstractClass
    {
        override public void WriteAbstract()
        {
            Console.WriteLine("AbstractMethod Sea");
        }
        override public void WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterfaceMethod Abstract Sea");
        }
        public string Name { get; set; }

        public Sea(string nm)
        {
            this.Name = nm;
        }
    }
    public class Ocean : Sea
    {
        new string Name { get; set; }
        public Sea[] sea;
        public Ocean(string nm, Sea[] s) : base(nm)
        {
            this.Name = nm;
            this.sea = s;
        }
    }
    public class Water : Ocean
    {
        public Ocean[] oceans;
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
