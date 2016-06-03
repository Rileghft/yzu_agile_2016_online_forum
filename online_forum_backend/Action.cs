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
            db.insertUser(account, password);
            bool result = db.insertUser(account, password);
            if (result==true)
                return true;
            else
                return false;
        }
    }
}
