using System.Collections.Generic;
using System.Threading.Tasks;
using Notifications.Common.Models;

namespace Notifications.Common.Interfaces
{
  public interface INotificationsAccess
  {
    Task<List<NotificationModel>> GetAllNotificationsAsync();
    Task<List<NotificationModel>> GetUserNotificationsAsync(string userId);
    Task<NotificationTemplate> GetCanceledNotificationTemplateAsync();
    Task<NotificationModel> AddNotificationAsync(NotificationModel notificationModel);
  }
}