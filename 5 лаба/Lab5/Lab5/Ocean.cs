using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Ocean : Sea
    {
        new string Name { get; set; }
        Sea[] sea;
        public Ocean(string nm, Sea[] s) : base(nm)
        {
            this.Name = nm;
            this.sea = s;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Ocean ocean = (Ocean)obj;
            return (this.Name == ocean.Name);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //метод GetType не переопределяется
        public sealed override string ToString()
        {
            return this.Name;
        }
    }
}
