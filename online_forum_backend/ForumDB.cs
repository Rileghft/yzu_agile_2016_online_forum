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

        internal string getArticle(int id)
        {
            foreach (Article article in articles)
            {
                if (article.articleID == id)
                {
                    article.read++;//抓取文章，則瀏覽次數加一
                    return article.content.ToString();
                }
            }
            return "None";
        }

        internal bool insertArticle(string account, string title, string summary, string content,string pattern)
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
            arti.patterns = pattern;
            arti.summary = summary;
            arti.articleID = id;
            //DateTime thisDay = DateTime.Today;
            arti.time = DateTime.Now.ToLongDateString().ToString();
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
   
        internal string getTitle(int n)
        {
            foreach (Article article in articles)
            {

                if (article.articleID == n)
                   return  article.title.ToString();

            }
            return "None";
        }

        internal int getReads(int n)
       {
           foreach (Article article in articles)
           {

               if (article.articleID == n)
                   return article.read;

           }
           return 0;
       }
        internal List<Collect> getcollect(int articleID)
       {
          
      List<Collect> read = new List<Collect>();

           foreach (Article article in articles)
           {
               if (article.articleID == articleID)
                   return article.collect;
           }                  
           return read;
           
       }

        internal void insertArticle(string p1, string p2, string p3, string p4)
        {
            throw new NotImplementedException();
        }
    }
}