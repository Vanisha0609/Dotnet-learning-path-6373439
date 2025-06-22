using System;

class Book
{
    public int BookId;
    public string Title;
    public string Author;

    public void Display()
    {
        Console.WriteLine($"ID: {BookId}, Title: {Title}, Author: {Author}");
    }
}

class Library
{
    Book[] books = new Book[100];
    int count = 0;

    public void AddBook(Book book)
    {
        if (count >= books.Length)
        {
            Console.WriteLine("Library full!");
            return;
        }
        books[count++] = book;
    }

    public void LinearSearch(string title)
    {
        bool found = false;
        for (int i = 0; i < count; i++)
        {
            if (books[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                books[i].Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Book not found (Linear Search).");
    }

    public void BinarySearch(string title)
    {
        // Ensure books are sorted by title before calling this!
        int left = 0, right = count - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int cmp = string.Compare(books[mid].Title, title, StringComparison.OrdinalIgnoreCase);

            if (cmp == 0)
            {
                books[mid].Display();
                return;
            }
            else if (cmp < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        Console.WriteLine("Book not found (Binary Search).");
    }

    public void SortBooksByTitle()
    {
        Array.Sort(books, 0, count, Comparer<Book>.Create((b1, b2) =>
            string.Compare(b1.Title, b2.Title, StringComparison.OrdinalIgnoreCase)));
    }

    public void DisplayAll()
    {
        for (int i = 0; i < count; i++)
        {
            books[i].Display();
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\n--- Library Management System ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Search by Title (Linear)");
            Console.WriteLine("3. Search by Title (Binary)");
            Console.WriteLine("4. Display All Books");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    Book b = new Book();
                    Console.Write("Enter Book ID: ");
                    b.BookId = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter Title: ");
                    b.Title = Console.ReadLine()!;
                    Console.Write("Enter Author: ");
                    b.Author = Console.ReadLine()!;
                    library.AddBook(b);
                    break;

                case 2:
                    Console.Write("Enter Title to search (Linear): ");
                    string linearTitle = Console.ReadLine()!;
                    library.LinearSearch(linearTitle);
                    break;

                case 3:
                    library.SortBooksByTitle();
                    Console.Write("Enter Title to search (Binary): ");
                    string binaryTitle = Console.ReadLine()!;
                    library.BinarySearch(binaryTitle);
                    break;

                case 4:
                    library.DisplayAll();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}

