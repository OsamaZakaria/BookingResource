using System;
using System.Collections.Generic;
using System.Text;

namespace BookingResource.EntityFramework.Data.Seed
{
    public interface IDbInitializer
    {
        void Initialize();
        void SeedData();
    }
}
