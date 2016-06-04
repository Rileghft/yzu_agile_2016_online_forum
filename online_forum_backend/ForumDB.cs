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

<<<<<<< HEAD
=======
        internal bool isLogin(Account user)
        {
            bool isExist = false;
            foreach (Account account in accounts)
            {
                if (user == account)
                {
                    isExist = true;
                }
            }
            return isExist;
        }

        internal bool getArticle(int id)
        {
            if (id >= articles.Count)
                return false;
            foreach (Article article in articles)
            {
                if (article.articleID == id)
                    article.content.ToString();
            }

            return true;
>>>>>>> eac6625019961e446301d77c5eb169cdddf3244f

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


        internal bool  getArticle( int id,string account, string title, string content /*,string time*/)
        { 
            int i;
            for (i = 0; i < accounts.Count; i++)
                if (accounts[i].name == account)
                    break;
            if (i == accounts.Count)
                return false;

            Article arti = new Article();
            arti.account = account;
            arti.title = title;
            arti.content = content;
            arti.articleID = id;
            //arti.time = time;
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
            //新增留言到該ID文章
            Comment user = new Comment();
            user.setAccount(userName);
            user.setContent(text);
            string time = DateTime.Now.TimeOfDay.ToString();
            user.setTime(time);
            foreach (Article article in articles)
            {
                if (article.articleID == articleID)
                    article.comment.Add(user);
            }
        }

        internal List<Comment> getComment(int articleID)
        {
            //顯示該ID文章的所有回覆
            List<Comment> empty = new List<Comment>();
            foreach (Article article in articles)
            {
                if (article.articleID == articleID)
                    return article.comment;
                    
            }
            return empty;
        }
   

       internal void grtTitle(string title)
        {

            Article arti = new Article();
            foreach (Article article in articles)
            {
<<<<<<< HEAD
                if (article.articleID >= 0)            
            arti.title = title;
               
=======
                if (article.articleID >= 0)
                   artice[n] = article.title.ToString();
>>>>>>> eac6625019961e446301d77c5eb169cdddf3244f
            }
        }
    }
}