﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueManager.Models
{
    public class EntityGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Del { get; set; }
    }
}
