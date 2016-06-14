using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_forum_backend
{
    class Article
    {
        public string account { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int articleID { get; set; }
        public string time { get; set; }
        public List<Comment> comment { get; set; }
        public int read { get; set; } //該篇文章瀏覽次數
   
        public Article()
        {
            comment = new List<Comment>();
            read = 0;
        }
    }
}
