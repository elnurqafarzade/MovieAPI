using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PB201MovieApp.Core.Entities;

namespace PB201MovieApp.DAL.Configurations
{  
        public class GenreConfiguration : IEntityTypeConfiguration<Genre>
        {
            public void Configure(EntityTypeBuilder<Genre> builder)
            {
                builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
                //builder.HasMany(x => x.Movies).WithOne(x => x.Genre).HasForeignKey(x => x.GenreId);
            }
        }
    }

}
}
