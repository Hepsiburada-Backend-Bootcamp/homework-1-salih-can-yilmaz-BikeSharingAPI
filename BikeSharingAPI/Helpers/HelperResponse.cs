using System;
using System.Net;
using System.Text.Json;
using BikeSharingAPI.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BikeSharingAPI.Helpers
{
    public static class HelperResponse
    {
        public static IActionResult GenerateResponse<T>(
            EnumResponseFormat format,
            HttpStatusCode statusCode,
            T data,
            bool isRawData = false
        )
        {
            if (data != null)
            {
                string content = String.Empty;
                switch (format)
                {
                    case EnumResponseFormat.JSON:
                        if (!isRawData)
                            content = JsonSerializer.Serialize(data);
                        else
                            content = data.ToString();

                        return new ContentResult
                        {
                            StatusCode = Convert.ToInt32(statusCode),
                            ContentType = "application/json",
                            Content = content
                        };

                    case EnumResponseFormat.XML:
                        if (!isRawData)
                            content = HelperXML.TOXML<T>(data);
                        else
                            content = data.ToString();

                        return new ContentResult
                        {
                            StatusCode = Convert.ToInt32(statusCode),
                            ContentType = "application/xml",
                            Content = content,
                        };

                    case EnumResponseFormat.HTML:
                        return new ContentResult
                        {
                            StatusCode = Convert.ToInt32(statusCode),
                            ContentType = "text/html",
                            Content = data.ToString()
                        };

                    case EnumResponseFormat.TEXT:
                        return new ContentResult
                        {
                            StatusCode = Convert.ToInt32(statusCode),
                            ContentType = "text/plain; charset=UTF-8",
                            Content = data.ToString()
                        };
                    default:
                        break;
                }
            }

            return new ContentResult
            {
                StatusCode = Convert.ToInt32(statusCode)
            };
        }

        public static IActionResult GenerateResponse(
            HttpStatusCode statusCode
        )
        {
            return new ContentResult
            {
                StatusCode = Convert.ToInt32(statusCode)
            };
        }
    }
}