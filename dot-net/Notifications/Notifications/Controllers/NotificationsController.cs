using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notifications.Common.Interfaces;
using Notifications.Common.Models;

namespace Notifications.Controllers
{
  [Route("api/notifications")]
  [ApiController]
  public class NotificationsController : ControllerBase
  {
    private readonly INotificationsService notificationsService;

    public NotificationsController(INotificationsService notificationsService)
    {
      this.notificationsService = notificationsService;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<NotificationModel>> Get([FromQuery] string userId)
    {
      if (!string.IsNullOrEmpty(userId))
      {
        return await notificationsService.GetUserNotificationsAsync(userId);
      }

      return await notificationsService.GetAllNotificationsAsync();
    }

    [HttpPost]
    public async Task<NotificationModel> Create([FromBody] NotificationEvent notificationEvent)
    {
      return await notificationsService.ProcessEventAsync(notificationEvent);
    }
  }
}