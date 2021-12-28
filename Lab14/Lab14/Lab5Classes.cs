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
    [Serializable]
    [DataContract]
    public abstract class AbstractClass
    {
        abstract public void WriteAbstract();
        abstract public void WriteInterfaceMethod();
    }
    public interface IInterface1
    {
        void WriteInterfaceMethod();
    }
    public interface IInterface2
    {
        void WriteInterfaceMethod();
    }
    public class Printer
    {
        public static string IAmPrinting(IInterface1 someobj)
        {
            return someobj.ToString();
        }
    }
    public class Realization : AbstractClass, IInterface1, IInterface2
    {
        override public void WriteAbstract()
        {
            Console.WriteLine("AbstractMethod");
        }
        override public void WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterfaceMethod Abstract");
        }
        void IInterface1.WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterface1Method Realization");
        }

        void IInterface2.WriteInterfaceMethod()
        {
            Console.WriteLine("WriteInterface2Method Realization");
        }

    }
    [Serializable]
    [DataContract]
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
        public string NameCou { get; set; }
        virtual public void WriteVoid()
        {
            Console.WriteLine("Virtual void");
        }
        public Country(string nm)
        {
            this.NameCou = nm;
        }
        public Country()
        {

        }
    }
    [Serializable]
    [DataContract]
    public class Continent : Country
    {
        public string NameCo { get; set; }
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
            this.NameCo = nm;
            this.countrys = cnt;
        }
        public Continent()
        {

        }
    }
    [Serializable]
    [DataContract]
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
        public string NameI { get; set; }
        public Island(string nm)
        {
            this.NameI = nm;
        }
        public Island()
        {

        }
    }
    [DataContract]
    [Serializable]
    public class Land : Continent
    {
        public string NameL { get; set; }
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
            this.NameL = nm;
            this.islands = isl;
            this.continents = cnt;
        }
        public Land()
        {

        }
    }
    [Serializable]
    [DataContract]
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
        public string NameS { get; set; }

        public Sea(string nm)
        {
            this.NameS = nm;
        }
        public Sea()
        {

        }
    }
    [Serializable]
    [DataContract]
    public class Ocean : Sea
    {
        string NameO { get; set; }
        public Sea[] sea;
        public Ocean(string nm, Sea[] s) : base(nm)
        {
            this.NameO = nm;
            this.sea = s;
        }
        public Ocean()
        {

        }
    }
    [DataContract]
    [Serializable]
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
        public Water()
        {

        }
    }
}
