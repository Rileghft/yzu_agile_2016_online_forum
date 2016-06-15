using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace online_forum_backend
{
    class Collect
    {
        private string account;
        private string title;
        private int articleID;

        public void setAccount(string Name)
        {
            account = Name;
        }
        public void setTitle(string t)
        {
            title = t;
        }

        public void setarticleID(int ID)
        {
            articleID = ID;
        }

  

        public string getAccount()
        {
            return account;
        }
        public string getTitle()
        {
            return title;
        }
        public int getarticleID()
        {
            return articleID;
        }

       

    
    }
}
