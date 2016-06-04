﻿using NUnit.Framework;
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
            bool result = Register.register("newaccount", "newpass");
            Assert.That(true, Is.EqualTo(result));
            //Assert.That("newaccount", Is.EqualTo(db.accounts[1].name));
            //Assert.That("newpass", Is.EqualTo(db.accounts[1].password));
        }

        [Test]
        public void 刪除文章()
        {
            ForumDB db = new ForumDB();
            db.insertArticle("teamD", "bbb", "ccc");
            Action delete = new Action();
            bool result = delete.deleteArticle(0,0);
           // Assert.That(true, Is.EqualTo(result));
        }

         [Test]
        public void 新增文章()
        {
            ForumDB db = new ForumDB();
            db.insertArticle("teamD", "測試標題", "測試內容");
            Assert.That("測試標題", Is.EqualTo(db.getTitle(0)));
            //Assert.That("測試內容", Is.EqualTo(db.getArticle(0)));
        }
    }
}