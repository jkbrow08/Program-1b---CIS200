// Program 1
// CIS 200-01
// Due: 2/14/2012
// By: Andrew L. Wright

// File: LibraryJournal.cs
// This file creates a concrete LibraryJournal class that adds
// discipline and editor.
// LibraryJournal IS-A LibraryPeriodical

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    public class LibraryJournal : LibraryPeriodical
    {
        public const decimal DAILYLATEFEE = 0.75m; // Journal's daily late fee

        // Precondition:  None
        // Postcondition: The journal has been initialized with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, volume, number, discipline, and editor. The
        //                item is not checked out.
        public LibraryJournal(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, int theVolume, int theNumber,
            String theDiscipline, String theEditor) :
            base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber, theVolume, theNumber)
        {
            Discipline = theDiscipline;
            Editor = theEditor;
        }

        public string Discipline
        {
            // Precondition:  None
            // Postcondition: The discipline has been returned
            get;

            // Precondition:  None
            // Postcondition: The discipline has been set to the specified value
            set;
        }

        public string Editor
        {
            // Precondition:  None
            // Postcondition: The editor has been returned
            get;

            // Precondition:  None
            // Postcondition: The editor has been set to the specified value
            set;
        }

        // Precondition:  daysLate >= 0
        // Postcondition: The fee for returning the item the specified days late
        //                has been returned
        public override decimal CalcLateFee(int daysLate)
        {
            if (daysLate >= 0)
                return daysLate * DAILYLATEFEE;
            else
                throw new ArgumentOutOfRangeException("daysLate",
                    daysLate, "daysLate must be >= 0");
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the libary item's data on
        //                separate lines
        public override string ToString()
        {
            String result; // Holds for formatted results as being built

            result = String.Format("LibraryJournal{3}Discipline:\t{0}{3}Editor:\t\t{1}{3}{2}",
                Discipline, Editor, base.ToString(), System.Environment.NewLine);

            return result;
        }
    }
}
