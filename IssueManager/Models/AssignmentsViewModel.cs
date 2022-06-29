using System.Collections.Generic;

namespace IssueManager.Models
{
    public class AssignmentsViewModel
    {
        public Assignment assignment { get; set; }
        public List<Entity> entities { get; set; } = new List<Entity>();
        public List<EntityGroup> entityGroups { get; set; } = new List<EntityGroup>();

        public Dictionary<int, bool> EntityCheck { get; set; } = new Dictionary<int, bool>();



    }
}
