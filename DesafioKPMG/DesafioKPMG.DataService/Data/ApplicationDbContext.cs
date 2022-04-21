using DesafioKPMG.DataService.Data.EntitiesConfiguration;
using DesafioKPMG.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsDbContextOptions):
            base(optionsDbContextOptions)
        {
        }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<GameResult> GameResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayerConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameResultConfiguration).Assembly);
        }
    }
}
