namespace CatsReviewWebAPI.Models
{
    public class CatOwner
    {
        public int CatId { get; set; }
        public int OwnerId { get; set; }
        public Cat? Cat { get; set; }
        public Owner? Owner { get; set; }
    }
}