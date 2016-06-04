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

            result = action.modifyArticleTitle(db, 0, db.accounts[0], "更新第二次文章標題");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("更新第二次文章標題", Is.EqualTo(db.articles[0].title));

            result = action.modifyArticleTitle(db, 1, db.accounts[0], "更新文章標題22");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("更新文章標題22", Is.EqualTo(db.articles[1].title));

        }

        [Test]
        public void 登入()
        {
            ForumDB db = new ForumDB();
            Action action = new Action();
            bool isLogin = action.signin(db, "teamD", "test");
            Assert.That(true, Is.EqualTo(isLogin));
        }

        [Test]
        public void 登入失敗()
        {
            ForumDB db = new ForumDB();
            Action action = new Action();
            bool isLogin = action.signin(db, "teamA", "1234");
            Assert.That(false, Is.EqualTo(isLogin));
        }

        [Test]
        public void 登出()
        {
            ForumDB db = new ForumDB();
            Action action = new Action();
            bool isLogin = action.signin(db, "teamD", "test");
            Assert.That(true, Is.EqualTo(action.loggedin));
            action.signout(db);
            Assert.That(null, Is.EqualTo(action.user));
            Assert.That(false, Is.EqualTo(action.loggedin));
        }
    }
}
