
namespace lab3
{
    partial class Airline
    {
        public Airline(string destination, int flightNumber, string type, DateTime time, string day)
        {
            Destination = destination;
            FlightNumber = flightNumber;
            Type = type;
            Time = time;
            Day = day;
            id = GetHashCode();
            counter++;
        }

        public Airline()
        {
            destination = Destination;
            flightNumber = FlightNumber;
            type = Type;
            time = Time;
            day = Day;
            id = GetHashCode();
            counter++;

        }

        static Airline()
        {
            var typeAirline = typeof(Airline);
            Airline test1 = new Airline(typeAirline);

        }


        private Airline(Type typeAirline, string equal = "")
        {
            Airline testObj = new Airline();

            equal = (testObj.GetType() == typeAirline) ? "Equel" : "No Equel";
            Console.WriteLine($"testObj.GetType() and typeof(Airline) are {equal}\n\n\n");

            counter--;
        }

    }
}