using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_forum_backend
{

    class Action
    {
        


        public bool register(string account, string password)
        {
            ForumDB db = new ForumDB();
            //db.insertUser(account, password);
            if (db.insertUser(account, password))
                return true;
            else
                return false;
        }

        public bool deleteArticle(int articleID, Account user, ForumDB db) // modify parameter
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
    }
}
