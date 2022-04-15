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

        public virtual ICollection<EntityGroupElement> EntityGroupElements { get; set; }
    }
}
