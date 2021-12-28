using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region 5 лабораторная
                Console.WriteLine("Lab5");
                Sea sea1 = new Sea("Baltic");
                Sea sea2 = new Sea("Nordic");
                Sea[] seas1 = { sea1, sea2 };
                Ocean ocean1 = new Ocean("Atlantic", seas1);

                Sea sea3 = new Sea("White");
                Sea sea4 = new Sea("Norwegian");
                Sea[] seas2 = { sea3, sea4 };
                Ocean ocean2 = new Ocean("Arctic", seas2);

                Ocean[] oceans = { ocean1, ocean2 };

                Water water = new Water(oceans, "");

                Country country1 = new Country("England");
                Country country2 = new Country("Germany");
                Country[] countrys1 = { country1, country2 };
                Continent continent1 = new Continent("Europe", countrys1);

                Country country3 = new Country("USA");
                Country country4 = new Country("Canada");
                Country[] countrys2 = { country3, country4 };
                Continent continent2 = new Continent("North America", countrys2);
                Continent[] continents = { continent1, continent2 };

                Island island1 = new Island("Sumatra");
                Island island2 = new Island("Schpicbergen");
                Island island3 = new Island("Corsika");
                Island[] islands = { island1, island2, island3 };

                Land land = new Land(continents, islands, "Earth");

                Realization real = new Realization();
                real.WriteAbstract();
                real.WriteInterfaceMethod();

                Interface1 i1 = new Realization();
                i1.WriteInterfaceMethod();
                Interface2 i2 = new Realization();
                i2.WriteInterfaceMethod();

                AbstractClass a1 = new Realization();
                a1.WriteInterfaceMethod();

                ((Interface1)real).WriteInterfaceMethod();
                ((Interface2)real).WriteInterfaceMethod();

                AbstractClass abstr1 = real as Realization;
                abstr1.WriteInterfaceMethod();
                Interface1 i11 = real as Realization;
                Interface2 i22 = real as Realization;
                i11.WriteInterfaceMethod();
                i22.WriteInterfaceMethod();

                Console.WriteLine(Printer.IAmPrinting(i1));
                Console.WriteLine(Printer.IAmPrinting(i11));
                #endregion

                #region 6 лабораторная
                Console.WriteLine("\n-------------------------------------\nLab6");
                Planet Earth = new Planet(water, land, "Earth");

                PlanetPolice control = new PlanetPolice();
                
                control.FindCountrys(continent1);

                Console.WriteLine("Count of seas = " + control.CountOfSea(Earth) + "\n");

                control.ShowIslands(Earth);
                #endregion

                Console.WriteLine("\n-------------------------------------\nLab7");
                Planet Mars = new Planet();
                // Console.WriteLine("Count of seas = " + control.CountOfSea(Mars) + "\n");
                Water wt = new Water();
                Land ld = new Land();
                Planet Mercury = new Planet(wt, ld, "Mercury");
                //Console.WriteLine("Count of seas = " + control.CountOfSea(Mercury) + "\n");

                //Ocean oc1 = new Ocean("ex");
                //Ocean[] ExOcean = { oc1 };
                //Planet Yupiter = new Planet(wt, ld, "Yupiter");
                //Yupiter.water.oceans = ExOcean;
                //Console.WriteLine("Count of seas = " + control.CountOfSea(Yupiter) + "\n");
                //control.ShowIslands(Yupiter);
                Console.WriteLine("No errors");
            }
            catch (EmptyException exception)
            {
                exception.GetInfo();
            }
            catch (NullException exception)
            {
                exception.GetInfo();
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
            }
            finally
            {
                Console.WriteLine("Этот блок выполнится обязательно");
            }

        }
    }
}
