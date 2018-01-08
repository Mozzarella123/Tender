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
        public SubGroup()
        {
            Subs = new List<Sub>();
        }
        [HiddenInput(DisplayValue = false)]
        public int SubGroupId { get; set; }
        public string Name { get; set; }
        public Type ForType { get; set; }
        public int Priority { get; set; }
        public IEnumerable<Sub> Subs { get; set; }
        public enum Type { Review,Application,Page,Organization,Tender,Offer,Comment,Post }
    }
}
