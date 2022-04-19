using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueManager.Models
{
    public class Entity //Przedsiębiorstwo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Del { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public string ModifyUserId { get; set; }
        public int HistoryPreviousId { get; set; }
        public int HistoryNextId { get; set; }

        public virtual ICollection<EntityGroupElement> EntityGroupElements { get; set; }
    }
}
