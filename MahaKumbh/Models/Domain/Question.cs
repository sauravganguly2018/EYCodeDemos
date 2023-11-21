using System.ComponentModel.DataAnnotations;

namespace MahaKumbh.Models.Domain
{
    public class Question
    {
        [Key]
        public int Qid { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime DateSubmitted { get; set; }
    }
}
