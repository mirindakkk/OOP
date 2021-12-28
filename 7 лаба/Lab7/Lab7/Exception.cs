using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class NullException : Exception //обработать определенным образом только те исключения, которые относятся к классу Null
    {
        public NullException(string message) : base(message)
        {
        }
        public void GetInfo()
        {
            Console.WriteLine("NullException: " + this.Message);
        }
    }

    public class EmptyException : Exception //обработать определенным образом только те исключения, которые относятся к классу Empty
    {

        public EmptyException(string message) : base(message)
        {

        }
        public void GetInfo()
        {
            Console.WriteLine("EmptyException: " + this.Message);
        }
    }
}
