using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class PlanetPolice
    {
        public void FindCountrys(Planet Earth)
        {
            foreach (Continent cont in Earth.land.continents)
            {
                Console.WriteLine(cont.Name);
                foreach (Country country in cont.countrys)
                {
                    Console.WriteLine("\t" + country.Name);
                }
                Console.WriteLine();
            }
        }

        public int CountOfSea(Planet Earth)
        {
            int size_sea = 0;
            foreach (Ocean ocean in Earth.water.oceans)
            {
                Console.WriteLine(ocean.Name + " ocean\n");
                foreach (Sea sea in ocean.sea)
                {
                    Console.WriteLine("\t" + sea.Name + " sea");
                    size_sea++;
                }
                Console.WriteLine();
            }
            return size_sea;
        }

        public void ShowIslands(Planet Earth)
        {
            Console.WriteLine("Islands");
            int index = 0, size = 0;
            foreach (Island island in Earth.land.islands)
            {
                size++;
            }
            string[] names_of_islands = new string[size];
            foreach (Island island in Earth.land.islands)
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
