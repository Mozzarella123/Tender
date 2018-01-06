﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TenderApp.Models.BusinessModels
{
    public class Sub
    {
        [HiddenInput(DisplayValue = false)]
        public int SubId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Priority { get; set; }
        //public enum SubType { TextBox,TextArea,Image};
    }
}
