using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Data;

namespace Business
{
    public class BAUserType : BaseClass
    {
        public BAUserType()
            : base()
        {
        }

        public BAUserType(TraderMarketPlaceEntities entities)
            : base(entities)
        { }

        public IQueryable<UserType> GetRoles()
        {
            return new DAUserType(Entities).GetRoles();
        }

        public UserType GetRole(Guid id)
        {
            return new DAUserType(Entities).GetRole(id);
        }

        public UserType GetRoleByName(string name)
        {
            return new DAUserType(Entities).GetRoleByName(name);
        }

        public void AddRole(UserType role)
        {
            new DAUserType(this.Entities).AddRole(role);
        }

        public void UpdateRole()
        {
            new DAUserType(this.Entities).UpdateRole();
        }

        public void DeleteRole(UserType role)
        {
            new DAUserType(this.Entities).DeleteRole(role);
        }
    }
}
