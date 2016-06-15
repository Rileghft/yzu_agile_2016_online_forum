using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// test
namespace online_forum_backend
{
    [TestFixture]
    class ForumDBTest
    {
        [Test]
        public void 驗證使用者()
        {
            ForumDB db = new ForumDB();
            Account user = db.getUser("teamD", "test");
            Assert.That("teamD", Is.EqualTo(user.getName()));
            Assert.That(0, Is.EqualTo(user.getID()));
        }

        [Test]
        public void 插入新使用者()
        {
            ForumDB db = new ForumDB();
            bool isSuccess = db.insertUser("test", "1234");
            Assert.That(true, Is.EqualTo(isSuccess));
            Assert.That("test", Is.EqualTo(db.accounts[1].name));
            Assert.That("1234", Is.EqualTo(db.accounts[1].password));
        }

        [Test]
        public void 插入新文章()
        {
            ForumDB db = new ForumDB();

            
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "測試新文章標題", "測試文章內容")));
            Assert.That("teamD"           , Is.EqualTo(db.articles[0].account));
            Assert.That("測試新文章標題"  , Is.EqualTo(db.articles[0].title));
            Assert.That("測試文章內容"    , Is.EqualTo(db.articles[0].content));
            Assert.That(0                 , Is.EqualTo(db.articles[0].articleID));
            //DateTime thisDay = DateTime.Today;
            Assert.That(DateTime.Now.ToLongDateString().ToString(), Is.EqualTo(db.articles[0].time));

            Assert.That(true, Is.EqualTo( db.insertArticle("teamD", "測試新文章標題2", "測試文章內容2")));
            Assert.That("teamD"           , Is.EqualTo(db.articles[1].account));
            Assert.That("測試新文章標題2" , Is.EqualTo(db.articles[1].title));
            Assert.That("測試文章內容2"   , Is.EqualTo(db.articles[1].content));
            Assert.That(1                 , Is.EqualTo(db.articles[1].articleID));
            //thisDay = DateTime.Today;
            Assert.That(DateTime.Now.ToLongDateString().ToString(), Is.EqualTo(db.articles[1].time));

        }

        [Test]
        public void 插入新文章失敗()
        {
            ForumDB db = new ForumDB();           
            Assert.That(false, Is.EqualTo(db.insertArticle("123", "測試新文章標題", "測試文章內容")));
            Assert.That(false, Is.EqualTo(db.insertArticle("test222", "測試新文章標題", "測試文章內容")));
            Assert.That(false, Is.EqualTo(db.insertArticle("teamB", "測試新文章標題", "測試文章內容")));

        }

        [Test]
        public void 刪除文章()
        {
            ForumDB db = new ForumDB();
            Account user = db.getUser("teamD", "test");
           
            Assert.That(false, Is.EqualTo( db.deleteArticle(0) ));
 
            db.insertArticle("teamD", "測試新文章標題", "測試文章內容");
            db.insertArticle("teamD", "測試新文章標題2", "測試文章內容2");
            db.insertArticle("teamD", "測試新文章標題3", "測試文章內容3");

            Assert.That(true, Is.EqualTo(db.deleteArticle(0)));
            Assert.That(2, Is.EqualTo(db.articles.Count));
            Assert.That("teamD"            , Is.EqualTo(db.articles[0].account));
            Assert.That("測試新文章標題2"  , Is.EqualTo(db.articles[0].title));
            Assert.That("測試文章內容2"    , Is.EqualTo(db.articles[0].content));
            Assert.That("teamD"            , Is.EqualTo(db.articles[1].account));
            Assert.That("測試新文章標題3"  , Is.EqualTo(db.articles[1].title));
            Assert.That("測試文章內容3"    , Is.EqualTo(db.articles[1].content));

            Assert.That(true, Is.EqualTo(db.deleteArticle(0)));
            Assert.That(1, Is.EqualTo(db.articles.Count));
            Assert.That("teamD", Is.EqualTo(db.articles[0].account));
            Assert.That("測試新文章標題3", Is.EqualTo(db.articles[0].title));
            Assert.That("測試文章內容3", Is.EqualTo(db.articles[0].content));

            Assert.That(true, Is.EqualTo(db.deleteArticle(0)));
            Assert.That(0, Is.EqualTo(db.articles.Count));

        }
    


        [Test]
        public void 插入顯示文章()
        {
            ForumDB db = new ForumDB();

            db.insertArticle("teamD", "測試新文章標題", "測試文章內容");//articleID 0
            db.insertComment("這篇文章很讚", "cyZeng", 0); 
            db.insertComment("這篇文章很無聊", "Kevin", 0);
            List<Comment> match = db.getComment(0);
            Assert.That("這篇文章很讚", Is.EqualTo(match[0].getContent()));
            Assert.That("這篇文章很無聊", Is.EqualTo(match[1].getContent()));
           

            db.insertArticle("teamD", "測試新文章標題2", "測試文章內容2");//articleID 1
            db.insertComment("Cool", "Lee", 1);
            List<Comment> match2 = db.getComment(1);
            Assert.That("Cool", Is.EqualTo(match2[0].getContent()));
        }
         [Test]
        public void 讀取文章內容()
        {
            ForumDB db = new ForumDB();

            db.insertArticle("teamD", "測試新文章標題", "測試文章內容");
            //Assert.That("測試文章內容", Is.EqualTo(db.getArticle(0)));
            Assert.That("teamD", Is.EqualTo(db.articles[0].account));
            Assert.That("測試新文章標題", Is.EqualTo(db.articles[0].title));
            Assert.That("測試文章內容", Is.EqualTo(db.articles[0].content));
            Assert.That(0, Is.EqualTo(db.articles[0].articleID));
           
        }

         [Test]
         public void 讀取文章列表()
         {
             ForumDB db = new ForumDB();
             db.insertArticle("teamD", "測試新文章標題", "測試文章內容");
             Assert.That("測試新文章標題", Is.EqualTo(db.getTitle(0)));
             Assert.That("None", Is.EqualTo(db.getTitle(1)));
     
         }
    }
}
