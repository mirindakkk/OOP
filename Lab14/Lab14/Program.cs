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
    class Program
    {
        static void Main(string[] args)
        {
            #region 5 лабораторная
            //Console.WriteLine("Lab5");
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
            //real.WriteAbstract();
            //real.WriteInterfaceMethod();

            IInterface1 i1 = new Realization();
            //i1.WriteInterfaceMethod();
            IInterface2 i2 = new Realization();
            //i2.WriteInterfaceMethod();

            AbstractClass a1 = new Realization();
            //a1.WriteInterfaceMethod();

            //((IInterface1)real).WriteInterfaceMethod();
            //((IInterface2)real).WriteInterfaceMethod();

            AbstractClass abstr1 = real as Realization;
            //abstr1.WriteInterfaceMethod();
            IInterface1 i11 = real as Realization;
            IInterface2 i22 = real as Realization;
            //i11.WriteInterfaceMethod();
            //i22.WriteInterfaceMethod();

            //Console.WriteLine(Printer.IAmPrinting(i1));
            //Console.WriteLine(Printer.IAmPrinting(i11));
            //Console.WriteLine();
            #endregion
            try
            {
                //  Console.WriteLine("Lab6");
                Planet Earth = new Planet(water, land, "Earth");

                BinaryFormatter bf = new BinaryFormatter();
                string path;
                using (FileStream stream = new FileStream(path = "E:\\2 курс\\1 сем\\ООП\\Lab14\\Lab14\\bin\\Debug\\14.bin", FileMode.Create))
                {
                    bf.Serialize(stream, Earth);
                }
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    Planet planet = (Planet)bf.Deserialize(stream);
                    Console.WriteLine("Binary:\n\tName: " + planet.Name);
                }

                SoapFormatter sf = new SoapFormatter();
                using (FileStream stream = new FileStream(path = "E:\\2 курс\\1 сем\\ООП\\Lab14\\Lab14\\bin\\Debug\\14.soap", FileMode.Create))
                {
                    sf.Serialize(stream, Earth);
                }
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    Planet planet = (Planet)sf.Deserialize(stream);
                    Console.WriteLine("Soap:\n\tName: " + planet.Name);
                }

                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Planet));
                using (FileStream stream = new FileStream(path = "E:\\2 курс\\1 сем\\ООП\\Lab14\\Lab14\\bin\\Debug\\14.json", FileMode.Create))
                {
                    jsonFormatter.WriteObject(stream, Earth);
                }
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    Planet planet = (Planet)jsonFormatter.ReadObject(stream);
                    Console.WriteLine("JSON:\n\tName: " + planet.Name);
                }

                XmlSerializer xs = new XmlSerializer(typeof(Planet));
                using (FileStream stream = new FileStream(path = "E:\\2 курс\\1 сем\\ООП\\Lab14\\Lab14\\bin\\Debug\\14.xml", FileMode.Create))
                {
                    xs.Serialize(stream, Earth);
                }
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    Planet planet = (Planet)xs.Deserialize(stream);
                    Console.WriteLine("Xml:\n\tName: " + planet.Name);
                }


                Planet Mars = new Planet(water, land, "Mars");
                Planet Yupiter = new Planet(water, land, "Yupiter");
                Planet Mercury = new Planet(water, land, "Mercury");
                Earth.size = 2;
                Mars.size = 2;
                Yupiter.size = 3;
                Mercury.size = 1;
                Planet[] SunSystem = { Earth, Mars, Yupiter, Mercury };
                XmlSerializer xmls = new XmlSerializer(typeof(Planet[]));
                using (FileStream stream = new FileStream(path = "E:\\2 курс\\1 сем\\ООП\\Lab14\\Lab14\\bin\\Debug\\14Task2.xml", FileMode.Create))
                {
                    xmls.Serialize(stream, SunSystem);
                }
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    Console.WriteLine("Xml task2");
                    Planet[] planets = (Planet[])xmls.Deserialize(stream);
                    foreach (Planet planet in planets)
                    {
                        Console.WriteLine("\tName: " + planet.Name);
                    }
                }


                XmlDocument xd = new XmlDocument();
                xd.Load(path);
                XmlElement xr = xd.DocumentElement;
                Console.WriteLine("\nName - Earth: ");
                XmlNode childnode = xr.SelectSingleNode("Planet[Name='Earth']");
                if (childnode != null)
                {
                    Console.WriteLine(childnode.OuterXml);
                }
                Console.WriteLine("\nsize = 2: ");
                XmlNodeList childnodes = xr.SelectNodes("Planet[size='2']");
                foreach (XmlNode n in childnodes)
                {
                    Console.WriteLine(n.OuterXml);
                }

                Console.WriteLine("\nLINQ to XML");
                XDocument xdoc = new XDocument();
                // создаем первый элемент
                XElement team = new XElement("team");
                // создаем атрибут
                XAttribute team_name_attr = new XAttribute("name", "Arsenal");
                XElement team_league_elem = new XElement("league", "BPL");
                XElement team_coach_elem = new XElement("coach", "Arsen Wenger");
                // добавляем атрибут и элементы в первый элемент
                team.Add(team_name_attr);
                team.Add(team_league_elem);
                team.Add(team_coach_elem);

                // создаем второй элемент
                XElement team2 = new XElement("team");
                XAttribute team2_name_attr = new XAttribute("name", "Morecambe");
                XElement team2_league_elem = new XElement("league", "League One");
                XElement team2_coach_elem = new XElement("coach", "Andrei Chayeuski");
                // добавляем атрибут и элементы во второй элемент
                team2.Add(team2_name_attr);
                team2.Add(team2_league_elem);
                team2.Add(team2_coach_elem);

                // создаем корневой элемент
                XElement teams = new XElement("teams");
                // добавляем в корневой элемент
                teams.Add(team);
                teams.Add(team2);
                // добавляем корневой элемент в документ
                xdoc.Add(teams);
                //сохраняем документ
                xdoc.Save("E:\\2 курс\\1 сем\\ООП\\Lab14\\Lab14\\bin\\Debug\\teams.xml");
                
                var items = from xe in xdoc.Elements("teams").Elements("team")
                            where xe.Element("league").Value == "BPL"
                            select new Team
                            {
                                Name = xe.Attribute("name").Value,
                                Coach = xe.Element("coach").Value
                            };
                foreach (var item in items)
                {
                    Console.WriteLine("\t{0} - {1}", item.Name, item.Coach);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}