namespace CatsReviewWebAPI.Models 
{
    public class Category {
        public int Id {get; set;}
        public string? Breed {get;set;}
        public ICollection<CatCategory>? CatCategories {get;set;}
    }
}