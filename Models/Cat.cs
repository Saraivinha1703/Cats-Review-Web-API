namespace CatsReviewWebAPI.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<CatCategory>? CatCategories { get; set; }
        public ICollection<CatOwner>? CatOwners { get; set; }
    }
}