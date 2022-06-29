using IssueManager.Enums;
using System;

namespace IssueManager.Models
{
    public class JobsViewModel
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string Note { get; set; }
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
