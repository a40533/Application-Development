using OnlineLibrary.Domain.Models;
using OnlineLibrary.Infrastructure;

internal class ReadFromUser
{
    public static void runApp()
    {
        var isLoggedIn = false;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(" - - - - - WELCOME TO ONLINE LIBRARY - - - - - ");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option:");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    // Login
                    Console.Write("Enter username: ");
                    var username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    var password = Console.ReadLine();

                    using (var db = new OnlineLibraryListDbContext())
                    {
                        var records = db.Users.ToList();
                        var records2 = db.Articles.ToList();
                        var records3 = db.Borrows.ToList();
                        var records4 = db.Books.ToList();
                        foreach (var oldUser in records)
                            if (oldUser.Username == username && oldUser.Password == password)
                            {
                                Console.WriteLine("Login successful!");
                                isLoggedIn = true;
                                Console.WriteLine("Press any Key to continue");
                                Console.Clear();
                                while (isLoggedIn)
                                {
                                    Console.Clear();
                                    Console.WriteLine(
                                        $" - - - - - WELCOME {oldUser.FirstName} TO ONLINE LIBRARY - - - - - ");
                                    Console.WriteLine("Select an option:");
                                    Console.WriteLine("1. User");
                                    Console.WriteLine("2. Articles");
                                    Console.WriteLine("3. Contact");
                                    Console.WriteLine("4. Books");
                                    Console.WriteLine("5. Logout");

                                    int choice2;
                                    if (!int.TryParse(Console.ReadLine(), out choice2))
                                    {
                                        Console.WriteLine("Invalid input. Please enter a number.");
                                        continue;
                                    }

                                    switch (choice2)
                                    {
                                        case 1:
                                            Console.Clear();
                                            var isUser = true;
                                            while (isUser)
                                            {
                                                Console.WriteLine("1. Update User Data");
                                                Console.WriteLine("2. Delete User");
                                                Console.WriteLine("3. View Data");
                                                Console.WriteLine("4. Back");

                                                int choice3;
                                                if (!int.TryParse(Console.ReadLine(), out choice3))
                                                {
                                                    Console.WriteLine("Invalid input. Please enter a number.");
                                                    continue;
                                                }

                                                switch (choice3)
                                                {
                                                    case 1:
                                                        Console.Clear();
                                                        Console.Write("Update First Name: ");
                                                        var newFirstname1 = Console.ReadLine();
                                                        Console.Write("Update Last Name: ");
                                                        var newLastname1 = Console.ReadLine();
                                                        Console.Write("Update username: ");
                                                        var newUsername1 = Console.ReadLine();
                                                        Console.Write("Update password: ");
                                                        var newPassword1 = Console.ReadLine();
                                                        Console.Write("Update Email: ");
                                                        var newEmail1 = Console.ReadLine();
                                                        Console.Write("Update Phone Number: ");
                                                        var newPhone1 = Console.ReadLine();

                                                        oldUser.FirstName = newFirstname1;
                                                        oldUser.LastName = newLastname1;
                                                        oldUser.Username = newUsername1;
                                                        oldUser.Password = newPassword1;
                                                        oldUser.Email = newEmail1;
                                                        oldUser.Phone = newPhone1;

                                                        db.Users.Update(oldUser);
                                                        db.SaveChanges();

                                                        Console.WriteLine("Update Successful!");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        break;
                                                    case 2:
                                                        Console.Clear();
                                                        db.Users.Remove(oldUser);
                                                        db.SaveChanges();
                                                        isUser = false;
                                                        isLoggedIn = false;
                                                        Console.WriteLine("Delete Successful!");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        break;
                                                    case 3:
                                                        Console.Clear();
                                                        Console.WriteLine(
                                                            $"Name: {oldUser.FirstName} {oldUser.LastName}");
                                                        Console.WriteLine($"Username: {oldUser.Username}");
                                                        Console.WriteLine($"Email: {oldUser.Email}");
                                                        Console.WriteLine($"Password: {oldUser.Password}");
                                                        Console.WriteLine($"Phone: {oldUser.Phone}");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        break;
                                                    case 4:
                                                        isUser = false;
                                                        break;
                                                    default:
                                                        Console.WriteLine(
                                                            "Invalid choice. Please enter a number between 1 and 5.");
                                                        Console.Clear();
                                                        break;
                                                }
                                            }

                                            ;
                                            break;
                                        case 2:
                                            var isArticle = true;
                                            while (isArticle)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("1. Read User Articles");
                                                Console.WriteLine("2. Update User Article");
                                                Console.WriteLine("3. Delete User Article");
                                                Console.WriteLine("4. View All Articles");
                                                Console.WriteLine("5. Back");

                                                int choice3;
                                                if (!int.TryParse(Console.ReadLine(), out choice3))
                                                {
                                                    Console.WriteLine("Invalid input. Please enter a number.");
                                                    continue;
                                                }

                                                switch (choice3)
                                                {
                                                    case 1:
                                                        foreach (var userArticle in records2)
                                                            if (oldUser.Id == userArticle.UserID)
                                                            {
                                                                Console.WriteLine($"Title: {userArticle.Title}");
                                                                Console.WriteLine($"Content: {userArticle.Content}");
                                                                Console.WriteLine(
                                                                    $"Date Published: {userArticle.DatePublished}");
                                                            }

                                                        Console.Clear();
                                                        break;
                                                    case 2:
                                                        Console.Clear();
                                                        Console.Write("Update Title: ");
                                                        var newTitle1 = Console.ReadLine();
                                                        Console.Write("Update Content: ");
                                                        var newContent1 = Console.ReadLine();

                                                        foreach (var userArticle in records2)
                                                            if (oldUser.Id == userArticle.UserID)
                                                            {
                                                                userArticle.Title = newTitle1;
                                                                userArticle.Content = newContent1;
                                                                db.Articles.Update(userArticle);
                                                                db.SaveChanges();
                                                            }

                                                        Console.WriteLine("Update Successful!");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        break;
                                                    case 3:
                                                        Console.Clear();
                                                        foreach (var userArticle in records2)
                                                            if (oldUser.Id == userArticle.UserID)
                                                            {
                                                                db.Articles.Remove(userArticle);
                                                                db.SaveChanges();
                                                            }

                                                        Console.WriteLine("Delete Successful!");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        break;
                                                    case 4:
                                                        foreach (var userArticle in records2)
                                                        {
                                                            Console.WriteLine($"Title: {userArticle.Title}");
                                                            Console.WriteLine($"Content: {userArticle.Content}");
                                                            Console.WriteLine(
                                                                $"Date Published: {userArticle.DatePublished}");
                                                        }

                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        break;
                                                    case 5:
                                                        isArticle = false;
                                                        break;
                                                    default:
                                                        Console.WriteLine(
                                                            "Invalid choice. Please enter a number between 1 and 5.");
                                                        Console.Clear();
                                                        break;
                                                }
                                            }

                                            ;
                                            break;
                                        case 3:
                                            Console.Clear();
                                            Console.Write("Write Your message: ");
                                            var newMessage1 = Console.ReadLine();

                                            var contact = new Contact
                                            {
                                                Message = newMessage1
                                            };
                                            db.Contacts.Add(contact);
                                            db.SaveChanges();
                                            Console.WriteLine("Message has been sent to admin!");
                                            Console.ReadLine();
                                            Console.Clear();
                                            break;
                                        case 4:
                                            var isBook = true;
                                            while (isBook)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("1. View Books");
                                                Console.WriteLine("2. Borrow Books");
                                                Console.WriteLine("3. Return Books");
                                                Console.WriteLine("4. Search Book");
                                                Console.WriteLine("5. Back");

                                                int choice3;
                                                if (!int.TryParse(Console.ReadLine(), out choice3))
                                                {
                                                    Console.WriteLine("Invalid input. Please enter a number.");
                                                    continue;
                                                }

                                                switch (choice3)
                                                {
                                                    case 1:
                                                        foreach (var availableBooks in records4)
                                                        {
                                                            Console.WriteLine($"ID: {availableBooks.Id}");
                                                            Console.WriteLine($"Title: {availableBooks.Title}");
                                                            Console.WriteLine($"Content: {availableBooks.Author}");
                                                            Console.WriteLine(
                                                                $"Date Published: {availableBooks.PublishedDate}");
                                                            Console.WriteLine(
                                                                $"Date Published: {availableBooks.Quantity}");
                                                        }

                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        break;
                                                    case 2:
                                                        int bookChoice;
                                                        Console.Write("ID of the Book you want to Borrow: ");
                                                        if (!int.TryParse(Console.ReadLine(), out bookChoice))
                                                        {
                                                            Console.WriteLine("Invalid input. Please enter a number.");
                                                            continue;
                                                        }

                                                        foreach (var availableBooks in records4)
                                                            if (availableBooks.Id == bookChoice &&
                                                                availableBooks.Quantity > 0)
                                                            {
                                                                availableBooks.Quantity = -1;
                                                                var currentDate = DateTime.Now;
                                                                var dateString =
                                                                    currentDate.ToString("yyyy-MM-dd HH:mm:ss");
                                                                var futureDate = currentDate.AddMonths(1);
                                                                var futureDateString =
                                                                    futureDate.ToString("yyyy-MM-dd HH:mm:ss");
                                                                availableBooks.Borrows.Add(new Borrow
                                                                {
                                                                    UserID = oldUser.Id,
                                                                    BookID = availableBooks.Id,
                                                                    BorrowDate = dateString,
                                                                    ReturnDate = futureDateString
                                                                });
                                                                db.SaveChanges();
                                                                Console.WriteLine("Book borrowed successfully!");
                                                                Console.ReadLine();
                                                            }

                                                        Console.Clear();
                                                        break;
                                                    case 3:
                                                        int bookChoice2;
                                                        Console.Write("ID of the Book you want to Return: ");
                                                        if (!int.TryParse(Console.ReadLine(), out bookChoice2))
                                                        {
                                                            Console.WriteLine("Invalid input. Please enter a number.");
                                                            continue;
                                                        }

                                                        foreach (var borrowed in records3)
                                                            if (bookChoice2 == borrowed.BookID)
                                                            {
                                                                db.Borrows.Remove(borrowed);
                                                                db.SaveChanges();
                                                                Console.WriteLine("Returned Successfully!");
                                                                Console.ReadLine();
                                                            }

                                                        Console.Clear();
                                                        break;
                                                    case 4:
                                                        Console.Write(
                                                            "Write the Title of the Book you want to search: ");
                                                        var newMessage2 = Console.ReadLine();
                                                        foreach (var availableBooks in records4)
                                                            if (availableBooks.Title == newMessage2)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine($"ID: {availableBooks.Id}");
                                                                Console.WriteLine($"Title: {availableBooks.Title}");
                                                                Console.WriteLine($"Content: {availableBooks.Author}");
                                                                Console.WriteLine(
                                                                    $"Date Published: {availableBooks.PublishedDate}");
                                                                Console.WriteLine(
                                                                    $"Date Published: {availableBooks.Quantity}");
                                                            }

                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        break;
                                                    case 5:
                                                        isBook = false;
                                                        break;
                                                    default:
                                                        Console.WriteLine(
                                                            "Invalid choice. Please enter a number between 1 and 5.");
                                                        Console.Clear();
                                                        break;
                                                }
                                            }

                                            ;
                                            break;
                                        case 5:
                                            isLoggedIn = false;
                                            Console.WriteLine("Logout successful!");
                                            Console.ReadLine();
                                            break;

                                        default:
                                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                                            Console.Clear();
                                            break;
                                    }
                                }

                                ;
                            }
                            else
                            {
                                Console.WriteLine("Invalid username or password. Please try again.");
                            }
                    }

                    Console.WriteLine("Press any Key to continue");
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();
                    // Register
                    Console.Write("Enter First Name: ");
                    var newFirstname = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    var newLastname = Console.ReadLine();
                    Console.Write("Enter username: ");
                    var newUsername = Console.ReadLine();
                    Console.Write("Enter password: ");
                    var newPassword = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    var newEmail = Console.ReadLine();
                    Console.Write("Enter Phone Number: ");
                    var newPhone = Console.ReadLine();

                    // Add new user to the database
                    var user = new User
                    {
                        FirstName = newFirstname,
                        LastName = newLastname,
                        Username = newUsername,
                        Password = newPassword,
                        Email = newEmail,
                        Phone = newPhone
                    };
                    using (var db = new OnlineLibraryListDbContext())
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Registration successful!");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 3:
                    // Exit
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
                    break;
            }
        }
    }
}