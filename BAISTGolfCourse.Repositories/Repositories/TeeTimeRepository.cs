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
    public class TeeTimeRepository : BaseRepository<TeeTime>, ITeeTimeRepository
    {
        public TeeTimeRepository(DbContext context) : base(context)
        {
        }

        public List<TeeTime> GetList(DateTime startDate, DateTime endDate)
        {
            return DbSet.Include(x => x.Reservations)
                        .Where(x => x.StartDate > DateTime.Now && (x.StartDate >= startDate)
                        && (x.EndDate <= endDate) && x.Reservations.Count < 4)
                        .OrderBy(x => x.StartDate).ToList();
        }

        public TeeTime GetWithMembers(int id)
        {
            return DbSet.Include(x => x.Reservations.Select(y => y.Member))
                        .SingleOrDefault(x => x.ID == id);
        }
    }
}
