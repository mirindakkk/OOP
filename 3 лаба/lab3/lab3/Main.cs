using System;
using System.Text;

namespace lab3
{
    partial class Airline
    {
        //Cодержит : Пункт назначения, Номер рейса, Тип самолета, Время вылета, Дни недели.

        private string destination;
        private int flightNumber ;
        private string type;
        private DateTime time;
        private string day;
        private readonly int id;

        private static int counter = 0 ;
        private const string err = "Error";

        private readonly string[] Weekday =
{
            "Monday",
            "Tuesday",
            "Friday",
        };

        private readonly string[] GoodDestination =
        {
            "London",
            "Moskow",
        };

    } 
    class Program
    {
        static void Main(string[] args)
        {
           int size = 5;
            Airline[] path = new Airline[size];

            path[0] = new Airline("Moskow", 1234 ,"usual", new DateTime(2022,7,6) ,"Monday");
            path[1] = new Airline("Moskow", 1234, "usual", new DateTime(2022, 7, 6), "Tuesday");
            path[2] = new Airline("London", 1234, "usual", new DateTime(2022, 7, 6), "Tuesday");
            path[3] = new Airline("London", 1234, "usual", new DateTime(2022, 7, 6), "Tuesday");

            var clone0 = new { path[0].Destination, path[0].FlightNumber, path[0].Type, path[0].Time, path[0].Day };// клонируем сюда нулевой эл
           

            Airline.createNewObj(path);
            Console.WriteLine("Clone obj 1 with Anonymous type : \n" + clone0.ToString() + "\n");
            Airline.outputFull(path); //печатаем массив пас

            Airline.inputCounter();//выводит текущий каунтер
            Console.WriteLine("path[0].Equals(path[1])" + path[0].Equals(path[1]));// сравнивает по полям
            Console.WriteLine("path[0].Equals(path[0])" + path[0].Equals(path[0]));

            Console.WriteLine("\nReadKey to output inf by search\n");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Output information about Airlines with Destination Moskow");
            Airline.ToStringDESTINATION(path, "Moskow"); // выведет все аирленс для москоу
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Output information about Airlines In Tuesday ");
            Airline.ToStringDAY(path, "Tuesday");

         

        }
    }
}