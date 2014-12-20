using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Data;

namespace Business
{
    public class BaseClass
    {
        public TraderMarketPlaceEntities Entities { get; set; }

        public BaseClass()
        {
            try
            {
                Connection con = new Connection();
                this.Entities = con.entities;
            }
            catch (Exception ex)
            {
            }
        }
        public BaseClass(TraderMarketPlaceEntities entities)
        {
            try
            {
                this.Entities = entities;
            }
            catch (Exception ex)
            { }
        }
    }
}
