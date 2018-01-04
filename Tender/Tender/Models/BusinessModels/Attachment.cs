using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApp.Models.BusinessModels
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
