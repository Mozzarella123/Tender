using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;

namespace TenderApp.Models.SubsViewModels
{
    public class SubViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int SubGroupId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? SubId { get; set; }
        public string Name { get; set; }
        public Sub.SubType Type { get; set; }
        public int Priority { get; set; }
    }
}
