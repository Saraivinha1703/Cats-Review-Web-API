namespace CatsReviewWebAPI.Models 
{
    public class Owner {
        public int Id {get; set;}
        public string? Name {get;set;}
        public string? Address {get;set;}
        public DateTime BirthDate {get;set;}
        public Country? Country {get;set;}
        public ICollection<CatOwner>? CatOwners {get;set;}
    }
}