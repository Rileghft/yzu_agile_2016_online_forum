using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_forum_backend
{
    internal class login
    {
        public List<AccountDB> accounts;
        //public List<AccountDB> contents;
        public login()
        {
            accounts = new List<AccountDB>();
            int id = accounts.Count;
            AccountDB SomeUser = new AccountDB(id);
            //SomeUser.userID = 123;
            SomeUser.name = "lee";
            SomeUser.password = "1234";
            accounts.Add(SomeUser);
        }
        public AccountDB Signin(string userName, string passwd)
        {
            AccountDB account = null;
            foreach (AccountDB user in accounts)
            {
                if (user.name.Equals(userName) && user.password.Equals(passwd))
                {
                    account = user;
                    Console.Write("successfully logged in");
                }
                else
                {
                    Console.Write("failed");
                }
            }
            return account;

        }
        internal bool addArticle(string userName, string content)
        {
            int i;
            for (i = 0; i < accounts.Count; i++)
                if (accounts[i].name == userName.ToString())
                    break;
            if (i == accounts.Count)
                return false;
            AccountDB contents = null;
            int id = accounts.Count;
            contents.userName = userName;
            contents.content = content;
            accounts.Add(contents);
            return true;

        }
    }

}
