using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Data.Models
{
    public class GolfCourse
    {
        public GolfCourse()
        {
            TeeTimes = new HashSet<TeeTime>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public double Rating { get; set; }
        public int Slope { get; set; }
        public DateTime YearFounded { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<TeeTime> TeeTimes { get; set; }
    }
}
