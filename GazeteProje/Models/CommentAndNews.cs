namespace GazeteProje.Models
{
    public class CommentAndNews
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        virtual public News? News { get; set; }
        public int CommentId { get; set; }
        virtual public Comments? Comments { get; set; }
    }
}
