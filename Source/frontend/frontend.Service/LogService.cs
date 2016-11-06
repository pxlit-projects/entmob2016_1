using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Domain;

namespace frontend.Service
{
    public class LogService : ILogService
    {
        private LogRepository repo;

        public LogService(string username, string password)
        {
            repo = new LogRepository(username, password);
        }

        public List<Log> All()
        {
           var logs = repo.GetAllLogs().Result;
            if (logs != null)
            {
                return logs;
            }
            else
            {
                return new List<Log>();
            }
        }
    }
}
