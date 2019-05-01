using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Notifications.DataAccess.Config
{
  public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NotificationsDbContext>
  {
    public NotificationsDbContext CreateDbContext(string[] args)
    {
      var builder = new DbContextOptionsBuilder<NotificationsDbContext>();
      builder.UseSqlServer("Server=localhost;Database=notifications-db;User Id=sa;Password=Password_123^;");
      return new NotificationsDbContext(builder.Options);
    }
  }
}