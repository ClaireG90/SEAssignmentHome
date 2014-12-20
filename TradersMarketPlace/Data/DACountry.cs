using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DACountry : Connection
    {
        public DACountry()
            : base()
        { }

        public DACountry(TraderMarketPlaceEntities entities)
            : base(entities)
        { }

        public IQueryable<Country> GetCountries()
        {
            return entities.Country;
        }

        public Country GetCountry(Guid id)
        {
            return entities.Country.SingleOrDefault(c => c.ID == id);
        }
    }
}
