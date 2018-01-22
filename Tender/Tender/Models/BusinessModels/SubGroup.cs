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
        public int SubGroupId { get; set; }
        public string Name { get; set; }
        public Type ForType { get; set; }
        public int Priority { get; set; }
        public virtual ICollection<Sub> Sub { get; set; }

        public enum Type
        {
            [Display(Name = "Отзывы")]
            Review,
            [Display(Name = "Предложения")]
            Application,
            [Display(Name = "Страницы")]
            Page,
            [Display(Name = "Организации")]
            Organization,
            [Display(Name = "Тендеры")]
            Tender,
            [Display(Name = "Тендеры")]
            Offer,
            [Display(Name = "Комментарии")]
            Comment,
            [Display(Name = "Посты")]
            Post
        }
    }
}
