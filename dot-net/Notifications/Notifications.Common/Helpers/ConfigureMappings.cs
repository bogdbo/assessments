using AutoMapper;
using Notifications.Common.Models;
using Notifications.Common.Models.Entities;

namespace Notifications.Common.Helpers
{
  public class ConfigureMappings
  {
    public static IMapper GetMapper()
    {
      var mapperConfiguration = new MapperConfiguration(config =>
      {
        config.CreateMap<NotificationModel, NotificationEntity>().ReverseMap();
        config.CreateMap<NotificationTemplate, NotificationModel>()
          .ForMember(dest => dest.UserId, opt => opt.Ignore());
      });

      return mapperConfiguration.CreateMapper();
    }
  }
}