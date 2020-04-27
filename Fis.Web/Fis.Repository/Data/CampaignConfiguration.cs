using Fis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fis.Repository.Data
{
    public class CampaignConfiguration:IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaign");
            builder.Property(c => c.Name).IsRequired().HasMaxLength(500);
            builder.Property(t => t.CreatedDate)
            .IsRequired()
            .HasColumnType("Date")
            .HasDefaultValueSql("GetDate()");
        }
    }
    
    
}
