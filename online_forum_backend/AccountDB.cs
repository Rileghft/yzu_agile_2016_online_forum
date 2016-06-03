using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_forum_backend
{
    class AccountDB
    {
        public int userID
        {
            get;
            set;
        }
        public String name
        {
            get;
            set;
        }
        public String password
        {
            get;
            set;
        }
         public AccountDB(int id)
        {
            userID = id;
        }


        internal object getName()
        {
            return name;
        }
        internal object getID()
        {
            return userID;
        }
        internal object getPasswd()
        {
            return password;
        }

    }
 
}
