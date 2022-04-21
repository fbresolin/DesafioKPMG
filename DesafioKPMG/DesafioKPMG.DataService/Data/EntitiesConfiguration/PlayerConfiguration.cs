using DesafioKPMG.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.Data.EntitiesConfiguration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.GameResults)
                .WithOne()
                .HasForeignKey(g => g.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
