﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface ICampgroundDAO
    {
        /// <summary>
        /// Gets all campgrounds from a specified park.
        /// </summary>
        /// <returns></returns>
        IList<Campground> GetCampgrounds(int id);
        decimal GetCampingCost(decimal dailyFee, DateTime arrivalDate, DateTime departureDate);
    }
}
