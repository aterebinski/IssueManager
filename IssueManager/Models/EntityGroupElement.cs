using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueManager.Models
{
    public class EntityGroupElement
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int EntityGroupId { get; set; }
        public bool Del { get; set; }
        public int Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public string ModifyUserId { get; set; }
        public int HistoryPreviousId { get; set; }
        public int HistoryNextId { get; set; }

        public virtual Entity Entity { get; set; }
        public virtual EntityGroup EntityGroup { get; set; }
    }
}
