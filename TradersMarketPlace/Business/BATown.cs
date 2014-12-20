using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Data;

namespace Business
{
    public class BATown : BaseClass
    {
        public BATown()
            : base()
        { }

        public BATown(TraderMarketPlaceEntities entities)
            : base(entities)
        { }

        public IQueryable<Town> GetTowns()
        {
            return new DATown(Entities).GetTowns();
        }

        public Town GetTown(Guid id)
        {
            return new DATown(Entities).GetTown(id);
        }

        public Town GetTownByName(string name)
        {
            return new DATown(Entities).GetTownByName(name);
        }

        public IQueryable<Town> GetTownsByCountry(Guid id)
        {
            return new DATown(Entities).GetTownsByCountry(id);
        }
    }
}
