﻿using IssueManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueManager.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int AssignmentId { get; set; }
        public bool Del { get; set; }
        public JobStatus Status { get; set; }
        public bool Checked { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public string ModifyUserId { get; set; }
        public int HistoryPreviousId { get; set; }
        public int HistoryNextId { get; set; }
    }
}
