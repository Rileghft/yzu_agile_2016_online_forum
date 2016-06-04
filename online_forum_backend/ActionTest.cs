using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_forum_backend
{
    [TestFixture]
    class ActionTest
    {
        [Test]
        public void 註冊新用戶_Action()
        {
            ForumDB db = new ForumDB();
            Action Register = new Action();
            bool result = Register.register(db,"newaccount", "newpass","newpass");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("newaccount", Is.EqualTo(db.accounts[1].name));
            Assert.That("newpass", Is.EqualTo(db.accounts[1].password));
        }

        [Test]
        public void 註冊新用戶_包含特殊字符_Action()
        {
            ForumDB db = new ForumDB();
            Action Register = new Action();
            bool result = Register.register(db, "********", "********","*******");
            Assert.That(false, Is.EqualTo(result));
        }

        [Test]
        public void 註冊新用戶_密碼長度不合_Action()
        {
            ForumDB db = new ForumDB();
            Action Register = new Action();
            bool result = Register.register(db, "123", "123","123");
            Assert.That(false, Is.EqualTo(result));
        }

        [Test]
        public void 註冊新用戶_第二字密碼不符_Action()
        {
            ForumDB db = new ForumDB();
            Action Register = new Action();
            bool result = Register.register(db, "1234567", "1234567", "12345678");
            Assert.That(false, Is.EqualTo(result));
        }

        [Test]
        public void 取得文章標題_Action()
        {
            ForumDB db = new ForumDB();
            Action Title = new Action();
            db.insertArticle("teamD","For_Test","Hello world");
            string result = Title.getArticleHeaderList(db,1);
            Assert.That("For_Test", Is.EqualTo(result));
        }

        [Test]
        public void 取得文章標題_更新日期_Action()
        {
            ForumDB db = new ForumDB();
            Action Title = new Action();
            db.insertArticle("teamD", "For_Test", "Hello world");
            string result = Title.getArticleHeaderList(db, 1);
            Assert.That("2016/6/4 上午 12:00:00", Is.EqualTo(db.articles[0].time));
        }

        [Test]
        public void 刪除文章_Action()
        {
            ForumDB db = new ForumDB();
            Assert.That(true,  Is.EqualTo(db.insertArticle("teamD", "bbb", "ccc")));          
            Action delete = new Action();

            bool result = delete.deleteArticle(db,0,db.accounts[0]);
            Assert.That(true, Is.EqualTo(result));
           // Assert.That(true, Is.EqualTo(result));

        }

        [Test]
        public void 編輯文章標題_Action()
        {
            ForumDB db = new ForumDB();
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題", "文章內容")));
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題22", "文章內容22")));
            Action action = new Action();

            bool result = action.modifyArticleTitle(db, 0, db.accounts[0], "更新文章標題");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("更新文章標題", Is.EqualTo(db.articles[0].title));
            Assert.That("文章內容"    , Is.EqualTo(db.articles[0].content));

            result = action.modifyArticleTitle(db, 0, db.accounts[0], "更新第二次文章標題");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("更新第二次文章標題", Is.EqualTo(db.articles[0].title));
            Assert.That("文章內容", Is.EqualTo(db.articles[0].content));

            result = action.modifyArticleTitle(db, 1, db.accounts[0], "更新文章標題22");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("更新文章標題22", Is.EqualTo(db.articles[1].title));
            Assert.That("文章內容22", Is.EqualTo(db.articles[1].content));

        }

        [Test]
        public void 編輯文章內容_Action()
        {
            ForumDB db = new ForumDB();
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題", "文章內容")));
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題22", "文章內容22")));
            Action action = new Action();

            bool result = action.modifyArticleContent(db, 0, db.accounts[0], "更新文章內容");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("文章標題"    , Is.EqualTo(db.articles[0].title));
            Assert.That("更新文章內容", Is.EqualTo(db.articles[0].content));

            result = action.modifyArticleContent(db, 0, db.accounts[0], "更新第二次文章內容");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("文章標題"         , Is.EqualTo(db.articles[0].title));
            Assert.That("更新第二次文章內容", Is.EqualTo(db.articles[0].content));

            result = action.modifyArticleContent(db, 1, db.accounts[0], "更新文章內容22");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("文章標題22"    , Is.EqualTo(db.articles[1].title));
            Assert.That("更新文章內容22", Is.EqualTo(db.articles[1].content));

        }
    }
}
