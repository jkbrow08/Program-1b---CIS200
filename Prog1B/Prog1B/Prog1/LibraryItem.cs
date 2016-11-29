// Program 1
// CIS 200-01
// Due: 2/14/2012
// By: Andrew L. Wright

// File: LibraryItem.cs
// This file creates an abstract LibraryItem class that will serve
// as the base class of a hierarchy of library items that keep
// track of common information and can be checked out by
// LibraryPatrons.
// LibraryItem HAS-A LibraryPatron (when the item is checked out)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    public abstract class LibraryItem
    {
        private LibraryPatron patron;  // The person that has the book checked out (null otherwise)
        private bool itemCheckedOut;   // The item's checked out status
        private int itemCopyrightYear; // The item's year of copyright
        private int itemLoanPeriod;    // The item's loan period

        // Precondition:  None
        // Postcondition: The library item has been initialized with the specified
        //                values for title, publisher, copyright year, loan period and
        //                call number. The item is not checked out.
        public LibraryItem(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber)
        {
            Title = theTitle;
            Publisher = thePublisher;
            CopyrightYear = theCopyrightYear;
            LoanPeriod = theLoanPeriod;
            CallNumber = theCallNumber;

            ReturnToShelf(); // Make sure item is not checked out
        }


        public string CallNumber
        {
            // Precondition:  None
            // Postcondition: The call number has been returned
            get;

            // Precondition:  None
            // Postcondition: The call number has been set to the specified value
            set;
        }

        public string Title
        {
            // Precondition:  None
            // Postcondition: The title has been returned
            get;

            // Precondition:  None
            // Postcondition: The title has been set to the specified value
            set;
        }

        public string Publisher
        {
            // Precondition:  None
            // Postcondition: The publisher has been returned
            get;

            // Precondition:  None
            // Postcondition: The publisher has been set to the specified value
            set;
        }

        public int CopyrightYear
        {
            // Precondition:  None
            // Postcondition: The copyright year has been returned
            get
            {
                return itemCopyrightYear;
            }

            // Precondition:  value >= 0
            // Postcondition: The copyright year has been set to the specified value
            set
            {
                if (value >= 0)
                    itemCopyrightYear = value;
                else
                    throw new ArgumentOutOfRangeException("CopyrightYear",
                        value, "CopyrightYear must be >= 0");
            }
        }

        public int LoanPeriod
        {
            // Precondition:  None
            // Postcondition: The loan period has been returned
            get
            {
                return itemLoanPeriod;
            }

            // Precondition:  value >= 0
            // Postcondition: The loan period has been set to the specified value
            set
            {
                if (value >= 0)
                    itemLoanPeriod = value;
                else
                    throw new ArgumentOutOfRangeException("LoanPeriod",
                        value, "LoanPeriod must be >= 0");
            }
        }

        // Abstract method header
        // Precondition:  daysLate >= 0
        // Postcondition: The fee for returning the item the specified days late
        //                has been returned
        public abstract decimal CalcLateFee(int daysLate);

        // Precondition:  None
        // Postcondition: The item is checked out by thePatron
        public void CheckOut(LibraryPatron thePatron)
        {
            itemCheckedOut = true;
            patron = thePatron;
        }

        // Precondition:  None
        // Postcondition: The item is not checked out (by any patron)
        public void ReturnToShelf()
        {
            itemCheckedOut = false;
            patron = null; // No longer associated with anyone
        }

        // Precondition:  None
        // Postcondition: true is returned if the item is checked out,
        //                otherwise false is returned
        public bool IsCheckedOut()
        {
            return itemCheckedOut;
        }

        // Precondition:  IsCheckedOut() == true
        // Postcondition: The patron that has the item checked out is returned
        //                (otherwise null)
        public LibraryPatron GetPatron()
        {
            return patron;
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the libary item's data on
        //                separate lines
        public override string ToString()
        {
            String result; // Holds for formatted results as being built

            result = String.Format("Title:\t\t{0}{5}Publisher:\t{1}{5}" +
                "Copyright:\t{2}{5}Loan Period:\t{3}{5}Call Number:\t{4}{5}",
                Title, Publisher, CopyrightYear, LoanPeriod, CallNumber,
                System.Environment.NewLine);

            if (IsCheckedOut())
                result += String.Format("Checked Out By:{1}{0}", GetPatron(),
                    System.Environment.NewLine);
            else
                result += "Not Checked Out";

            return result;
        }
    }
}
