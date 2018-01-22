using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TenderApp.Models.BusinessModels
{
    public class Sub
    {
        public int SubId { get; set; }
        public string Name { get; set; }
        public SubType Type { get; set; }
        public int Priority { get; set; }
        public int SupGroupId { get; set; }
        public virtual SubGroup SubGroup { get; set; }
        public enum SubType { TextBox,TextArea,Image};
    }
}
