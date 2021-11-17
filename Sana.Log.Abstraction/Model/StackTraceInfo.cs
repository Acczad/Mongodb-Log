using System;
using System.Diagnostics;

namespace Sana.Log.Abstraction.Model
{
    public class StackTraceInfo
    {

        public string FileName { get; private set; } = "";
        public string Method { get; private set; } = "";
        public string LineNumber { get; private set; } = "";
        public string StackTrace { get; private set; } = "";

        public static StackTraceInfo GetInstance(Exception exception)
        {

            if (exception == null) return null;

            var traceInfo = new StackTraceInfo();


            traceInfo.StackTrace = exception.ToString();

            var footPrints = new StackTrace(exception, true);
            var frames = footPrints.GetFrames();


            foreach (var frame in frames)
            {
                if (frame == null) continue;
                if (frame.GetFileLineNumber() < 1)
                    continue;

                traceInfo.FileName += $"»{frame.GetFileName()}";
                traceInfo.Method += $"»{frame.GetMethod()?.Name}";
                traceInfo.LineNumber += $"»{ frame.GetFileLineNumber()}";
            }

            return traceInfo;
        }
    }
}
