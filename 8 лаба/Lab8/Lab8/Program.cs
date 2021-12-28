using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<String> l = new CollectionType<String>("Sasha", 0);
                CollectionType<String> a1 = new CollectionType<String>("Misha");
                CollectionType<String> a2 = new CollectionType<String>("Jenya");
                CollectionType<String> a3 = new CollectionType<String>("Sergei");
                CollectionType<String> a4 = new CollectionType<String>("Maksim");
                l.Add(a1);
                l.Add(a2);
                l.Add(a3);
                l.Add(a4);
                l.Show();

                CollectionType<Object> n = new CollectionType<Object>(1, 1);
                CollectionType<Object> n1 = new CollectionType<Object>(2);
                CollectionType<Object> n2 = new CollectionType<Object>(3);
                CollectionType<Object> n3 = new CollectionType<Object>(4);
                n.Add(n1);
                n.Add(n2);
                n.Add(n3);
                n.Show();
                n.Delete();
                n.Show();

                CollectionType<Country> country1 = new CollectionType<Country>(new Country("England"), 2);
                CollectionType<Country> country2 = new CollectionType<Country>(new Country("Germany"));
                country1.Add(country2);
                country1.Show();
                FileHandler<Country>.AddToFile(country1, country1);
                FileHandler<Country>.AddFromFile(country1);
                country1.Show();
                Console.WriteLine("Without errors");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                Console.WriteLine("Done!");
                Console.ReadKey();
            }
        }
    }
}