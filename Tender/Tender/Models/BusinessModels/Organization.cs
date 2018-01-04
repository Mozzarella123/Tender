using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApp.Models.BusinessModels
{
    public class Organization : Post
    {
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Application> Applications { get; set; }
        public string Adress { get; set; }
    }
}
