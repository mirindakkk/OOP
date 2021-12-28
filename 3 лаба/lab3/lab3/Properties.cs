
namespace lab3
{
    partial class Airline
    {
        public static int Counter { get { return counter; } }
        public string Destination
        {
            get { return destination; }
            //set { destination = (value == null || value == "") ? err : value; }
            set
            {
                foreach (string distArr in GoodDestination)
                {
                    if (distArr == value)
                    {
                        destination = value;
                        break;
                    }
                    else
                    {
                        destination = err;
                    }
                }
            }
        }
        public int FlightNumber { get {return flightNumber; } set { flightNumber = value; } }
        public string Type { get { return type; } set { type = value; } }
        public DateTime Time { get { return time; } set { time = value; } }
        public string Day
        {
            get { return day; }
            set
            {
                foreach (string dayArr in Weekday)
                {
                    if (dayArr == value)
                    {
                        day = value;
                        break;
                    }
                    else
                    {
                        day = err;
                    }
                }
            }
        }
    }
}