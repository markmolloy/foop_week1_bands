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
        public DateTime Relased { get; set; }

        public override string ToString()
        {
            ///basic
            //return string.Format("{0} - {1} - ${2}m", Name, Year, Sales);

            //with datetime released date
            return string.Format("{0} - {1} years ago - ${2}m", Name, GetAge(Relased, DateTime.Now), Sales);
        }

        private int GetAge(DateTime release, DateTime now)
        {
            int age = now.Year - release.Year;
            if (now.Month < release.Month || (now.Month == release.Month && now.Day < release.Day))
            { age--; }
            return age;
        }

        
    }
}
