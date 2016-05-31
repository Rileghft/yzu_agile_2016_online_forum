using System;
using System.Collections.Generic;

namespace online_forum_backend
{
    internal class ForumDB
    {
        public List<Account> accounts;
        public List<Article> articles;
        public List<Comment> comments;
        
        public ForumDB()
        {
            accounts = new List<Account>();
            articles = new List<Article>();
            comments = new List<Comment>();
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

        internal void insertComment(string text, string userName, int articleID)
        {
            Comment user = new Comment();
            user.setAccount(userName);
            user.setContent(text);
            user.setArticleID(articleID);
            string time = DateTime.Now.TimeOfDay.ToString();
            user.setTime(time);
            comments.Add(user);
        }

        internal List<Comment> getComment(int articleID)
        {  
            //列出該文章ID的所有回覆
            List<Comment> match = new List<Comment>();

            foreach (Comment usr in comments)
            {
                if (usr.getArticleID() == articleID)
                    match.Add(usr);
            }
            return match;
        }

    }
}