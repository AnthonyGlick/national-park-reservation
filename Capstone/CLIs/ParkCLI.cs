﻿using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLIs
{
    public class ParkCLI : CLI
    {
        const int padInfo = 20;
        const int padOptions = 3;
        const int returnToInputLine = 2;

        private readonly Park park;


        public ParkCLI(Park selectedPark)
        {
            
            this.park = selectedPark;
        }

        public override void Run()
        {
            bool isParkNull = this.park == null;

            if (isParkNull)
            {
                throw new Exception();
            }

            ParkMenuHeader(padInfo, padOptions);

            while (true)
            {
                int choice = GetInteger("Pick one:");

                if (choice == 1)
                {
                    CampgroundCLI campgroundCLI = new CampgroundCLI(this.park.Id);
                    campgroundCLI.Run();
                    ParkMenuHeader(padInfo, padOptions);
                }
                else if (choice == 2)
                {
                    // TODO add park-wide search option
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid option, please try again.");
                    Console.CursorTop -= returnToInputLine;
                }
            }
        }

        /// <summary>
        /// Displays the park menu header
        /// </summary>
        /// <param name="padInfo">the padding for the info</param>
        /// <param name="padOptions">the padding for the options</param>
        private void ParkMenuHeader(int padInfo, int padOptions)
        {
            Console.Clear();
            Console.WriteLine(this.park.Name + " National Park");
            Console.WriteLine("Loaction:".PadRight(padInfo) + this.park.Location);
            Console.WriteLine("Established:".PadRight(padInfo) + this.park.EstablishedDate);
            Console.WriteLine("Area:".PadRight(padInfo) + this.park.Area);
            Console.WriteLine("Annual Visitors:".PadRight(padInfo) + this.park.Visitors);
            Console.WriteLine();
            WordWrap(this.park.Description);
            Console.WriteLine();

            Console.WriteLine("Select a command");
            Console.WriteLine("1) View Campgrounds".PadRight(padOptions));
            Console.WriteLine("2) Search for Reservation".PadRight(padOptions));
            Console.WriteLine("3) Return to Previous Screen".PadRight(padOptions));
        }
    }
}
