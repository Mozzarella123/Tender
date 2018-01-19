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
        public SubGroup Group { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int SubId { get; set; }
        public string Name { get; set; }
        public SubType Type { get; set; }
        public int Priority { get; set; }
        public enum SubType { TextBox,TextArea,Image};
    }
}
