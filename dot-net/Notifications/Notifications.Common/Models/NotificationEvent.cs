namespace Notifications.Common.Models
{
  public class NotificationEvent
  {
    public string Type { get; set; }
    public CanceledNotificationPayload Data { get; set; }
    public string UserId { get; set; }
  }

  public class CanceledNotificationPayload
  {
    public string Reason { get; set; }
    public string FirstName { get; set; }
    public string AppointmentDateTime { get; set; }
    private string OrganisationName { get; set; }
  }
}