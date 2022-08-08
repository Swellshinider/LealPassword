using System;

namespace LealPassword.Diagnostics
{
    public sealed class Diagnostic
    {
        internal Diagnostic(DiagnosticType type, string from, string message, Exception exception = null)
        {
            Type = type;
            From = from;
            Message = message;
            GeneratedTime = DateTime.Now.Ticks;
            Exception = exception;
        }

        public DiagnosticType Type { get; }
        public string From { get; }
        public string Message { get; }
        public long GeneratedTime { get; }
        public Exception Exception { get; }

        public override string ToString()
        {
            var dt = new DateTime(GeneratedTime);
            var dtf = $"[{dt.ToShortDateString()}, {dt.ToShortTimeString()}.{dt.Millisecond}]";

            return Exception == null
                ? $"{dtf} {Type}, {From}(): {Message}"
                : $"{dtf} {Type}, {From}(): {Message}\n" +
                $"Exception: {Exception.Message}\n" +
                $"InnerException: {Exception.InnerException}\n" +
                $"StackTrace: {Exception.StackTrace}";
        }
    }
}