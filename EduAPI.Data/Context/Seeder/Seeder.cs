using EduAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduAPI.Data.Context;

public static class Seeder
{
    public static void Seed(this ModelBuilder builder)
    {
        var authors = new List<Author>();
        var materials = new List<Material>();
        var types = new List<MatType>();
        var reviews = new List<Review>();
        authors.Add(new Author()
        {
            Id = 1,
            Name = "Priscillia Chang",
            Description = "Co-founder of the prestigious \"Women in IT\" summit."
        }
        );

        authors.Add(new Author()
        {
            Id = 2,
            Name = "Alex Green",
            Description = "A known Udemy coach."
        }
        );

        authors.Add(new Author()
        {
            Id = 3,
            Name = "Get Coding Inc.",
            Description = "Programming course provider."
        }
        );

        authors.Add(new Author()
        {
            Id = 4,
            Name = "Anne X",
            Description = "Local API guru."
        }
        );

        materials.Add(new Material()
        {
            Id = 2,
            AuthorId = 1,
            Title = "Get started in IT",
            Description = "A useful set of tips.",
            Location = "getstarted.com/article.html",
            TypeId = 2,
            PublishedAt = new DateTime(2022, 08, 02)
        }
        );

        materials.Add(new Material()
        {
            Id = 3,
            AuthorId = 4,
            Title = "Everything you need to know about APIs",
            Description = "An exhaustive guide for beginner and moderately-skilled programmers.",
            Location = "Rajska library",
            TypeId = 4,
            PublishedAt = new DateTime(2020, 05, 03)
        }
        );

        materials.Add(new Material()
        {
            Id = 1,
            AuthorId = 2,
            Title = "Build an ASP .NET MVC app",
            Description = "For baby ASP .NET programmers",
            Location = "udemy.com",
            TypeId = 3,
            PublishedAt = new DateTime(2021, 07, 25)
        }
        );

        materials.Add(new Material()
        {
            Id = 4,
            AuthorId = 3,
            Title = "My first DB",
            Description = "Build your first database in EF Core",
            Location = "getcoding.com/efcore",
            TypeId = 1,
            PublishedAt = new DateTime(2022, 03, 18)
        }
        );
        materials.Add(new Material()
        {
            Id = 5,
            AuthorId = 1,
            Title = "Effective mapping",
            Description = "Stop making silly mistakes",
            Location = "\"Women in IT\" magazine, issue 17",
            TypeId = 2,
            PublishedAt = new DateTime(2020, 05, 05)
        }
        );
        materials.Add(new Material()
        {
            Id = 6,
            AuthorId = 4,
            Title = "EF Core for dummies",
            Description = "Build your first database in EF Core",
            Location = "Left on a bench in Park Jordana",
            TypeId = 4,
            PublishedAt = new DateTime(2012, 02, 10)
        }
        );

        types.Add(new MatType()
        {
            Id = 1,
            Name = "Video tutorial",
            Definition = "A short video detailing how to implement a specific feature."
        }
        );

        types.Add(new MatType()
        {
            Id = 2,
            Name = "Article",
            Definition = "A text form explaining the issue."
        }
        );

        types.Add(new MatType()
        {
            Id = 3,
            Name = "Online course",
            Definition = "An in-depth form, covering a large portion of material."
        }
        );

        types.Add(new MatType()
        {
            Id = 4,
            Name = "Book",
            Definition = "An analogue predecessor of big online courses."
        }
        );

        reviews.Add(new Review()
        {
            Id = 1,
            MaterialId = 2,
            Contents = "Not really that useful",
            Points = 3
        }
        );

        reviews.Add(new Review()
        {
            Id = 2,
            MaterialId = 3,
            Contents = "I didn't even get any errors!",
            Points = 10
        }
        );

        reviews.Add(new Review()
        {
            Id = 3,
            MaterialId = 1,
            Contents = "Could be more clear",
            Points = 7
        }
        );

        reviews.Add(new Review()
        {
            Id = 4,
            MaterialId = 4,
            Contents = "Decent",
            Points = 6
        }
        );
        builder.Entity<Author>().HasData(authors);
        builder.Entity<Material>().HasData(materials);
        builder.Entity<MatType>().HasData(types);
        builder.Entity<Review>().HasData(reviews);
    }
}