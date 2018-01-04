using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApp.Models.BusinessModels
{
    public class Post_Meta
    {
        public int Post_MetaId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public virtual Post_Meta Parent { get; set; }
        public virtual ICollection<Post_Meta> Children { get; set; }

    }
}
