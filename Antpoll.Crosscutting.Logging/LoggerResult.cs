using System.Collections.Generic;

namespace Antpoll.Crosscutting.Logging
{
    public class LoggerResult
    {
        public LoggerResult(IEnumerable<string> error)
        {
            Succeeded = false;
            Errors = error;
        }

        public LoggerResult(bool success)
        {
            Succeeded = true;
        }

        public bool Succeeded { get; }

        public IEnumerable<string> Errors { get; }
    }
}
