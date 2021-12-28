using System.Text;

namespace lab3
{
    partial class Airline
    {
        
        private bool boolResult(out bool res, object obj)
        {
            Airline p = (Airline)obj;
            res = (
                this.Destination == p.Destination && this.FlightNumber == p.FlightNumber &&
                this.Type == p.Type && this.Time == p.Time && 
                this.Day == p.Day && this.id == p.id
                ) ? true : false;
            return res;
        }

        public override string ToString()
        {
            var line = new StringBuilder();
            line.Append('-', 20);

            return $"Destination: {destination} \nFlightNumber: {flightNumber} \nType: {type} \nTime: {time} \nDay: {day} \nID: {id} + \n{line} ";
        }

        public static void ToStringDESTINATION(Airline[] air, string str)
        {
            for (int i = 0; i < Counter; i++)
            {
                if (air[i].Destination == str)
                {
                    Console.WriteLine(air[i].ToString());
                    
                }
            }
        }

        public static void ToStringDAY(Airline[] air, string str)
        {
            for (int i = 0; i < Counter; i++)
            {
                if (air[i].Day == str) Console.WriteLine(air[i].ToString());

            }
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Airline p = (Airline)obj;
            bool res = true;

            return boolResult(out res, (Airline)obj);
        }

        public static void inputCounter()
        {
            Console.WriteLine("Number of reserved Airlines is " + Counter);
        }

        public static void outputFull(Airline[] air)
        { 
            for (int a = 0; a < Airline.Counter; a++)
            {
                Console.WriteLine($"Info about Airline {a + 1}: ");

                Console.WriteLine(air[a].ToString());
            }
            Console.WriteLine();
        }

        public static void createNewObj(Airline[] air)
        {
            int countNew = Counter ;
            air[countNew] = new Airline();

            Console.WriteLine($"Enter info for Airline {countNew + 1}\n");

            Console.Write("Destination:");
            air[countNew].Destination = Console.ReadLine();

            Console.Write("Flight number:");
            air[countNew].FlightNumber = Int32.Parse(Console.ReadLine());

            Console.Write("Type of plane:");
            air[countNew].Type = Console.ReadLine();

            Console.Write("Flight time:");
            air[countNew].Time = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Day:");
            air[countNew].Day = Console.ReadLine();

            Console.Clear();
        }


    }
}

