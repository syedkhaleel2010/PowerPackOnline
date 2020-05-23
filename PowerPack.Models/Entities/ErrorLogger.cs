using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models.Entities
{
    public class ErrorLogger
    {
        public long ErrorLogId { get; set; }
        public string ErrorMessage { get; set; }
        public long UserId { get; set; }
        public string ModuleUrl { get; set; }
        public string UserIpAddress { get; set; }
        public string WebServerIpAddress { get; set; }
        public DateTime ReportingDate { get; set; }
        public string User { get; set; }
        public List<string> lstTaskFiles { get; set; }
    }

    public class DBLogDetails
    {
        public int SPID { get; set; }
        public int BlkBy { get; set; }
        public int ElapsedMS { get; set; }
        public int CPU { get; set; }
        public int IOReads { get; set; }
        public int IOWrites { get; set; }
        public int Executions { get; set; }
        public string CommandType { get; set; }
        public string ObjectName { get; set; }
        public string SQLStatement { get; set; }

        public string STATUS { get; set; }
        public string Login { get; set; }
        public string Host { get; set; }
        public string DBName { get; set; }
        public string LastWaitType { get; set; }
        public DateTime StartTime { get; set; }
        public string Protocol { get; set; }
        public string transaction_isolation { get; set; }
        public int ConnectionWrites { get; set; }
        public int ConnectionReads { get; set; }
        public string Authentication { get; set; }
        public string ClientAddress { get; set; }
    }
}
