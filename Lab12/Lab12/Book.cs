using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Book
    {
        public string Author;
        private string Name;
        public Book()
        {
            Author = "No author";
            Name = "No name";
            WriteInfo();
        }
        public Book(string auth, string name)
        {
            Author = auth;
            Name = name;
            WriteInfo();
        }
        public void WriteInfo()
        {
            Console.WriteLine("{0} from {1}", this.Name, this.Author);
        }
        public int Met(string name)
        {
            Console.WriteLine("Method " + name);
            return 0;
        }
    }
}
