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
        public void 刪除文章_Action()
        {
            ForumDB db = new ForumDB();
            db.insertArticle("teamD", "bbb", "ccc");
            Action delete = new Action();
            bool result = delete.deleteArticle(db,0,0);
            //Assert.That(true, Is.EqualTo(result));
        }
    }
}
