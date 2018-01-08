using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TenderApp.Models.BusinessModels
{
    public class SubGroup
    {
        public int SubGroupId { get; set; }
        public string Name { get; set; }
        public string ForType { get; set; }
        public int Priority { get; set; }
        public ICollection<Sub> Subs { get; set; }
    }
}
