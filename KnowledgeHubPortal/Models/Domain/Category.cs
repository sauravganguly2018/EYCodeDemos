using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.Models.Domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required (ErrorMessage="Please enter category name")]
        [MaxLength(100)]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }
        [Required (ErrorMessage="Please enter category description")]
        [MaxLength(500)]
        [Display(Name ="Category Description")]
        public string CategoryDescription { get; set; } 
    }
}
