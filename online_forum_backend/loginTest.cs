﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace online_forum_backend
{
    [TestFixture]
    class loginTest
    {
        [Test]
        public void 是否登录成功()
        {
            login db = new login();
            AccountDB user = db.Signin("lee", "1234");
            Assert.That("1234", Is.EqualTo(user.getPasswd()));
            Assert.That(0, Is.EqualTo(user.getID()));
        }

        [Test]
        public void 添加文章()
        {
            login db = new login();
            Assert.That(true, Is.EqualTo(db.addArticle("lee", "測試文章內容")));
            Assert.That("lee", Is.EqualTo(db.accounts[0].userName));
            Assert.That("測試文章內容", Is.EqualTo(db.accounts[0].content));

        }
    }
}