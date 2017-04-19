using BAISTGolfCourse.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Data.Mappings
{
    public class PlayerScoreMap : EntityTypeConfiguration<PlayerScore>
    {
        public PlayerScoreMap()
        {
            HasKey(x => x.ID);

            Property(x => x.HandicapID).IsOptional();

        }
    }

    public class HoleMap : EntityTypeConfiguration<Hole>
    {
        public HoleMap()
        {
            HasKey(x => x.ID);

            Property(x => x.Name).HasMaxLength(80);

            HasMany(x => x.PlayerScores)
                    .WithRequired(x => x.Hole)
                    .HasForeignKey(x => x.HoleID)
                    .WillCascadeOnDelete(false);
        }
    }

    public class HandicapMap : EntityTypeConfiguration<Handicap>
    {
        public HandicapMap()
        {
            HasKey(x => x.ID);

            Property(x => x.Name).HasMaxLength(80);

            HasMany(x => x.PlayerScores)
                    .WithOptional(x => x.Handicap)
                    .HasForeignKey(x => x.HandicapID)
                    .WillCascadeOnDelete(false);
        }
    }

    public class GolfCourseMap : EntityTypeConfiguration<GolfCourse>
    {
        public GolfCourseMap()
        {
            HasKey(x => x.ID);

            Property(x => x.Name).HasMaxLength(300);

            Property(x => x.Rating).IsRequired();

            Property(x => x.Slope).IsRequired();

            Property(x => x.Address).HasMaxLength(150);

            Property(x => x.City).HasMaxLength(100);

            Property(x => x.Country).HasMaxLength(150);

            HasMany(x => x.TeeTimes)
                    .WithRequired(x => x.GolfCourse)
                    .HasForeignKey(x => x.GolfCourseID)
                    .WillCascadeOnDelete(false);
        }
    }
    
}