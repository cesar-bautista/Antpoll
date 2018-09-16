using System;

namespace Antpoll.Crosscutting.Logging.Entities
{
    public class EventLog
    {
        public int EventLogId { get; set; }

        public EventLogTypes EventLogTypeId { get; set; }

        public string Source { get; set; }

        public string Message { get; set; }

        public string MessageException { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }
    }
}
