using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.Repositories.BaseRepository;
using BAISTGolfCourse.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Repositories.Repositories
{
    public class HandicapRepository : BaseRepository<Handicap>, IHandicapRepository
    {
        public HandicapRepository(DbContext context) : base(context)
        {
        }

    }
}
