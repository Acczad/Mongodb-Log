using System;
using System.Collections.Generic;

namespace Sana.Log.Abstraction.Model
{
    public class SanaErrorLogModel : SanaBaseLogDataModel
    {
        private SanaErrorLogModel(string message, string systemName) : base(LogLevel.Error, message, systemName)
        {
            Messages = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Messages { get; private set; }
        public int ErrorCode { get; private set; }
        public StackTraceInfo StackTrace { get; set; }

        public static SanaErrorLogModel GetInstance(string message, string systemName)
        {
            return new SanaErrorLogModel(message, systemName);
        }
        public void AddMultiCulturalMessages(Dictionary<string, string> messages)
        {
            if (messages?.Count == null) return;
            Messages = messages;
        }
        public void AddException(int erroCode, Exception exception)
        {
            ErrorCode = erroCode;
            StackTrace = StackTraceInfo.GetInstance(exception);
        }
    }
}
