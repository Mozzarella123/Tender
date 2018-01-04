using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApp.Models.BusinessModels
{
    public class Tender : Post
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Organization Organization { get; set; }
        public virtual ICollection<Application> Offers { get; set; }
    }
}
