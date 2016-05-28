using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
