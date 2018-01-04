using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApp.Models.BusinessModels
{
    public class Review : Comment
    {
        public int Mark { get; set; }
    }
}
