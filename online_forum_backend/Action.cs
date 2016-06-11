using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_forum_backend
{

    class Action
    {
        public Account user;
        public bool loggedin;

        public bool register(ForumDB db, string account, string password ,string cofirmpass)
        {
            string[] special = {"!","@","#","$","%","^","&","*","(",")","_","=","<",">","/"};
            for (int i = 0; i < special.Count(); i++)
            {
                if (account.Contains(special[i]))
                    return false;
            }

            if (password.Count() < 6 || password.Count() > 16)
                return false;

            if (password != cofirmpass)
                return false;

            if (db.insertUser(account, password))
                return true;
            else
                return false;
        }

        public bool signin(ForumDB db, string account, string password)
        {
            user = db.getUser(account, password);
            if (user != null)
            {
                loggedin = true;
                return true;
            }
            else
                return false;

        }

        public string signout(ForumDB db)
        {
            if (loggedin)
            {
                loggedin = false;
                user = null;
                return "log out ";
            }
            else
            {
                return "please log in firstly!";
            }

        }
        public bool deleteArticle(ForumDB db, int articleID, Account user) // modify parameter
        {
            // 判斷刪除文章是否為作者本人
            if (articleID >= db.articles.Count)
                return false;

            if (db.articles[articleID].account != user.getName())
                return false;

            if (db.deleteArticle(articleID))
                return true;
            else
                return false;
        }
        public string addArticle(ForumDB db, Account user,string title,string content)
        {
            string account = user.name;
            if (!db.insertArticle(account, title, content))
            {
                return "Error";
            }
            else
            {
                db.insertArticle(account, title, content);
                return content;
            }

        }
        public string addComment(ForumDB db, Account user, Article art,string content)
        {
            if (!db.isLogin(user))
            {
                return "Error";
            }
            else
            {
                db.insertComment(content, user.name, art.articleID);
                return content;
            }

        }

        internal string getArticleHeaderList(ForumDB db,int ArticleID)
        {
            string result;
            result = db.getTitle(ArticleID);
            return result;
        }

        public bool modifyArticleContent(ForumDB db, int articleID, Account user, string content)
        {
            if (articleID >= db.articles.Count)
                return false;

            if (db.articles[articleID].account != user.getName())
                return false;

            db.articles[articleID].content = content;
            return true;
        }
        
        public bool modifyArticleTitle(ForumDB db, int articleID, Account user, string title)
        {
            if (articleID >= db.articles.Count)
               return false;
            if (db.articles[articleID].account != user.getName())
               return false;
            db.articles[articleID].title = title;
            return true;
        }
        
        public List<Article> searchArticleTitle( ForumDB db, string searchKey )
        {
            List<Article> list = new List<Article>();
            for (int i = 0; i < db.articles.Count; i++ )
            {
                if (db.articles[i].title.Contains(searchKey))
                    list.Add(db.articles[i]);
            }
            
            return list;
        }

        public List<Article> searchArticleContent(ForumDB db, string searchKey)
        {
            List<Article> list = new List<Article>();
            for (int i = 0; i < db.articles.Count; i++)
            {
                if (db.articles[i].content.Contains(searchKey))
                    list.Add(db.articles[i]);
            }

            return list;
        }

    }
}
