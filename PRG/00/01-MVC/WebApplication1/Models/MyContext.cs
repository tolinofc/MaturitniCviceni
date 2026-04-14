using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4b2_jandatomas_db2 ;user=jandatomas;password=123456");
        }

    }

}
