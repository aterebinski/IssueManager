﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueManager.Models
{
    public class JobNote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Del { get; set; }
        public int JobId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public string ModifyUserId { get; set; }
        public int HistoryPreviousId { get; set; }
        public int HistoryNextId { get; set; }
    }
}
