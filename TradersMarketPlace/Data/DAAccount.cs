using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DAAccount : Connection
    {
        public DAAccount()
            : base()
        { }

        public DAAccount(TraderMarketPlaceEntities entities)
            : base(entities)
        { }

        public IQueryable<Account> GetAccounts()
        {
            return entities.Account;
        }

        public Account GetAccount(Guid id)
        {
            return entities.Account.SingleOrDefault(a => a.ID == id);
        }

        public Account GetAccountByUsername(string username)
        {
            return entities.Account.SingleOrDefault(a => a.Username == username);
        }

        public Account GetAccoutByUsernameAndPassword(string username, string password)
        {
            return
                (from a in this.entities.Account
                 where a.Username == username &&
                 a.Password == password
                 select a).SingleOrDefault();
        }

        public void AddAccount(Account account)
        {
            entities.Account.AddObject(account);
            entities.SaveChanges();
        }

        public void UpdateAccount()
        {
            entities.SaveChanges();
        }

        public void DeleteAccount(Account account)
        {
            entities.Account.DeleteObject(account);
            entities.SaveChanges();
        }
    }
}
