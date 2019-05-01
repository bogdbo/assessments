using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Notifications.Common.Models;

namespace Notifications.Common.Interfaces
{
  public interface INotificationsService
  {
    Task<List<NotificationModel>> GetAllNotificationsAsync();
    Task<NotificationModel> ProcessEventAsync(NotificationEvent notificationEvent);
    Task<IReadOnlyCollection<NotificationModel>> GetUserNotificationsAsync(string userId);
  }
}