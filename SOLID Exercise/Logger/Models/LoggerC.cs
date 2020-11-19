using Logger.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class LoggerC : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public LoggerC(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public LoggerC(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders
            => (IReadOnlyCollection<IAppender>) this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.Appenders)
            {
                if (error.Level >= appender.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");

            foreach (IAppender appender in this.Appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
