using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IssueManager.Models
{
    public class EntityGroupColor
    {
        [Key]
        public int Id { get; set; }
        public string HEX { get; set; }
        public int Order { get; set; }

        //public virtual ICollection<EntityGroup> EntityGroups { get; set; }

    }
}
