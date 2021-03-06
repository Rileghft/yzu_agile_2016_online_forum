﻿using NUnit.Framework;
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

            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "測試新文章標題", "測試摘要", "測試文章內容", "picture1")));
            Assert.That("teamD"           , Is.EqualTo(db.articles[0].account));
            Assert.That("測試新文章標題"  , Is.EqualTo(db.articles[0].title));
            Assert.That("測試摘要"        , Is.EqualTo(db.articles[0].summary));
            Assert.That("測試文章內容"    , Is.EqualTo(db.articles[0].content));
            Assert.That("picture1"        , Is.EqualTo(db.articles[0].patterns));
            Assert.That(0                 , Is.EqualTo(db.articles[0].articleID));
            //DateTime thisDay = DateTime.Today;
            Assert.That(DateTime.Now.ToLongDateString().ToString(), Is.EqualTo(db.articles[0].time));

            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "測試新文章標題2", "測試摘要2", "測試文章內容2", "picture1")));
            Assert.That("teamD"           , Is.EqualTo(db.articles[1].account));
            Assert.That("測試新文章標題2" , Is.EqualTo(db.articles[1].title));
            Assert.That("測試摘要2"       , Is.EqualTo(db.articles[1].summary));
            Assert.That("測試文章內容2"   , Is.EqualTo(db.articles[1].content));
            Assert.That("picture1", Is.EqualTo(db.articles[1].patterns));
            Assert.That(1                 , Is.EqualTo(db.articles[1].articleID));
            //thisDay = DateTime.Today;
            Assert.That(DateTime.Now.ToLongDateString().ToString(), Is.EqualTo(db.articles[1].time));

        }

        [Test]
        public void 插入新文章失敗()
        {
            ForumDB db = new ForumDB();
            Assert.That(false, Is.EqualTo(db.insertArticle("123", "測試新文章標題", "測試摘要", "測試文章內容", "picture1")));
            Assert.That(false, Is.EqualTo(db.insertArticle("test222", "測試新文章標題", "測試摘要", "測試文章內容", "picture1")));
            Assert.That(false, Is.EqualTo(db.insertArticle("teamB", "測試新文章標題", "測試摘要", "測試文章內容", "picture1")));

        }

        [Test]
        public void 刪除文章()
        {
            ForumDB db = new ForumDB();
            Account user = db.getUser("teamD", "test");
           
            Assert.That(false, Is.EqualTo( db.deleteArticle(0) ));

            db.insertArticle("teamD", "測試新文章標題" , "測試摘要" , "測試文章內容","pictures1");
            db.insertArticle("teamD", "測試新文章標題2", "測試摘要2", "測試文章內容2","pictures1");
            db.insertArticle("teamD", "測試新文章標題3", "測試摘要3", "測試文章內容3", "pictures1");

            Assert.That(true, Is.EqualTo(db.deleteArticle(0)));
            Assert.That(2, Is.EqualTo(db.articles.Count));
            Assert.That("teamD"            , Is.EqualTo(db.articles[0].account));
            Assert.That("測試新文章標題2"  , Is.EqualTo(db.articles[0].title));
            Assert.That("測試摘要2"        , Is.EqualTo(db.articles[0].summary));
            Assert.That("測試文章內容2"    , Is.EqualTo(db.articles[0].content));
            Assert.That("pictures1"        , Is.EqualTo(db.articles[0].patterns));
            Assert.That("teamD"            , Is.EqualTo(db.articles[1].account));
            Assert.That("測試新文章標題3"  , Is.EqualTo(db.articles[1].title));
            Assert.That("測試摘要3"        , Is.EqualTo(db.articles[1].summary));
            Assert.That("測試文章內容3"    , Is.EqualTo(db.articles[1].content));
            Assert.That("pictures1"        , Is.EqualTo(db.articles[1].patterns));
            Assert.That(true, Is.EqualTo(db.deleteArticle(0)));
            Assert.That(1, Is.EqualTo(db.articles.Count));
            Assert.That("teamD", Is.EqualTo(db.articles[0].account));
            Assert.That("測試新文章標題3", Is.EqualTo(db.articles[0].title));
            Assert.That("測試摘要3"      , Is.EqualTo(db.articles[0].summary));
            Assert.That("測試文章內容3"  , Is.EqualTo(db.articles[0].content));
            Assert.That("pictures1", Is.EqualTo(db.articles[0].patterns));
            Assert.That(true, Is.EqualTo(db.deleteArticle(0)));
            Assert.That(0, Is.EqualTo(db.articles.Count));

        }

        [Test]
        public void 刪除評論()
        {
            ForumDB db = new ForumDB();
            Account user = db.getUser("teamD", "test");

            Assert.That(false, Is.EqualTo(db.deleteComment("teamD", 0)));

            db.insertArticle("teamD", "測試新文章標題", "測試摘要", "測試文章內容","");
            db.insertArticle("teamD", "測試新文章標題2", "測試摘要2", "測試文章內容2","");
            db.insertArticle("teamA", "測試新文章標題3", "測試摘要3", "測試文章內容3","");
            db.insertComment("測試評論內容", "teamD", 0);
            db.insertComment("測試評論內容1", "teamD", 1);
            //db.insertComment("測試評論內容2", "teamD", 2);

            Assert.That(true, Is.EqualTo(db.deleteComment("teamD", 0)));
            Assert.That(true, Is.EqualTo(db.deleteComment("teamD", 1)));

            Assert.That(false, Is.EqualTo(db.deleteComment("teamA", 2)));

        }

        [Test]
        public void 插入顯示文章()
        {
            ForumDB db = new ForumDB();

            db.insertArticle("teamD", "測試新文章標題", "測試摘要", "測試文章內容", "測試文章內圖片");//articleID 0

            db.insertComment("這篇文章很讚", "cyZeng", 0); 
            db.insertComment("這篇文章很無聊", "Kevin", 0);
            List<Comment> match = db.getComment(0);
            Assert.That("這篇文章很讚", Is.EqualTo(match[0].getContent()));
            Assert.That("這篇文章很無聊", Is.EqualTo(match[1].getContent()));


            db.insertArticle("teamD", "測試新文章標題2", "測試摘要", "測試文章內容2", "測試文章內圖片");//articleID 1
            db.insertComment("Cool", "Lee", 1);
            List<Comment> match2 = db.getComment(1);
            Assert.That("Cool", Is.EqualTo(match2[0].getContent()));
        }
         [Test]
        public void 讀取文章內容()
        {
            ForumDB db = new ForumDB();

            db.insertArticle("teamD", "測試新文章標題", "測試摘要", "測試文章內容","測試文章內圖片");
            //Assert.That("測試文章內容", Is.EqualTo(db.getArticle(0)));
            Assert.That("teamD", Is.EqualTo(db.articles[0].account));
            Assert.That("測試新文章標題", Is.EqualTo(db.articles[0].title));
            Assert.That("測試文章內容", Is.EqualTo(db.articles[0].content));
            Assert.That("測試文章內圖片",Is.EqualTo(db.articles[0].patterns));
            Assert.That(0, Is.EqualTo(db.articles[0].articleID));
           
        }
        [Test]
         public void 讀取文章圖片()
         {
             ForumDB db = new ForumDB();

             db.insertArticle("teamD", "測試新文章標題", "測試摘要", "測試文章內容", "測試文章內圖片");
             Assert.That("測試文章內圖片", Is.EqualTo(db.articles[0].patterns));
             Assert.That(0, Is.EqualTo(db.articles[0].articleID));
         }

         [Test]
         public void 讀取文章列表()
         {
             ForumDB db = new ForumDB();
             db.insertArticle("teamD", "測試新文章標題", "測試摘要", "測試文章內容","測試文章內圖片");
             Assert.That("測試新文章標題", Is.EqualTo(db.getTitle(0)));
             Assert.That("None", Is.EqualTo(db.getTitle(1)));
     
         }

        [Test]
        public void 新增文章的類別屬性()
        {
            ForumDB db = new ForumDB();

            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "diablo3", "abstract1", "content1", "picture1", "game")));
            Assert.That("teamD"           , Is.EqualTo(db.articles[0].account));
            Assert.That("diablo3"  , Is.EqualTo(db.articles[0].title));
            Assert.That("abstract1"        , Is.EqualTo(db.articles[0].summary));
            Assert.That("content1"    , Is.EqualTo(db.articles[0].content));
            Assert.That("picture1"        , Is.EqualTo(db.articles[0].patterns));
            Assert.That("game", Is.EqualTo(db.articles[0].type));
            Assert.That(0                 , Is.EqualTo(db.articles[0].articleID));
            Assert.That(DateTime.Now.ToLongDateString().ToString(), Is.EqualTo(db.articles[0].time));

            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "flower", "abstract2", "content2", "picture2", "plant")));
            Assert.That("teamD"           , Is.EqualTo(db.articles[1].account));
            Assert.That("flower" , Is.EqualTo(db.articles[1].title));
            Assert.That("abstract2"       , Is.EqualTo(db.articles[1].summary));
            Assert.That("content2"   , Is.EqualTo(db.articles[1].content));
            Assert.That("picture2", Is.EqualTo(db.articles[1].patterns));
            Assert.That("plant", Is.EqualTo(db.articles[1].type));
            Assert.That(1                 , Is.EqualTo(db.articles[1].articleID));
            Assert.That(DateTime.Now.ToLongDateString().ToString(), Is.EqualTo(db.articles[1].time));

        }
    }
}
