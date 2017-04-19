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
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(DbContext context) : base(context)
        {
        }

        public List<Reservation> GetListForMember(int memberID)
        {
            return DbSet.Include(x => x.TeeTime).Where(x => x.MemberID == memberID
            && x.TeeTime.StartDate > DateTime.UtcNow).ToList();
        }

        public List<Reservation> GetNormalListForMember(int memberID)
        {
            return DbSet.Include(x => x.TeeTime).Where(x => x.MemberID == memberID).ToList();
        }

        public Reservation GetWithGolfCourse(int id)
        {
            return DbSet.Include(x => x.TeeTime.GolfCourse).Where(x => x.ID == id).SingleOrDefault();
        }

        public List<Reservation> GetListReportForMember(int memberID)
        {
            return DbSet.Include(x => x.TeeTime).ToList();
        }
    }
}
