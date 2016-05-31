using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace online_forum_backend
{
    class Comment
    {
        private string account;
        private string content;
        private string time;

        public void setAccount(string Name)
        {
            account = Name;
        }

        public void setContent(string text)
        {
            content = text;
        }

        public void setTime(string t)
        {
            time = t;
        }

        public string getAccount()
        {
            return account;
        }

        public string getContent()
        {
            return content;
        }

        public string getTime()
        {
            return time;
        }
    }
}
