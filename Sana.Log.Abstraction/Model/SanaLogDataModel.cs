using System;
using System.Text.Json;
using System.Collections.Generic;

namespace Sana.Log.Abstraction.Model
{
    public class SanaBaseLogDataModel
    {
        protected SanaBaseLogDataModel(
            LogLevel logLevel,
            string message,
            string systemName)
        {
            Meta = new Dictionary<string, string>();
            CreateDate = DateTime.UtcNow;
            LogLevel = logLevel;
            Message = message;
            SystemName = systemName;
        }

        public string SystemName { get; }
        public string Message { get; }
        public LogLevel LogLevel { get; }
        public DateTimeOffset CreateDate { get; }
        public long UserId { get; private set; }
        public string UserName { get; private set; }


        public Dictionary<string, string> Meta { get; private set; }
        public string RequestData { get; private set; }


        public void AddUser(long userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }

        public void AddIP(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress)) return;

            Meta["IP"] = ipAddress;
        }
        public void AddRequestDto(object data)
        {
            if (data == null) return;

            RequestData = JsonSerializer.Serialize(data);
        }
    }
}
