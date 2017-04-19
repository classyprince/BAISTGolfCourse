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
    public class ApplicantRepository : BaseRepository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(DbContext context) : base(context)
        {
        }

        public List<Applicant> GetAllNewApplicants()
        {
            return DbSet.Include(x => x.ShareHolder1)
                        .Include(x => x.ShareHolder2)
                        .Where(x => x.Status == Common.Enums.ApplicantStatus.Initiated 
                        || x.Status == Common.Enums.ApplicantStatus.UnderReview).ToList();
        }

        public Applicant GetWithMembers(int id)
        {
            return DbSet.Include(x => x.ShareHolder1)
                        .Include(x => x.ShareHolder2)
                        .SingleOrDefault(x => x.ID == id);
        }
    }
}
