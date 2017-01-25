using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bands
{
    public abstract class Band:IComparable
    {
        //band has a name, year started, members, and albums
        public string Name { get; set; }
        public int Year { get; set; }
        public string[] Members { get; set; }
        public Album[] Albums { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Name, this.GetType().Name);
        }

        public int CompareTo(object obj)
        {
            Band b = (Band)obj;
            return this.Name.CompareTo(b.Name);
        }
    }

    public class Rock : Band{ }
    public class Pop : Band { }
    public class Indie : Band { }
}
