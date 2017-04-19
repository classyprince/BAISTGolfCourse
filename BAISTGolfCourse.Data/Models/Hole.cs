using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Data.Models
{
    public class Hole
    {
        public Hole()
        {
            PlayerScores = new HashSet<PlayerScore>();
        }
        public int ID { get; set; }
        public string Name { get; set; }       
        public ICollection<PlayerScore> PlayerScores { get; set; }
    }
}
