using Microsoft.EntityFrameworkCore;
using MvcRacunala.Models;

namespace MvcRacunala.Data
{
    public class MvcRacunalaContext : DbContext
    {
        public MvcRacunalaContext(DbContextOptions<MvcRacunalaContext> options)
            : base(options)
        {
        }

        public DbSet<Racunala> Racunala { get; set; }
    }
}