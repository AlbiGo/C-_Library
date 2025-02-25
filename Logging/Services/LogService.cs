using DataManagement.Entities;
using Dependency.Concept;
using Logging.Repositories;
using System.Data.Entity;

namespace Logging.Services
{
    public class LogService : ILogService
    {
        private readonly IExceptionLogRepository _exceptionLogRepository;

        public LogService()
        {
            _exceptionLogRepository = DependencyInjectionProvider.Resolve<IExceptionLogRepository>();
        }

        /// <summary>
        /// Log to db
        /// </summary>
        public async Task Log(Log log)
        {
            await _exceptionLogRepository.Add(log);
        }

        public async Task<List<Log>> GetLogs()
        {
            return await (_exceptionLogRepository.CustomQuery()
                .ToListAsync());
        }
    }
}