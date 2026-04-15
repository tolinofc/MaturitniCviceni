using Microsoft.EntityFrameworkCore;

namespace JizdniRad.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Line> Lines { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<LineStop> LineStops { get; set; }
        public DbSet<Departure> Departures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4b2_jandatomas_db2;user=jandatomas;password=123456");
        }

    }

}
