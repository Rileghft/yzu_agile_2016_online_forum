using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_forum_backend
{
    class getAriticalHeaderList
    {
        public List<Account> accounts;
        public List<Article> articles;
        public string getAriticalHeader(int n)
        {
            string[] artice = new String[20]; ;
            foreach (Article article in articles)
            {
                if (article.articleID >= 0)
                    artice[n] = article.title.ToString();
            }
            return artice[n];
            //进一步完善标题页的显示标题数目...
        }
    }
}
