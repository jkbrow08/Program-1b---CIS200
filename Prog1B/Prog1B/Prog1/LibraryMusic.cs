// Program 1
// CIS 200-01
// Due: 2/14/2012
// By: Andrew L. Wright

// File: LibraryMusic.cs
// This file creates a concrete LibraryMusic class that adds
// artist and number of tracks.
// LibraryMusic IS-A LibraryMediaItem

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    public class LibraryMusic : LibraryMediaItem
    {
        public const decimal DAILYLATEFEE = 0.50m; // Music's daily late fee
        public const decimal MAXFEE = 20.00m;      // Max late fee

        private int numTracks;         // Music's number of tracks
        private MediaType musicMedium; // The movie's medium

        // Precondition:  None
        // Postcondition: The movie has been initialized with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, duration, director, medium, and rating. The
        //                item is not checked out.
        public LibraryMusic(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, double theDuration, String theArtist,
            MediaType theMedium, int theNumTracks) :
            base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber, theDuration)
        {
            Artist = theArtist;
            Medium = theMedium;
            NumTracks = theNumTracks;
        }

        public string Artist
        {
            // Precondition:  None
            // Postcondition: The artist has been returned
            get;

            // Precondition:  None
            // Postcondition: The artist has been set to the specified value
            set;
        }

        public int NumTracks
        {
            // Precondition:  None
            // Postcondition: The number of tracks has been returned
            get
            {
                return numTracks;
            }

            // Precondition:  value >= 0
            // Postcondition: The number of tracks has been set to the specified value
            set
            {
                if (value >= 0)
                    numTracks = value;
                else
                    throw new ArgumentOutOfRangeException("NumTracks",
                        value, "NumTracks must be >= 0");
            }
        }

        public override MediaType Medium
        {
            // Precondition:  None
            // Postcondition: The medium has been returned
            get
            {
                return musicMedium;
            }

            // Precondition:  value from { CD, SACD, VINYL }
            // Postcondition: The medium has been set to the specified value
            set
            {
                if (value == MediaType.CD || value == MediaType.SACD ||
                    value == MediaType.VINYL)
                    musicMedium = value;
                else
                    throw new ArgumentOutOfRangeException("Medium",
                        value, "Medium must be from { CD, SACD, VINYL }");
            }
        }

        // Precondition:  daysLate >= 0
        // Postcondition: The fee for returning the item the specified days late
        //                has been returned
        public override decimal CalcLateFee(int daysLate)
        {
            decimal lateFee = 0.0M; // Late music fee

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

            result = String.Format("LibraryMusic{3}Artist:\t\t{0}{3}Num Tracks:\t{1}{3}{2}",
                Artist, NumTracks, base.ToString(),System.Environment.NewLine);

            return result;
        }
    }
}
