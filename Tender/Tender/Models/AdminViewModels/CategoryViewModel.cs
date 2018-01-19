using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;

namespace TenderApp.Models.AdminViewModels
{
    public class CategoryViewModel
    {
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        public string Type { get; set; }
        [Display(Name = "Родительская категория")]

        public virtual int ParentId { get; set; }
    }
}
