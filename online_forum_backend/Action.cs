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


        public bool deleteArticle(ForumDB db ,int articleID, int userID)
        {
            if (db.deleteArticle(articleID))
                return true;
            else
                return false;
        }
    }
}
