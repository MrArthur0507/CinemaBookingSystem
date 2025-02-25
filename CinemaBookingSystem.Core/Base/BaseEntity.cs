using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Core.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity() { 
            Id = Guid.NewGuid();
        }

        public BaseEntity(Guid id)
        {
            Id = id;
        }

    }
}
