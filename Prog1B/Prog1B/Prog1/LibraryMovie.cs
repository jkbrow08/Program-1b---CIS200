// Program 1
// CIS 200-01
// Due: 2/14/2012
// By: Andrew L. Wright

// File: LibraryMovie.cs
// This file creates a concrete LibraryMovie class that adds
// director and rating.
// LibraryMovie IS-A LibraryMediaItem

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    public class LibraryMovie : LibraryMediaItem
    {
        public const decimal DAILYLATEFEEDVD = 1.00m; // DVD/VHS's daily late fee
        public const decimal DAILYLATEFEEBLU = 1.50m; // BluRay's daily late fee
        public const decimal MAXFEE = 25.00m;         // Max late fee

        public enum MPAARatings { G, PG, PG13, R, NC17, U }; // Possible movie ratings

        // String names of ratings - Must put in same order as items in MPAARatings enum
        private String[] RatingsNames = { "G", "PG", "PG-13", "R", "NC-17", "U"};

        private MediaType movieMedium; // The movie's medium

        // Precondition:  None
        // Postcondition: The movie has been initialized with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, duration, director, medium, and rating. The
        //                item is not checked out.
        public LibraryMovie(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, double theDuration, String theDirector,
            MediaType theMedium, MPAARatings theRating) :
            base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber, theDuration)
        {
            Director = theDirector;
            Medium = theMedium;
            Rating = theRating;
        }

        public string Director
        {
            // Precondition:  None
            // Postcondition: The director has been returned
            get;

            // Precondition:  None
            // Postcondition: The director has been set to the specified value
            set;
        }

        public MPAARatings Rating
        {
            // Precondition:  None
            // Postcondition: The rating has been returned
            get;

            // Precondition:  None
            // Postcondition: The rating has been set to the specified value
            set;
        }

        public override MediaType Medium
        {
            // Precondition:  None
            // Postcondition: The medium has been returned
            get
            {
                return movieMedium;
            }

            // Precondition:  value from { DVD, BLURAY, VHS }
            // Postcondition: The medium has been set to the specified value
            set
            {
                if (value == MediaType.BLURAY || value == MediaType.DVD ||
                    value == MediaType.VHS)
                    movieMedium = value;
                else
                    throw new ArgumentOutOfRangeException("Medium",
                        value, "Medium must be from { DVD, BLURAY, VHS }");
            }
        }

        // Precondition:  daysLate >= 0
        // Postcondition: The fee for returning the item the specified days late
        //                has been returned
        public override decimal CalcLateFee(int daysLate)
        {
            decimal lateFee = 0.0M; // Late movie fee

            if (daysLate < 0)
                throw new ArgumentOutOfRangeException("daysLate",
                    daysLate, "daysLate must be >= 0");
            else if (Medium == MediaType.BLURAY)
                lateFee = daysLate * DAILYLATEFEEBLU;
            else
                lateFee = daysLate * DAILYLATEFEEDVD;

            // Make sure to cap the late fee
            return Math.Min(lateFee, MAXFEE);
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the libary item's data on
        //                separate lines
        public override string ToString()
        {
            String result; // Holds for formatted results as being built

            result = String.Format("LibraryMovie{1}Director:\t{0}{1}",
                Director, System.Environment.NewLine);

            result += String.Format("Rating:\t\t{0}{2}{1}",
                RatingsNames[(int)Rating], base.ToString(), System.Environment.NewLine);

            return result;
        }
    }
}
