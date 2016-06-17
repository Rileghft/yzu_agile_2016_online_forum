using System;

namespace online_forum_backend
{
    internal class Account
    {
        private int userID { get; set; }
        public String name { get; set; }
        public String password { get; set; }
        public int score;

        public Account(int id)
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
    }
}