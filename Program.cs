using System;
// added System.Collections.Generic to use the dictionary
using System.Collections.Generic;

namespace BookManagementApp
{
    // Created a class, LibraryManager, that conteints the library BookDatabase, an empty list to use in case of book loan and all the operations, such as borrowing, returning, and listing books.
    // It manages the collection of all available books and tracks which books the user has borrowed. To do so:
    // I created a Dictionary to store all books (IDs + titles) and a List to keep track of borrowed book IDs. 
    // Then I created public methods(called by class: Program) to unable the user to borrow, return and list books.
    public class LibraryManager
    {
        // Created a dictionary called booksDatabase, storage for all available library books.To do so:
        // I set the key as int, used it as book IDs, and the value as string, used it for book titles.
        // And with this logic, I stored inside the dictionary 15 books where key=Book ID and String=Book Title
        private Dictionary<int, string> booksDatabase = new Dictionary<int, string>
        {
            { 1, "The name of the rose" },
            { 2, "The lord of the rings" },
            { 3, "Charlie and the chocolate factory" },
            { 4, "Pride and prejudice" },
            { 5, "1984" },
            { 6, "House of leaves" },
            { 7, "The alchemist" },
            { 8, "Harry Potter and the sorcerer's stone" },
            { 9, "The hobbit" },
            { 10, "War and peace" },
            { 11, "The Da Vinci code" },
            { 12, "The picture of Dorian Gray" },
            { 13, "Moby-Dick" },
            { 14, "The little prince" },
            { 15, "Don Quixote" }
        };

        // Created a list of integers, called booksBorrowed, where the integers will be the IDs of the borrowed books.
        // It stores the IDs of all books the user has on loan. When book borrowed = its ID is add to this list; when returned, its ID is removed.
        // It stores only the IDs (key of the dictionary above) for efficiency, fast to add/remove. Titles are retrieved from the dictionary ''booksDatabase'' when needed via the ID.
        // Note: I decide to use list instand of array because list can grown and reduce depending on the number of books borrowed. Can be limited if the Library has a limit of loan books a user can borrow. 
        private List<int> booksBorrowed = new List<int>();

        // Created a public method, called ListBorrowedBooks, that prints to the console, the list of all books (ID and title) currently borrowed by the user. To do so:
        // 1. Used if statement to check if user borrowed list (booksBorrowed) is empty, using COUNT that returns the number of elements currently in the list, if equal to 0, print message "You have no borrowed books." and return to the Main.
        // 2. Otherwise, using foreach loop, it loops through each ID in booksBorrowed, retrieves the title from booksDatabase, and prints both.
        public void ListBorrowedBooks()
        {
            if (booksBorrowed.Count == 0)
            {
                Console.WriteLine("You have no borrowed books.");
                return;
            }

            Console.WriteLine("Books you have borrowed:");
            foreach (var id in booksBorrowed)
            {
                Console.WriteLine($"{id}: {booksDatabase[id]}");
            }
        }

        // Created a public method, called ReturnBook, that allows the user to return a previously borrowed book usign the book's ID. To do so:
        // 1. Prompt user for a book ID.
        // 2. Read user input and store it in a variable called INPUT (is string because Console.ReadLine() returns a string value)
        // 3. Use if statement to check if the input is valid: 
        //         _Tries to convert INPUT(string) to an integer(in order to do that INPUT must be a number):
        //              a)successful: store it into a variable called ID(integer), return TRUE, that became FALSE thanks to "!" and don't go inside the if statement.
        //              b)unsuccessful: return FALSE, that became TRUE thanks to "!", go inside the if statement and print the message of invalid ID and return to Main.
        // 4. Second if, to check if the ID (stored before) is into the user booksBorrowed list(using Contains). 
        //         _If contained = TRUE, became FALSE thanks to ! and don't go inside the if statement.
        //         _If not contained = FALSE, became TRUE thanks to !. Trigger the if, and print message "You have not borrowed this book." and return to Main.
        // 5. If valid and contained = removes it and prints a confirmation with the book's title retrieves from booksDatabase using the ID.
        public void ReturnBook()
        {
            Console.Write("Enter book ID to return: ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("ID invalid. Please check your borrowed book list to find the correct ID.");
                return;
            }
            if (!booksBorrowed.Contains(id))
            {
                Console.WriteLine("You have not borrowed this book.");
                return;
            }
            booksBorrowed.Remove(id);
            Console.WriteLine($"You have returned: {booksDatabase[id]}");
        }

        // Created a public method, called ListAllBooks, that prints to the console, the list of all books (ID and title) available in the library, regardless of whether it is borrowed or not.
        // To do so:
        // Used foreach loop: loops through each book in booksDatabase printing both book's ID (Dictionary's key) and book's title (Dictionary's value).
        public void ListAllBooks()
        {
            Console.WriteLine("All books in the library:");
            foreach (var book in booksDatabase)
            {
                Console.WriteLine($"{book.Key}: {book.Value}");
            }
        }

        // Created a public method, called BorrowBook. Allows user to borrow a book, present in the Library Database, usign the book's ID. To do so:
        // 1. Prompt user for a book ID.
        // 2. Read user input and store it in a variable called INPUT (string because Console.ReadLine() returns a string value)
        // 3. Use if statement to check if the input is valid: 
        //         _ 1° condition: Tries to convert INPUT(string) to an integer(in order to do that INPUT must be a number):
        //              a)successful: store it into a variable called ID(integer), return TRUE, that became FALSE thanks to "!"
        //              b)unsuccessful: return FALSE, that became TRUE thanks to "!" 
        //         _ 2° condition: Check if id(input) is contained as Key into the Database(using ContainsKey):
        //              a)true: became FALSE thanks to "!"
        //              b)false: became TRUE thanks to "!" 
        //         _ if at least one of the condition is TRUE: triggers if statement and print the message of invalid ID and return to Main.
        // 4. Second if, to check if the ID is contained into the user booksBorrowed list(using Contains). 
        //         _If contained = TRUE. Trigger the if statement and print message "You have already borrowed this book." and return to Main.
        //         _If not contained = FALSE. Don't go inside the if statement.
        // 5. If no one of the if statements is triggered = Add book it into the bookBorrowed List, using the id, and prints a confirmation with the book's title retrieves from booksDatabase using the ID.
        public void BorrowBook()
        {
            Console.Write("Enter book ID to borrow: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int id) || !booksDatabase.ContainsKey(id))
            {
                Console.WriteLine("Sorry, book ID invalid. Please check the library book list to find the correct ID.");
                return;
            }
            if (booksBorrowed.Contains(id))
            {
                Console.WriteLine("You have already borrowed this book.");
                return;
            }
            booksBorrowed.Add(id);
            Console.WriteLine($"You have borrowed: {booksDatabase[id]}");
        }
    }

    // Created a class called Program. Contains the Main method, application menu method and a helper to check and handle user menu input
    // It displays a menu, reads user choices, and calls the appropriate methods from the LibraryManager class to perform app actions.
    public class Program
    {
        // Main method. Entry point of the application, where the program begins.
        // 1. Initializes the LibraryManager, displays the menu, reads user choices, and calls the corresponding LibraryManager methods based on the user's selection.
        // How I made it work: To do so, I have:
        // 1. Instantiated a LibraryManager object to manage all book operations. (will contains both library database, our dictionary, and the user borrowed book list, that starts as empty)
        // 2. Created a boolean variable 'exit' to control the main loop.
        // 3. Used a while loop to repeatedly show the menu until the user chooses to exit.
        // 4. Called AppMenu() method to display the menu options.
        // 5. Called ReadChoice() method to read and validate the user's menu selection. And store the return of the method (the user choice) into a variable called choice(must be integer)
        // 6. Used a switch statement to call the correct LibraryManager method based on the user's choice.
        // 7. After each action (unless exit), prompted the user to press Enter, read the input and cleared the console for better readability when the user press Enter.
        // 8. If user choose exit, print Goodbye and exit= true so the while loop stops and the program end.
        public static void Main(string[] args)
        {
            LibraryManager LibraryManager = new LibraryManager();

            bool exit = false;

            while (!exit)
            {
                AppMenu();
                int choice = ReadChoice();

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        LibraryManager.ListBorrowedBooks();
                        break;
                    case 2:
                        LibraryManager.ReturnBook();
                        break;
                    case 3:
                        LibraryManager.ListAllBooks();
                        break;
                    case 4:
                        LibraryManager.BorrowBook();
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        exit = true;
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress Enter to return to the main menu...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        // Created a static method called AppMenu, which displays the main menu options to the user. To do so:
        // 1. Print list of possible actions (list borrowed books, return, list all, borrow, exit)
        // 2. Prompts user to enter a choice.
        static void AppMenu()
        {
            Console.WriteLine("What would you like to do:");
            Console.WriteLine("1) List all books you have on loan");
            Console.WriteLine("2) Return a book");
            Console.WriteLine("3) List all books in the library");
            Console.WriteLine("4) Borrow a book");
            Console.WriteLine("5) Exit");
            Console.Write("Enter choice (1-5): ");
        }

        // Implemented method with recursion, in other cases I would have used a WHILE, but wanted to try recursion
        // Created a static method called ReadChoice, which safely reads and validates the user's menu selection.
        // 1. Used if statement to ensures the user enters a valid integer(int.TryParse) between 1 and 5(&& choice >= 1 && choice <= 5), and returns 'choice'(int where we stored the input choice). 
        // 2. If the input is invalid, it asks again until a valid choice is chosen
        // I have used int.TryParse to attempt to parse the input, checked the range, and used recursion to repeat the prompt until a valid choice is entered.
        static int ReadChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 5)
                return choice;

            Console.WriteLine("Please enter a number between 1 and 5.");
            return ReadChoice();
        }
    }
}
