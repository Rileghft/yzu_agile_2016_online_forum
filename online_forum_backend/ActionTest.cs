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
        public void 註冊新用戶()
        {
            ForumDB db = new ForumDB();
            Action Register = new Action();
            Register.register("newaccount", "newpass");
            bool result = Register.register("newaccount", "newpass");
            Assert.That(false, Is.EqualTo(result));
            //Assert.That("newaccount", Is.EqualTo(db.accounts[1].name));
            //Assert.That("newpass", Is.EqualTo(db.accounts[1].password));
        }
    }
}
