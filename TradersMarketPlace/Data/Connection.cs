using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class Connection
    {
        public TraderMarketPlaceEntities entities;

        public Connection(TraderMarketPlaceEntities entities)
        {
            this.entities = entities;
        }

        public Connection()
        {
            entities = new TraderMarketPlaceEntities();
        }
    }
}
