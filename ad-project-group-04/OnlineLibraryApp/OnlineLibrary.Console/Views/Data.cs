using OnlineLibrary.Domain.Models;
using OnlineLibrary.Infrastructure;

namespace OnlineLibrary.Console.Views;

internal class Data
{
    public static void NewData()
    {
        var category = new Category { Name = "Adventure" };
        var category2 = new Category { Name = "Action" };
        var category3 = new Category { Name = "Horror" };
        var category4 = new Category { Name = "Romance" };
        var category5 = new Category { Name = "Fan Fiction" };

        var book = new Book
        {
            Title = "Test Book",
            Author = "Test Author",
            Quantity = 100,
            PublishedDate = "2020/1/1"
        };
        var book2 = new Book
        {
            Title = "Test Book2",
            Author = "Test Author2",
            Quantity = 100,
            PublishedDate = "2020/1/1"
        };
        var book3 = new Book
        {
            Title = "Test Book3",
            Author = "Test Author3",
            Quantity = 100,
            PublishedDate = "2020/1/1"
        };
        var book4 = new Book
        {
            Title = "Test Book4",
            Author = "Test Author4",
            Quantity = 100,
            PublishedDate = "2020/1/1"
        };
        var book5 = new Book
        {
            Title = "Test Book5",
            Author = "Test Author5",
            Quantity = 100,
            PublishedDate = "2020/1/1"
        };
        
        using (var db = new OnlineLibraryListDbContext())
        {
            db.Books.Add(book);
            db.Categories.Add(category);
            db.Books.Add(book2);
            db.Categories.Add(category2);
            db.Books.Add(book3);
            db.Categories.Add(category3);
            db.Books.Add(book4);
            db.Categories.Add(category4);
            db.Books.Add(book5);
            db.Categories.Add(category5);
            db.SaveChanges();
        }
    }
}