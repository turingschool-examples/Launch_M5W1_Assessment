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
        [StringLength(50, ErrorMessage = "Artist cannot exceed 50 characters")]
        public string Artist { get; set; }
        public int Rating { get; set; }
    }
}
