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

        public bool deleteArticle(int articleID, int userID)
        {
            ForumDB db = new ForumDB();
            if (db.deleteArticle(articleID))
                return true;
            else
                return false;
        }
    }
}
