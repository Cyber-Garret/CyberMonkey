using Cyber_Monkey.Model;
using System.Data.Entity;

namespace Cyber_Monkey
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Project> Projects { get; set; }
    }
}
