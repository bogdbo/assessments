using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Notifications.Common.Interfaces;
using Notifications.Common.Models;

namespace Notifications.Services
{
  public class NotificationsService : INotificationsService
  {
    private readonly INotificationsAccess notificationsAccess;
    private readonly IMapper mapper;

    public NotificationsService(INotificationsAccess notificationsAccess, IMapper mapper)
    {
      this.notificationsAccess = notificationsAccess;
      this.mapper = mapper;
    }

    public async Task<List<NotificationModel>> GetAllNotificationsAsync()
    {
      return await notificationsAccess.GetAllNotificationsAsync();
    }

    public async Task<NotificationModel> ProcessEventAsync(NotificationEvent notificationEvent)
    {
      if (notificationEvent == null)
      {
        throw new ArgumentNullException();
      }

      if (notificationEvent.Data == null)
      {
        throw new ValidationException("An event's 'data' cannot be null");
      }

      if (string.IsNullOrWhiteSpace(notificationEvent.UserId))
      {
        throw new ValidationException("An event's user id cannot be null or empty");
      }

      if (string.IsNullOrWhiteSpace(notificationEvent.Type))
      {
        throw new ValidationException("An event's type cannot be null or empty");
      }

      // todo: building the new model should be done in a separate service
      var template = await notificationsAccess.GetCanceledNotificationTemplateAsync();
      if (template == null)
      {
        throw new InvalidOperationException("Cannot find template in db");
      }
      
      var model = mapper.Map<NotificationModel>(template);
      model.Id = Guid.NewGuid();
      model.Body = notificationEvent.Data.Reason;
      model.UserId = notificationEvent.UserId;

      return await notificationsAccess.AddNotificationAsync(model);
    }

    public async Task<IReadOnlyCollection<NotificationModel>> GetUserNotificationsAsync(string userId)
    {
      if (string.IsNullOrWhiteSpace(userId))
      {
        throw new ArgumentNullException();
      }

      return await notificationsAccess.GetUserNotificationsAsync(userId);
    }
  }
}