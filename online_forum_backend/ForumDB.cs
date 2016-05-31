using System;
using System.Collections.Generic;

namespace online_forum_backend
{
    internal class ForumDB
    {
        public List<Account> accounts;
        public List<Article> articles;
        
        public ForumDB()
        {
            accounts = new List<Account>();
            articles = new List<Article>();
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

        internal bool  insertArticle( string account, string title, string content )
        { // 如果沒有這個帳戶使用者，回傳false
            int i;
            for (i = 0; i < accounts.Count; i++)
                if (accounts[i].name == account)
                    break;
            if (i == accounts.Count)
                return false;

            Article arti = new Article();
            int id = articles.Count;
            arti.account = account;
            arti.title = title;
            arti.content = content;
            arti.articleID = id;
            DateTime thisDay = DateTime.Today;
            arti.time = thisDay.ToString();
            articles.Add(arti);
            return true;

        }

        internal bool deleteArticle(int id)
        { // 如果沒有此文章id，回傳false
            if (id >= articles.Count)
                return false;
            articles.RemoveAt(id);
            return true;

        }
    }
}