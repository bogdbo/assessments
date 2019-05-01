using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Notifications.Middlewares
{
  public class GlobalExceptionHandler
  {
    private readonly RequestDelegate next;

    public GlobalExceptionHandler(RequestDelegate next)
    {
      this.next = next;
    }

    public async Task Invoke(HttpContext context, ILogger<GlobalExceptionHandler> logger)
    {
      try
      {
        await next(context);
      }
      catch (ValidationException ex)
      {
        await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
        logger.LogWarning(ex, nameof(ValidationException));
      }
    }

    private static async Task HandleExceptionAsync(HttpContext context, HttpStatusCode code,
      object value = null)
    {
      context.Response.StatusCode = (int) code;
      if (value != null)
      {
        if (value is string stringValue)
        {
          await context.Response.WriteAsync(stringValue);
        }
        else
        {
          context.Response.ContentType = "application/json";
          await context.Response.WriteAsync(JsonConvert.SerializeObject(value, SerializerSettings));
        }
      }
    }

    private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
    {
      ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
  }
}