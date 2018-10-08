using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using MiniProfilerDemo.Models;

namespace MVCDemo.Mapper
{
    internal class InstallMapper : EntityTypeConfiguration<Install>
    {
        internal InstallMapper()
        {
            this.ToTable("Install");
            this.HasKey(t => t.ID );

            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}