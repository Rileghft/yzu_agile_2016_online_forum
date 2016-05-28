using System;
using System.Collections.Generic;

namespace online_forum_backend
{
    internal class ForumDB
    {
        public List<Account> accounts;
        
        public ForumDB()
        {
            accounts = new List<Account>();
            int id = accounts.Count;
            Account defaultAccount = new Account(id);
            defaultAccount.name = "teamD";
            defaultAccount.password = "test";
            accounts.Add(defaultAccount);
        }

        internal Account getUser(string userName, string passwd)
        {
            Account account = null;
            foreach(Account user in accounts)
            {
                if(user.name.Equals(userName) && user.password.Equals(passwd))
                {
                    account = user;
                }
            }
            return account;
        }

        internal bool insertUser(string userName, string passwd)
        {
            if (getUser(userName, passwd) == null)
            {
                int id = accounts.Count;
                Account newUser = new Account(id);
                newUser.name = userName;
                newUser.password = passwd;
                accounts.Add(newUser);
                return true;
            }
            else return false;
        }
    }
}