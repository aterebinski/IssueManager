using System.Collections.Generic;

namespace IssueManager.Models
{
    public class EntityGroupElementsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<EntityViewModel> EntitiesVM { get; set; } = new List<EntityViewModel>();
        public List<Entity> Entities { get; set; } = new List<Entity>();
        //public Dictionary<Entity, bool> IsChecked { get; set; } = new Dictionary<Entity, bool>();
        public Dictionary<int, bool> IsChecked { get; set; } = new Dictionary<int, bool>();
    }
}
