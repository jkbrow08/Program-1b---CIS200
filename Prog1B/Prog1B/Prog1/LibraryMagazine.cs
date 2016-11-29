// Program 1
// CIS 200-01
// Due: 2/14/2012
// By: Andrew L. Wright

// File: LibraryMagazine.cs
// This file creates a concrete LibraryMagazine class that adds
// no new data.
// LibraryMagazine IS-A LibraryPeriodical

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    public class LibraryMagazine : LibraryPeriodical
    {
        public const decimal DAILYLATEFEE = 0.25m; // Magazine's daily late fee
        public const decimal MAXFEE = 20.00m;      // Max late fee

        // Precondition:  None
        // Postcondition: The magazine has been initialized with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, volume, and number. The item is not checked out.
        public LibraryMagazine(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, int theVolume, int theNumber) :
            base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber, theVolume, theNumber)
        {
            // No new data to initialize
        }

        // Precondition:  daysLate >= 0
        // Postcondition: The fee for returning the item the specified days late
        //                has been returned
        public override decimal CalcLateFee(int daysLate)
        {
            decimal lateFee = 0.0M; // Late magazine fee

            if (daysLate < 0)
                throw new ArgumentOutOfRangeException("daysLate",
                    daysLate, "daysLate must be >= 0");
            else
                lateFee = daysLate * DAILYLATEFEE;

            // Make sure to cap the late fee
            return Math.Min(lateFee, MAXFEE);
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the libary item's data on
        //                separate lines
        public override string ToString()
        {
            String result; // Holds for formatted results as being built

            result = String.Format("LibraryMagazine{1}{0}",
                base.ToString(), System.Environment.NewLine);

            return result;
        }
    }
}
