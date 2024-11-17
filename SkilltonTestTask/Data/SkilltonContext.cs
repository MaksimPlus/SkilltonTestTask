using Microsoft.EntityFrameworkCore;
using SkilltonTestTask.Models;
namespace SkilltonTestTask.Data
{
    public class SkilltonContext : DbContext
    {
        public SkilltonContext()
        {
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\EmployeeDB.mdf;Integrated Security=True");
        }
    }
}
