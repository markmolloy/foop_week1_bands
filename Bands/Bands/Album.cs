using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bands
{
    public class Album
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Sales { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - ${2}m", Name, Year, Sales);
        }
    }
}
