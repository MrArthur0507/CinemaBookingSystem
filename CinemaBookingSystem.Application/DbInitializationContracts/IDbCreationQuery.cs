﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.DbInitializationContracts
{
    public interface IDbCreationQuery
    {
        public bool ExecuteCreationQuery();

    }
}
