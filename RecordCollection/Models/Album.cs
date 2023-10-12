using System.ComponentModel.DataAnnotations;

namespace RecordCollection.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Artist is required")]
        public string Artist { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }
    }
}
