namespace KnowledgeHubPortal.Models.Domain
{
    public class Article
    {
        public int ArticleID {  get; set; } 
        public string Title { get; set; }
        public string URL { get; set; } 
        public string? Description {  get; set; }    
        public string? Author { get; set; }
        public DateTime DateSubmitted { get; set; } 
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
