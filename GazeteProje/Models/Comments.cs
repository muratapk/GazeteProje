using System.ComponentModel.DataAnnotations;

namespace GazeteProje.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentName { get; set; } = string.Empty;
        public string CommentContent { get; set; } = string.Empty;
        public bool ? Approval { get; set; }
        public virtual List<CommentAndNews>? CommentAndNews { get; set; }
    }
}
