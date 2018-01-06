using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TenderApp.Models.BusinessModels
{
    public class SubGroup
    {
        [HiddenInput(DisplayValue = false)]
        public int SubGroupId { get; set; }
        public string Name { get; set; }
        public int ForType { get; set; }
        public int Priority { get; set; }
        public ICollection<Sub> Subs { get; set; }
    }
}
