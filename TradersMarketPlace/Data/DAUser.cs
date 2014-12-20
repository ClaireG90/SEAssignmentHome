using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DAUser : Connection
    {
        public DAUser()
            : base()
        { }

        public DAUser(TraderMarketPlaceEntities entities)
            : base(entities)
        { }

        public IQueryable<User> GetUsers()
        {
            return entities.User;
        }

        public User GetUser(Guid id)
        {
            return entities.User.SingleOrDefault(u => u.ID == id);
        }

        public User GetUserByAccount(Guid id)
        {
            return
                (from u in this.entities.User
                 where u.AccountID == id
                 select u).SingleOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return
                (from u in this.entities.User
                 where u.Email == email
                 select u).SingleOrDefault();
        }

        public UserType GetUserRoleByUsername(string username)
        {
            Account a = new DAAccount().GetAccountByUsername(username);

            User u = new DAUser().GetUserByAccount(a.ID);

            return entities.UserType.SingleOrDefault(ut => ut.ID == u.UserTypeID);
        }

        public void AddUser(User user)
        {
            entities.User.AddObject(user);
            entities.SaveChanges();
        }

        public void UpdateUser()
        {
            entities.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            entities.User.DeleteObject(user);
            entities.SaveChanges();
        }
    }
}
