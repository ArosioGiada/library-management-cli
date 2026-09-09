# Library Management CLI

An interactive console application in C# for managing a library's book catalogue — list books, borrow them, and return them — built using the .NET Standard Library's collection types.

## Overview

The app presents a menu loop where the user can list their currently borrowed books, return a book, list every book in the library, or borrow a book. After each action, the program returns to the main menu until the user chooses to exit.

    What would you like to do:
    1) List all books you have on loan
    2) Return a book
    3) List all books in the library
    4) Borrow a book
    5) Exit
    Enter choice (1-5):

## Data structures

- **`Dictionary<int, string>`**: the library's book catalogue, keyed by book ID with the title as the value. Preloaded with 15 books.
- **`List<int>`**: the IDs of the books currently borrowed. `List<T>` is used deliberately here as the Standard Library's dynamically-resizing array — it grows and shrinks as books are borrowed and returned, with no fixed limit on how many a user can have on loan.

## Features

- **List borrowed books**: shows each borrowed book's ID and title, looked up from the catalogue.
- **Return a book**: validates the entered ID and confirms it's actually on loan before removing it.
- **List all books**: prints every book in the catalogue.
- **Borrow a book**: validates the ID exists in the catalogue and isn't already borrowed before adding it.

Invalid input (non-numeric IDs, IDs not in the catalogue, returning a book not on loan, borrowing a book already on loan) is caught and reported with a clear message instead of crashing the program.

## How to run

    dotnet run

Follow the on-screen menu prompts.

## Design notes

The menu input loop (`ReadChoice`) is implemented with recursion instead of a `while` loop — a deliberate choice to practice the pattern, since it re-prompts the user on invalid input by calling itself again rather than looping.

## Author

Giada Arosio — built for the Algorithms and Data Structures unit at Torrens University Australia.
