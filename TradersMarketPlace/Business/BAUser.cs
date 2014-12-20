using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Data;

namespace Business
{


    public class BAUser : BaseClass
    {
        bool isUser;

        public enum RegistrationResult { Successful, UsernamExists, EmailExists }

        public BAUser()
            : base()
        { }

        public BAUser(TraderMarketPlaceEntities entities)
            : base(entities)
        { }

        public IQueryable<User> GetUsers()
        {
            return new DAUser(Entities).GetUsers();
        }

        public User GetUser(Guid id)
        {
            return new DAUser(Entities).GetUser(id);
        }

        public User GetUserByAccount(Guid id)
        {
            return new DAUser(Entities).GetUserByAccount(id);
        }

        public User GetUserByEmail(string email)
        {
            return new DAUser(Entities).GetUserByEmail(email);
        }

        public void AddUser(User user)
        {
            new DAUser(this.Entities).AddUser(user);
        }

        public void UpdateUser()
        {
            new DAUser(this.Entities).UpdateUser();
        }

        public void DeleteUser(User user)
        {
            new DAUser(this.Entities).DeleteUser(user);
        }

        public UserType GetUserRoleByUsername(string username)
        {
            return new DAUser().GetUserRoleByUsername(username);
        }

        public RegistrationResult AddUser(User user, Guid role, Account ac)
        {
            RegistrationResult result = RegistrationResult.Successful;
            BAAccount baAccount = new BAAccount();
            Account a = baAccount.GetAccountByUsername(ac.Username);
            User u = GetUserByEmail(user.Email);

            if (a == null && u == null)
            {
                baAccount.AddAccount(ac);
                
                new DAUser(this.Entities).AddUser(user);
                user.UserTypeID = role;
                result = RegistrationResult.Successful;
            }
            else
            {
                if (a != null)
                {
                    result = RegistrationResult.UsernamExists;
                }
                else
                {
                    result = RegistrationResult.EmailExists;
                }
            }
            return result;
        }
    }
}
