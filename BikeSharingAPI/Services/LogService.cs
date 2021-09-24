using System;
using System.IO;
using BikeSharingAPI.Enums;
using BikeSharingAPI.Models;
using BikeSharingAPI.Services.IServices;

namespace BikeSharingAPI.Services
{
    public class LogService : ILogService
    {
        public bool Log(string message, EnumLogLevel logLevel = EnumLogLevel.INFORMATION)
        {
            message = logLevel.ToString() + Environment.NewLine + DateTime.Now + Environment.NewLine + message + Environment.NewLine + SharedData.LogSeperator;

                string directoryName = $"Logs";
                if (!Directory.Exists(directoryName))
                    Directory.CreateDirectory(directoryName);

                string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                fileName = $"{directoryName}/{fileName}.Log";
                

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }

                FileStream objFilestream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                objStreamWriter.WriteLine(message);
                objStreamWriter.Close();
                objFilestream.Close();
                return true;
        }
    }
}