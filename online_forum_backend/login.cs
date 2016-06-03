using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_forum_backend
{
    class login
    {
        public List<AccountDB> accounts;
        public login()
        {
            accounts = new List<AccountDB>();
            int id = accounts.Count;
            AccountDB SomeUser = new AccountDB(id);
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
    }
}
