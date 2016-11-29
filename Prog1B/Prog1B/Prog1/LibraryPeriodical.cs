// Program 1
// CIS 200-01
// Due: 2/14/2012
// By: Andrew L. Wright

// File: LibraryPeriodical.cs
// This file creates an abstract LibraryPeriodical class that adds
// volume and number.
// LibraryPeriodical IS-A LibraryItem

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    public abstract class LibraryPeriodical : LibraryItem
    {
        private int periodicalVolume; // The periodical's volume
        private int periodicalNumber; // The preiodical's number

        // Precondition:  None
        // Postcondition: The library periodical has been initialized with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, volume, and number. The item is not checked out.
        public LibraryPeriodical(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, int theVolume, int theNumber) :
            base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber)
        {
            Volume = theVolume;
            Number = theNumber;
        }

        public int Volume
        {
            // Precondition:  None
            // Postcondition: The volume has been returned
            get
            {
                return periodicalVolume;
            }

            // Precondition:  value >= 0
            // Postcondition: The volume has been set to the specified value
            set
            {
                if (value >= 0)
                    periodicalVolume = value;
                else
                    throw new ArgumentOutOfRangeException("Volume",
                        value, "Volume must be >= 0");
            }
        }

        public int Number
        {
            // Precondition:  None
            // Postcondition: The number has been returned
            get
            {
                return periodicalNumber;
            }

            // Precondition:  value >= 0
            // Postcondition: The number has been set to the specified value
            set
            {
                if (value >= 0)
                    periodicalNumber = value;
                else
                    throw new ArgumentOutOfRangeException("Number",
                        value, "Number must be >= 0");
            }
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the libary item's data on
        //                separate lines
        public override string ToString()
        {
            String result; // Holds for formatted results as being built

            result = String.Format("Volume:\t\t{0}{3}Number:\t\t{1}{3}{2}",
                Volume, Number, base.ToString(), System.Environment.NewLine);

            return result;
        }
    }
}
