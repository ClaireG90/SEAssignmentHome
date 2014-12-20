using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DATown : Connection
    {
        public DATown()
            : base()
        { }

        public DATown(TraderMarketPlaceEntities entities)
            : base(entities)
        { }

        public IQueryable<Town> GetTowns()
        {
            return entities.Town;
        }

        public Town GetTown(Guid id)
        {
            return entities.Town.SingleOrDefault(t => t.ID == id);
        }

        public Town GetTownByName(string name)
        {
            return entities.Town.SingleOrDefault(t => t.Town1 == name);
        }

        public IQueryable<Town> GetTownsByCountry(Guid id)
        {
            return
                (from t in this.entities.Town
                 where t.CountryID == id
                 select t);
        }
    }
}
