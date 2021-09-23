using BikeSharingAPI.Enums;

namespace BikeSharingAPI.Services.IServices
{
    public interface ILogService
    {
         bool Log(string message, EnumLogLevel logLevel = EnumLogLevel.INFORMATION);
    }
}