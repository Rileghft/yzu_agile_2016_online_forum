using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_forum_backend
{

    class Action
    {
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
