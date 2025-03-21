﻿using CinemaBookingSystem.Application.Contracts.Repositories.Base;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Contracts.Repositories
{
    public interface ICinemaLocationRepository : IBaseRepository<CinemaLocation>
    {
    }
}
