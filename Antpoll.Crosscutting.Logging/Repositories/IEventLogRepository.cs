using System.Threading.Tasks;

namespace Antpoll.Crosscutting.Logging.Repositories
{
    public interface IEventLogRepository
    {
        bool RegisterEvent(EventLogTypes eventLogTypes, string message, string source, string messageException, string userName);

        Task<bool> RegisterEventAsync(EventLogTypes eventLogTypes, string message, string source, string messageException, string userName);
    }
}
