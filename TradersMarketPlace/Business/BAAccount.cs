using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Common;

namespace Business
{
    public enum LoginResult { Success, UsernameDoesNotExist, PasswordIncorrect, Error }

    public class BAAccount : BaseClass
    {
        public BAAccount()
            : base()
        { }


 
        public BAAccount(TraderMarketPlaceEntities entities)
            : base(entities)
        { }

        public IQueryable<Account> GetAccounts()
        {
            return new DAAccount(Entities).GetAccounts();
        }

        public Account GetAccount(Guid id)
        {
            return new DAAccount(Entities).GetAccount(id);
        }

        public Account GetAccountByUsername(string username)
        {
            return new DAAccount(Entities).GetAccountByUsername(username);
        }

        public Account GetAccountByUsernameAndPassword(string username, string password)
        {
            return new DAAccount(Entities).GetAccoutByUsernameAndPassword(username, password);
        }

        public void AddAccount(Account account)
        {
            new DAAccount(this.Entities).AddAccount(account);
        }

        public void UpdateAccount()
        {
            new DAAccount(this.Entities).UpdateAccount();
        }

        public void DeleteAccount(Account account)
        {
            new DAAccount(this.Entities).DeleteAccount(account);
        }

        public LoginResult Login(string username, string password)
        {
            LoginResult result = LoginResult.Success;
            Account account = new DAAccount().GetAccoutByUsernameAndPassword(username, password);

            if (account == null)
                result = LoginResult.Error;

            else if (!account.Password.Equals(password))
                result = LoginResult.PasswordIncorrect;

            else if (account.Username == username && account.Password == password)
                result = LoginResult.Success;

            else
                result = LoginResult.Error;

            return result;
        }
    }
}
