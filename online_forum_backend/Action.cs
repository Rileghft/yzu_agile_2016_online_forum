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
        private string pattern;

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
            
            if (db.articles[articleID].account != (string)user.getName())
                return false;

            if (db.deleteArticle(articleID))
                return true;
            else
                return false;
        }

        public string addArticle(ForumDB db, Account user, string title, string summary, string content)
        {
            string account = user.name;
            if (!db.insertArticle(account, title, summary, content, pattern))
            {
                return "Error";
            }
            else
            {
                db.insertArticle(account, title, summary, content, pattern);
                return content;
            }

        }
        public bool insert_Patterns_into_Article(ForumDB db, int articleID, string patterns)
        {
            db.articles[articleID].patterns = patterns;
            return true;
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
                user.score++;
                return content;
            }

        }
        public bool deleteComment(ForumDB db, int articleID, Account user)
        {
            // 判斷刪除文章是否為作者本人
            if (articleID >= db.articles.Count)
                return false;

            if (db.articles[articleID].account != (string)user.getName())
                return false;

            if (db.deleteComment((string)user.getName(), articleID))
                return true;
            else
                return false;
        }

        internal string getArticleHeaderList(ForumDB db,int ArticleID)
        {
            string result;
            result = db.getTitle(ArticleID);
            return result;
        }

        public bool modifyArticleContent(ForumDB db, int articleID, Account user, string content,string patterns)
        {
            if (articleID >= db.articles.Count)
                return false;

            if (db.articles[articleID].account != (string)user.getName())
                return false;

            db.articles[articleID].content = content;
            db.articles[articleID].patterns = patterns;
            return true;
        }
        
        public bool modifyArticleTitle(ForumDB db, int articleID, Account user, string title)
        {
            if (articleID >= db.articles.Count)
               return false;
            if (db.articles[articleID].account != (string)user.getName())
               return false;
            db.articles[articleID].title = title;
            return true;
        }

        public bool modifyArticleSummary(ForumDB db, int articleID, Account user, string summary)
        {
            if (articleID >= db.articles.Count)
                return false;
            if (db.articles[articleID].account != (string)user.getName())
                return false;
            db.articles[articleID].summary = summary;
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

        public List<Article> searchArticleSummary(ForumDB db, string searchKey)
        {
            List<Article> list = new List<Article>();
            for (int i = 0; i < db.articles.Count; i++)
            {
                if (db.articles[i].summary.Contains(searchKey))
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

        public List<Article> searchArticleAll(ForumDB db, string searchKey)
        {
            List<Article> list = new List<Article>();
            for (int i = 0; i < db.articles.Count; i++)
            {
                if (db.articles[i].title.Contains(searchKey) ||
                    db.articles[i].summary.Contains(searchKey) ||
                    db.articles[i].content.Contains(searchKey))
                    list.Add(db.articles[i]);
            }

            return list;
        }

        public string getArticle(ForumDB db, int articleID)
        {
            return db.getArticle(articleID);//透過資料庫動作讀取文章
        }

        public int getReads(ForumDB db, int articleID)
        {
            return db.getReads(articleID);//透過資料庫動作取得該篇文章讀取次數
        }
    }
}
