using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApp.Models.BusinessModels
{
    public class User_Meta
    {
        public int User_MetaId { get; set; }
        public ApplicationUser User { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public virtual ICollection<User_Meta> Children { get; set; }
        public virtual User_Meta Parent { get; set; }
    }
}
