﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApp.Models.BusinessModels
{
    public class Comment : Post
    {
        public Post Post { get; set; }
    }
}
