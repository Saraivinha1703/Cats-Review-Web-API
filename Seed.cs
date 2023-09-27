using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Data
{
    public class Seed
    {

        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if (!_context.CatOwners.Any())
            {
                List<CatOwner> catOwners = new List<CatOwner>(){
                    new CatOwner()
                     {
                        Cat = new Cat()
                        {
                            Name = "Mr.Rufus",
                            BirthDate = new DateTime(2010, 1, 1),
                            CatCategories = new List<CatCategory>()
                            {
                                new CatCategory { Category = new Category() {Breed = "Persian"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review {Title = "About Mr.Rufus", Text = "The ugliest cat of all ugly cats", Reviewer = new Reviewer() {Name = "Ms.Karen"}},
                                new Review {Title = "About Mr.Rufus", Text = "I've seen worst", Reviewer = new Reviewer() {Name = "Mr.Kyle"}},
                                new Review {Title = "About Mr.Rufus", Text = "Kinda cute", Reviewer = new Reviewer() {Name = "Saddy"}}
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Katherine Scarlett",
                            Address = "St. Ugly Cats",
                            BirthDate = new DateTime(1999, 12, 5),
                            Country = new Country() {Name = "England"}
                        }
                    },

                    new CatOwner()
                     {
                        Cat = new Cat()
                        {
                            Name = "Garfield",
                            BirthDate = new DateTime(2015, 12, 4),
                            CatCategories = new List<CatCategory>()
                            {
                                new CatCategory { Category = new Category() {Breed = "Bobtail"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review {Title = "About Garfield", Text = "Cute but angry and strange", Reviewer = new Reviewer() {Name = "Ms.Lucile"}},
                                new Review {Title = "About Garfield", Text = "Nice orange color", Reviewer = new Reviewer() {Name = "Terry"}},
                                new Review {Title = "About Garfield", Text = "Pretty", Reviewer = new Reviewer() {Name = "Robert"}}
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Vincent Violet",
                            Address = "St. Orange Cats",
                            BirthDate = new DateTime(1989, 7, 22),
                            Country = new Country() {Name = "Netherlands"}
                        }
                    },

                    new CatOwner()
                     {
                        Cat = new Cat()
                        {
                            Name = "Luck",
                            BirthDate = new DateTime(2018, 9, 12),
                            CatCategories = new List<CatCategory>()
                            {
                                new CatCategory { Category = new Category() {Breed = "Siamese"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review {Title = "About Luck", Text = "Very pretty", Reviewer = new Reviewer() {Name = "Lily"}},
                                new Review {Title = "About Luck", Text = "Acting silly sometimes", Reviewer = new Reviewer() {Name = "Anthony"}},
                                new Review {Title = "About Luck", Text = "nice", Reviewer = new Reviewer() {Name = "John"}}
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Charles Brown",
                            Address = "St. Nice Cats",
                            BirthDate = new DateTime(2004, 3, 17),
                            Country = new Country() {Name = "New Zeland"}
                        }
                    }
                };
                _context.CatOwners.AddRange(catOwners);
                _context.SaveChanges();
            }
        }
    }
}