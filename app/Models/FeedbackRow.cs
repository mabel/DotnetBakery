using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models
{
    public class FeedbackRow
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public int Mark { get; set; }
    }
}


