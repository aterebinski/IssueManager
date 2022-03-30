using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueManager.Models
{
    public class Entity //Przedsiębiorstwo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Del { get; set; }
    }
}
