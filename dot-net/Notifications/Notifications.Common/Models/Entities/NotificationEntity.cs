using System;

namespace Notifications.Common.Models.Entities
{
  public class NotificationEntity
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string EventType { get; set; }
    public string UserId { get; set; }
  }
}