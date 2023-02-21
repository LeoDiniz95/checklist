using checklist_api.Models;
using Microsoft.EntityFrameworkCore;

namespace checklist_api.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<CheckListDM> CheckListDMs { get; set; }
    }
}
