using Microsoft.EntityFrameworkCore;

namespace Avenga.ASP.NET.CORE.MVC.Database.DataAccess
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options){}
    }
}
