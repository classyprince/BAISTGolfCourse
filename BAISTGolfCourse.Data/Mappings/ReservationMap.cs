using BAISTGolfCourse.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Data.Mappings
{
    public class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {
            HasKey(x => x.ID);

            Property(x => x.DateCreated).IsRequired();

            Property(x => x.Status).IsOptional();
        }
    }
}
