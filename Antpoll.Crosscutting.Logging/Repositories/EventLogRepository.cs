using System;
using System.Threading.Tasks;
using Antpoll.Crosscutting.Logging.Entities;

namespace Antpoll.Crosscutting.Logging.Repositories
{
    public class EventLogRepository : IEventLogRepository, IDisposable
    {
        public bool RegisterEvent(EventLogTypes eventLogTypes, string message, string source, string messageException, string userName)
        {
            var eventLog = new EventLog()
            {
                EventLogTypeId = eventLogTypes,
                Source = source,
                Message = message,
                MessageException = messageException,
                UserName = userName,
                Date = DateTime.UtcNow
            };

            //UNDONE: Write to file
            return true;
        }

        public async Task<bool> RegisterEventAsync(EventLogTypes eventLogTypes, string message, string source, string messageException, string userName)
        {
            var eventLog = new EventLog()
            {
                EventLogTypeId = eventLogTypes,
                Source = source,
                Message = message,
                MessageException = messageException,
                UserName = userName,
                Date = DateTime.UtcNow
            };
            //UNDONE: Write to file
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //UNDONE: Disposable object Write
            }
        }
    }
}
