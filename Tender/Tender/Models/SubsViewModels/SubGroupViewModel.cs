using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;

namespace TenderApp.Models.SubsViewModels
{
    public class SubGroupViewModel
    {
        
        [HiddenInput(DisplayValue = false)]
        public int? SubGroupId { get; set; }
        public string Name { get; set; }
        public SubGroup.Type ForType { get; set; }
        public int Priority { get; set; }
        public List<Sub> Subs { get; set; }
    }
}
