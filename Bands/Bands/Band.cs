using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public void WriteToFile()
        {
            //string array to hold all info
            int length = Members.Length + Albums.Length + 2;
            string[] bandInfo = new string[length];
            //fill it with band's details
            bandInfo[0] = Name;
            for (int i = 0; i < Members.Length; i++)
            {
                bandInfo[i + 1] = Members[i];
            }
            for (int i = 0; i < Albums.Length; i++)
            {
                bandInfo[i + 1 + Members.Length] = Albums[i].ToString();
            }
            //file name
            string fileName = string.Format("Band-{0}.txt", Name);
            //write
            File.WriteAllLines(fileName, bandInfo);
        }
    }

    public class Rock : Band{ }
    public class Pop : Band { }
    public class Indie : Band { }
}
