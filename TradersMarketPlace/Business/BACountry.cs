using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Data;

namespace Business
{
    public class BACountry : BaseClass
    {
        public BACountry()
            : base()
        { }

        
        public BACountry(TraderMarketPlaceEntities entities)
            : base(entities)
        { }

        public IQueryable<Country> GetCountries()
        {
            return new DACountry(Entities).GetCountries();
        }

        public Country GetCountry(Guid id)
        {
            return new DACountry(Entities).GetCountry(id);
        }
    }
}
