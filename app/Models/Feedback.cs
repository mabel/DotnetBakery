namespace app.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int Mark { get; set; }
    }
}


