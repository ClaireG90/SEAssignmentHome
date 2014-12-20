using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DAUserType : Connection
    {
        public DAUserType()
            : base()
        { }

        public DAUserType(TraderMarketPlaceEntities entities)
            : base(entities)
        { }

        public IQueryable<UserType> GetRoles()
        {
            return entities.UserType;
        }

        public UserType GetRole(Guid id)
        {
            return entities.UserType.SingleOrDefault(r => r.ID == id);
        }

        public UserType GetRoleByName(string name)
        {
            return entities.UserType.SingleOrDefault(r => r.UserType1 == name);
        }

        public void AddRole(UserType role)
        {
            entities.UserType.AddObject(role);
            entities.SaveChanges();
        }

        public void UpdateRole()
        {
            entities.SaveChanges();
        }

        public void DeleteRole(UserType role)
        {
            entities.UserType.DeleteObject(role);
            entities.SaveChanges();
        }
    }
}
