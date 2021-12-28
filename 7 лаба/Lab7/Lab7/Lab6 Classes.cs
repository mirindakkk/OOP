using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Planet
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

        public Planet(Water wt, Land ld, string nm)
        {
            this.water = wt;
            this.land = ld;
            this.Name = nm;
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
    public class PlanetPolice
    {
        public void FindCountrys(Continent continent)
        {
            Console.WriteLine(continent.Name);
            foreach (Country country in continent.countrys)
            {
                Console.WriteLine("\t" + country.Name);
            }
            Console.WriteLine();
        }

        public int CountOfSea(Planet planet)
        {
            int size_sea = 0;
            if (planet.Name == null)
            {
                throw new NullException("Не задано имя планеты");
            }
            Console.WriteLine(planet.Name);
            if (planet.water.oceans == null)
            {
                throw new NullException("На этой планете нет океанов");
            }
            foreach (Ocean ocean in planet.water.oceans)
            {
                Console.WriteLine(ocean.Name + " ocean\n");
                for (int i = 0; i < ocean.sea.Length; i++)
                {
                    Console.WriteLine("\t" + ocean.sea[i].Name + " sea");
                    size_sea++;
                }
                Console.WriteLine();
            }
            if (size_sea == 0)
            {
                throw new EmptyException("На этой планете нет морей\n");
            }
            return size_sea;
        }

        public void ShowIslands(Planet planet)
        {
            if (planet.Name == null)
            {
                throw new NullException("Не задано имя планеты");
            }
            Console.WriteLine(planet.Name);
            Console.WriteLine("Islands");
            int index = 0, size = 0;
            if (planet.land.islands == null)
            {
                throw new EmptyException("На этой планете нет островов");
            }
            foreach (Island island in planet.land.islands)
            {
                size++;
            }
            string[] names_of_islands = new string[size];
            foreach (Island island in planet.land.islands)
            {
                names_of_islands[index++] = island.Name;
            }
            Array.Sort(names_of_islands);
            for (int i = 0; i < names_of_islands.Length; i++)
            {
                Console.WriteLine("\t" + names_of_islands[i]);
            }
        }
    }

}
