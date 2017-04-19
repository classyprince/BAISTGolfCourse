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
    public class PlayerScoreRepository : BaseRepository<PlayerScore>, IPlayerScoreRepository
    {
        public PlayerScoreRepository(DbContext context) : base(context)
        {
        }

        public List<PlayerScore> GetAllPlayerScores()
        {
            return DbSet
                .Include(x => x.Member)
                .Include(x => x.Handicap)
                .OrderBy(x => x.Member.FirstName).ToList();
        }
    }
}
