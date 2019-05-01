using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notifications.Common.Interfaces;
using Notifications.Common.Models;
using Notifications.Common.Models.Entities;

namespace Notifications.DataAccess.Access
{
  public class NotificationsAccess : INotificationsAccess
  {
    private readonly NotificationsDbContext dbContext;
    private readonly IMapper mapper;

    public NotificationsAccess(NotificationsDbContext dbContext, IMapper mapper)
    {
      this.dbContext = dbContext;
      this.mapper = mapper;
    }

    public async Task<List<NotificationModel>> GetAllNotificationsAsync()
    {
      var notifications = await dbContext.Notifications.ToListAsync();
      return mapper.Map<List<NotificationModel>>(notifications);
    }

    public async Task<List<NotificationModel>> GetUserNotificationsAsync(string userId)
    {
      var notifications =
        await dbContext.Notifications.Where(n => n.UserId == userId).ToListAsync();

      return mapper.Map<List<NotificationModel>>(notifications);
    }

    public async Task<NotificationTemplate> GetCanceledNotificationTemplateAsync()
    {
      return await dbContext.Templates.FirstOrDefaultAsync(t =>
        t.EventType == NotificationEventTypes.EventCancelled);
    }

    public async Task<NotificationModel> AddNotificationAsync(NotificationModel notificationModel)
    {
      // todo: more validation
      if (notificationModel == null)
      {
        throw new ArgumentNullException();
      }

      await dbContext.Notifications.AddAsync(mapper.Map<NotificationEntity>(notificationModel));
      await dbContext.SaveChangesAsync();
      
      return notificationModel;
    }
  }
}