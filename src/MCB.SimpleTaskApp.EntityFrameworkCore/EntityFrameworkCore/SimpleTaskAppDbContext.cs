using Abp.EntityFrameworkCore;
using MCB.SimpleTaskApp.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MCB.SimpleTaskApp.EntityFrameworkCore
{
    public class SimpleTaskAppDbContext : AbpDbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public SimpleTaskAppDbContext(DbContextOptions<SimpleTaskAppDbContext> options) 
            : base(options)
        {

        }
    }
}
