//  Title: Program 1B
//  Class:  CIS 200-01
//    Due: 2/21/2012
//   Name: Jeremy Brown
//Purpose: The purpose of this program is to create a test program
//         using Linq to create and display specific queries.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryItems;


public class Program
{
    // Precondition:  None
    // Postcondition: The LibraryItem hierarchy has been tested using LINQ, demonstrating polymorphism
    public static void Main(string[] args)
    {
        const int DAYSLATE = 14; // Number of days late to test each object's CalcLateFee method

        List<LibraryItem> items = new List<LibraryItem>();       // List of library items
        List<LibraryPatron> patrons = new List<LibraryPatron>(); // List of patrons

        int p; // Patron index

        // Test data - Magic numbers allowed here
        items.Add(new LibraryBook("The Wright Guide to C#", "UofL Press", 2010, 14,
            "ZZ25 3G", "Andrew Wright"));
        items.Add(new LibraryBook("Harriet Pooter", "Stealer Books", 2000, 21,
            "AB73 ZF", "IP Thief"));
        items.Add(new LibraryMovie("Andrew's Super-Duper Movie", "UofL Movies", 2011, 7,
            "MM33 2D", 92.5, "Andrew L. Wright", LibraryMediaItem.MediaType.BLURAY,
            LibraryMovie.MPAARatings.PG));
        items.Add(new LibraryMovie("Pirates of the Carribean: The Curse of C#", "Disney Programming", 2011, 10,
            "MO93 4S", 122.5, "Steven Stealberg", LibraryMediaItem.MediaType.DVD, LibraryMovie.MPAARatings.G));
        items.Add(new LibraryMusic("C# - The Album", "UofL Music", 2011, 14,
            "CD44 4Z", 84.3, "Dr. A", LibraryMediaItem.MediaType.CD, 10));
        items.Add(new LibraryMusic("Led Zeppelin IV", "Universal", 1996, 21,
            "VI64 1Z", 65.0, "Led Zeppelin", LibraryMediaItem.MediaType.VINYL, 12));
        items.Add(new LibraryJournal("Journal of C# Seriousness", "UofL Journals", 2011, 14,
            "JJ12 7M", 1, 2, "Information Systems", "Andrew Wright"));
        items.Add(new LibraryJournal("Japanese Journal", "UofL Journals", 2007, 14,
            "JJ34 3F", 8, 4, "Modern Language", "Kazuko Probst"));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
            "MA53 9A", 16, 7));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
            "MA53 9B", 16, 8));
        items.Add(new LibraryMagazine("Java Weekly", "UofL Mags", 2010, 14,
            "MA53 9C", 16, 9));
        items.Add(new LibraryMagazine("VB Magazine", "UofL Mags", 2011, 14,
            "MA21 5V", 1, 1));

        // Add patrons
        patrons.Add(new LibraryPatron("Akira Kurosawa", "12345"));
        patrons.Add(new LibraryPatron("Mifune Toshiro", "11223"));
        patrons.Add(new LibraryPatron("Kathryn Janeway", "54321"));
        patrons.Add(new LibraryPatron("James T. Kirk", "98765"));
        patrons.Add(new LibraryPatron("Jean-Luc Picard", "33456"));

        Console.WriteLine("List of items at start:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);
        Pause();

        // Check out some items
        // Here, every other item will be checked out by patrons (in order)
        // This is tricky... pay attention!

        p = 0; // Start with 1st patron
        for (int i = 0; i < items.Count; i += 2) // +=2 does every other
            items[i].CheckOut(patrons[p++ % patrons.Count]); // % count keeps within 0 - (count-1)

        Console.WriteLine("List of items after checking some out:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);
        Pause();

        //Filters out the items that are checked out and displays them
        var checkedOut =
            from L in items
            where L.IsCheckedOut() == true
            select L;

        Console.WriteLine("The items that are checked out are:\n");
        foreach (var item in checkedOut)
            Console.WriteLine("{0}\n", item);

        //Displays the count of currently checked out items
        Console.WriteLine("The amount of items that are currently checked out are: " +
        "{0}\n", checkedOut.Count());  
        Pause();

        //Finds and displays each library item that is a media item
        var mediaFilter =
            from L in checkedOut
            where L is LibraryMediaItem
            select L;

        foreach (var media in mediaFilter)
            Console.WriteLine("{0}\n", media);
        Pause();

        //Finds and displays each unique library magazine title
        var magFilter =
            from L in items
            where L is LibraryMagazine
            select L.Title;

        Console.WriteLine("The unique magazine titles are:\n");
        foreach (var title in magFilter.Distinct())
            Console.WriteLine("{0}\n",title);
        Pause();

        Console.WriteLine("Calculated late fees after {0} days late:\n", DAYSLATE);
        Console.WriteLine("{0,42} {1,11} {2,8}", "Title", "Call Number", "Late Fee");
        Console.WriteLine("------------------------------------------ ----------- --------");

        // Caluclate and display late fees for each item
        foreach (LibraryItem item in items)
            Console.WriteLine("{0,42} {1,11} {2,8:C}", item.Title, item.CallNumber,
                item.CalcLateFee(DAYSLATE));
        Pause();

        // Return each item that is checked out
        foreach (LibraryItem item in items)
        {
            if (item.IsCheckedOut())
                item.ReturnToShelf();
        }
        //Display the returned items
        Console.WriteLine("After returning all items:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);

        //Display the count of items that are currently checked out
        Console.WriteLine("The amount of items that are currently checked out are: " +
        "{0}\n", checkedOut.Count());
        Pause();


        //Display the libraryBooks in LibraryItems and update the load period to add 7 days
        foreach (LibraryItem item in items)
        {
            if (item is LibraryBook)
            {
                Console.WriteLine(item);
                item.LoanPeriod += 7;
                Console.WriteLine("Updated Loan Period is: {0}\n", item.LoanPeriod);
            }

        }
        Pause();
    }

    // Precondition:  None
    // Postcondition: Pauses program execution until user presses Enter and
    //                then clears the screen
    public static void Pause()
    {
        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

        Console.Clear(); // Clear screen
    }
}