﻿using System;
using System.Collections.Generic;

namespace PowerPack.Models.Entities
{
    public class ErrorLogModel
    {
        public Guid ErrorId { get; set; }
        public string Application { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string User { get; set; }
        public int StatusCode { get; set; }
        public DateTime TimeUtc { get; set; }
        public int Sequence { get; set; }
        public string AllXml { get; set; }
        public long StoreId { get; set; }
        public bool IsWeb { get; set; }
    }
    public class  ErrorLog
    {
        public IEnumerable<ErrorLogModel>  ErrorLogs { get; set; }
        public int TotalCount { get; set; }
    }
}