using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueManager.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public bool Del { get; set; }
        public int Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public string ModifyUserId { get; set; }
        public int HistoryPreviousId { get; set; }
        public int HistoryNextId { get; set; }
    }
}
