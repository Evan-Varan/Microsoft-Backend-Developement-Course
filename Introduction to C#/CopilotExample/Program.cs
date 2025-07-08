using System;

class LibraryManager
{
    static void Main()
    {
        string[] books = new string[5];
        bool[] checkedOut = new bool[5];
        int borrowedCount = 0;
        const int borrowLimit = 3;
        while (true)
        {
            Console.WriteLine("\nMenu: add, remove, search, borrow, checkin, display, exit");
            Console.Write("Choose an action: ");
            string action = Console.ReadLine()?.Trim().ToLower();

            if (action == "add")
            {
                int emptyIndex = Array.FindIndex(books, b => string.IsNullOrEmpty(b));
                if (emptyIndex == -1)
                {
                    Console.WriteLine("The library is full. No more books can be added.");
                }
                else
                {
                    Console.Write("Enter the title of the book to add: ");
                    string newBook = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newBook))
                    {
                        Console.WriteLine("Book title cannot be empty.");
                        continue;
                    }
                    books[emptyIndex] = newBook;
                    checkedOut[emptyIndex] = false;
                    Console.WriteLine($"Book '{newBook}' added.");
                }
            }
            else if (action == "remove")
            {
                if (Array.TrueForAll(books, b => string.IsNullOrEmpty(b)))
                {
                    Console.WriteLine("The library is empty. No books to remove.");
                }
                else
                {
                    Console.Write("Enter the title of the book to remove: ");
                    string removeBook = Console.ReadLine();
                    bool removed = false;
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(books[i]) && books[i].Equals(removeBook, StringComparison.OrdinalIgnoreCase))
                        {
                            if (checkedOut[i])
                            {
                                Console.WriteLine($"Cannot remove '{books[i]}': it is currently checked out.");
                                removed = true;
                                break;
                            }
                            books[i] = "";
                            checkedOut[i] = false;
                            Console.WriteLine($"Book '{removeBook}' removed.");
                            removed = true;
                            break;
                        }
                    }
                    if (!removed)
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
            }
            else if (action == "search")
            {
                Console.Write("Enter the title of the book to search for: ");
                string searchBook = Console.ReadLine();
                bool found = false;
                for (int i = 0; i < books.Length; i++)
                {
                    if (!string.IsNullOrEmpty(books[i]) && books[i].Equals(searchBook, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Book '{books[i]}' is available in the library. {(checkedOut[i] ? "(Checked out)" : "(Available)")}");
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Book not found in the collection.");
                }
            }
            else if (action == "borrow")
            {
                if (borrowedCount >= borrowLimit)
                {
                    Console.WriteLine($"You have reached the borrowing limit of {borrowLimit} books. Please check in a book before borrowing another.");
                    continue;
                }
                Console.Write("Enter the title of the book to borrow: ");
                string borrowBook = Console.ReadLine();
                bool borrowed = false;
                for (int i = 0; i < books.Length; i++)
                {
                    if (!string.IsNullOrEmpty(books[i]) && books[i].Equals(borrowBook, StringComparison.OrdinalIgnoreCase))
                    {
                        if (checkedOut[i])
                        {
                            Console.WriteLine($"Book '{books[i]}' is already checked out.");
                        }
                        else
                        {
                            checkedOut[i] = true;
                            borrowedCount++;
                            Console.WriteLine($"You have borrowed '{books[i]}'.");
                        }
                        borrowed = true;
                        break;
                    }
                }
                if (!borrowed)
                {
                    Console.WriteLine("Book not found in the collection.");
                }
            }
            else if (action == "checkin")
            {
                Console.Write("Enter the title of the book to check in: ");
                string checkinBook = Console.ReadLine();
                bool checkedIn = false;
                for (int i = 0; i < books.Length; i++)
                {
                    if (!string.IsNullOrEmpty(books[i]) && books[i].Equals(checkinBook, StringComparison.OrdinalIgnoreCase))
                    {
                        if (checkedOut[i])
                        {
                            checkedOut[i] = false;
                            borrowedCount--;
                            Console.WriteLine($"Book '{books[i]}' has been checked in.");
                        }
                        else
                        {
                            Console.WriteLine($"Book '{books[i]}' is not currently checked out.");
                        }
                        checkedIn = true;
                        break;
                    }
                }
                if (!checkedIn)
                {
                    Console.WriteLine("Book not found in the collection.");
                }
            }
            else if (action == "display")
            {
                Console.WriteLine("Available books:");
                bool anyBook = false;
                for (int i = 0; i < books.Length; i++)
                {
                    if (!string.IsNullOrEmpty(books[i]))
                    {
                        Console.WriteLine($"- {books[i]} {(checkedOut[i] ? "(Checked out)" : "(Available)")}");
                        anyBook = true;
                    }
                }
                if (!anyBook)
                {
                    Console.WriteLine("(No books in the library)");
                }
                Console.WriteLine($"Books currently borrowed: {borrowedCount}/{borrowLimit}");
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', 'search', 'borrow', 'checkin', 'display', or 'exit'.");
            }
        }
    }
}