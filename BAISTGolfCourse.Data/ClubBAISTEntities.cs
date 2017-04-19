using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.Data.Mappings;

namespace BAISTGolfCourse.Data
{
    public partial class ClubBAISTEntities : DbContext
    {
        public ClubBAISTEntities()
        : base("name=ClubBAISTEntities")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<TeeTime> TeeTimes { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Hole> Holes { get; set; }
        public virtual DbSet<GolfCourse> GolfCourses { get; set; }
        public virtual DbSet<PlayerScore> PlayerScores { get; set; }
        public virtual DbSet<Handicap> Handicaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicantMap());
            modelBuilder.Configurations.Add(new MemberMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new ReservationMap());
            modelBuilder.Configurations.Add(new TeeTimeMap());
            modelBuilder.Configurations.Add(new HoleMap());
            modelBuilder.Configurations.Add(new PlayerScoreMap());
            modelBuilder.Configurations.Add(new GolfCourseMap());
            modelBuilder.Configurations.Add(new HandicapMap());
        }
    }
}
