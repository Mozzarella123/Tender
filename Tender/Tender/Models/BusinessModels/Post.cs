using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace TenderApp.Models.BusinessModels
{
    public enum Status { Published, Drafted, Archived, Moderation }
    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public ApplicationUser Author { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Post_Meta> Metas { get; set; }
    }
    
}
