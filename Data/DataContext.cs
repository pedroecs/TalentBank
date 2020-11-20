using Microsoft.EntityFrameworkCore;
using TalentBankBackend.Models;

namespace TalentBankBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }
                  
        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<Vacancies> Vacancies { get; set; }
    }

}