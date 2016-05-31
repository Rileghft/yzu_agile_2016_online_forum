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
        private int articleID; //新增文章ID，這樣才知道是哪個文章的回覆

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

        public void setArticleID(int id)
        {
            articleID = id;
        }

        public string getAccount()
        {
            return account;
        }

        public string getContent()
        {
            return content;
        }

        public int getArticleID()
        {
            return articleID;
        }

        public string getTime()
        {
            return time;
        }
    }
}
