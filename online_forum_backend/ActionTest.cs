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
            db.insertArticle("teamD", "For_Test", "測試摘要", "Hello world","pictures");
            string result = Title.getArticleHeaderList(db,0);
            Assert.That("For_Test", Is.EqualTo(result));
        }

        [Test]
        public void 取得文章標題_更新日期_Action()
        {
            ForumDB db = new ForumDB();
            Action Title = new Action();
            db.insertArticle("teamD", "For_Test", "測試摘要", "Hello world","pictures");
            string result = Title.getArticleHeaderList(db, 1);
            Assert.That(DateTime.Now.ToLongDateString().ToString(), Is.EqualTo(db.articles[0].time));
        }

        [Test]
        public void 刪除文章_Action()
        {
            ForumDB db = new ForumDB();
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "bbb", "測試摘要", "ccc","picture1")));          
            Action delete = new Action();

            bool result = delete.deleteArticle(db,0,db.accounts[0]);
            Assert.That(true, Is.EqualTo(result));
           // Assert.That(true, Is.EqualTo(result));

        }
        [Test]
        public void 非作者刪除文章_Action()
        {
            ForumDB db = new ForumDB();
            Action register = new Action();
            register.register(db, "hacker", "test123456", "test123456");
            Assert.That(true, Is.EqualTo(db.insertArticle("hacker", "bbb", "測試摘要", "ccc", "picture1")));          
            Action delete = new Action();

            bool result = delete.deleteArticle(db,0,db.accounts[0]);
            Assert.That(false, Is.EqualTo(result));

        }
        [Test]
        public void 編輯文章標題_Action()
        {
            ForumDB db = new ForumDB();
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題", "測試摘要", "文章內容", "picture14")));
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題22", "測試摘要22", "文章內容22", "picture13")));
            Action action = new Action();

            bool result = action.modifyArticleTitle(db, 0, db.accounts[0], "更新文章標題");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("更新文章標題", Is.EqualTo(db.articles[0].title));
            Assert.That("測試摘要", Is.EqualTo(db.articles[0].summary));
            Assert.That("文章內容"    , Is.EqualTo(db.articles[0].content));

            result = action.modifyArticleTitle(db, 0, db.accounts[0], "更新第二次文章標題");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("更新第二次文章標題", Is.EqualTo(db.articles[0].title));
            Assert.That("測試摘要", Is.EqualTo(db.articles[0].summary));
            Assert.That("文章內容", Is.EqualTo(db.articles[0].content));

            result = action.modifyArticleTitle(db, 1, db.accounts[0], "更新文章標題22");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("更新文章標題22", Is.EqualTo(db.articles[1].title));
            Assert.That("測試摘要22", Is.EqualTo(db.articles[1].summary));
            Assert.That("文章內容22", Is.EqualTo(db.articles[1].content));

        }
        [Test]
        public void 非作者編輯文章標題_Action()
        {
            ForumDB db = new ForumDB();
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題", "測試摘要", "文章內容", "picture1")));
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題22", "測試摘要22", "文章內容22", "picture12")));
            Action action = new Action();

            Account not_author = new Account(1);
            not_author.name = "not_author";
            not_author.password = "pw";

            bool result = action.modifyArticleTitle(db, 0, not_author, "更新文章標題");
            Assert.That(false, Is.EqualTo(result));

            result = action.modifyArticleTitle(db, 0, not_author, "更新第二次文章標題");
            Assert.That(false, Is.EqualTo(result));

            result = action.modifyArticleTitle(db, 1, not_author, "更新文章標題22");
            Assert.That(false, Is.EqualTo(result));
        }

        [Test]
        public void 編輯文章摘要_Action()
        {
            ForumDB db = new ForumDB();
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題", "測試摘要", "文章內容", "picture16")));
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題22", "測試摘要22", "文章內容22", "picture15")));
            Action action = new Action();

            bool result = action.modifyArticleSummary(db, 0, db.accounts[0], "更新文章摘要");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("文章標題"          , Is.EqualTo(db.articles[0].title));
            Assert.That("更新文章摘要"      , Is.EqualTo(db.articles[0].summary));
            Assert.That("文章內容", Is.EqualTo(db.articles[0].content));

            result = action.modifyArticleSummary(db, 0, db.accounts[0], "更新第二次文章摘要");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("文章標題"          , Is.EqualTo(db.articles[0].title));
            Assert.That("更新第二次文章摘要", Is.EqualTo(db.articles[0].summary));
            Assert.That("文章內容", Is.EqualTo(db.articles[0].content));

            result = action.modifyArticleSummary(db, 1, db.accounts[0], "更新文章摘要22");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("文章標題22"        , Is.EqualTo(db.articles[1].title));
            Assert.That("更新文章摘要22"    , Is.EqualTo(db.articles[1].summary));
            Assert.That("文章內容22", Is.EqualTo(db.articles[1].content));

        }
        [Test]
        public void 非作者編輯文章摘要_Action()
        {
            ForumDB db = new ForumDB();
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題", "測試摘要", "文章內容", "picture17")));
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題22", "測試摘要22", "文章內容22", "picture18")));
            Action action = new Action();

            Account not_author = new Account(1);
            not_author.name = "not_author";
            not_author.password = "pw";

            bool result = action.modifyArticleSummary(db, 0, not_author, "更新文章摘要");
            Assert.That(false, Is.EqualTo(result));

            result = action.modifyArticleSummary(db, 0, not_author, "更新第二次文章摘要");
            Assert.That(false, Is.EqualTo(result));

            result = action.modifyArticleSummary(db, 1, not_author, "更新文章摘要22");
            Assert.That(false, Is.EqualTo(result));
        }

        [Test]
        public void 編輯文章內容_Action()
        {
            ForumDB db = new ForumDB();
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題", "測試摘要", "文章內容", "picture1")));
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題22", "測試摘要22", "文章內容22", "picture1")));
            Action action = new Action();

            bool result = action.modifyArticleContent(db, 0, db.accounts[0], "更新文章內容","替換文章內圖片");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("文章標題"    , Is.EqualTo(db.articles[0].title));
            Assert.That("測試摘要", Is.EqualTo(db.articles[0].summary));
            Assert.That("更新文章內容", Is.EqualTo(db.articles[0].content));
            Assert.That("替換文章內圖片", Is.EqualTo(db.articles[0].patterns));

            result = action.modifyArticleContent(db, 0, db.accounts[0], "更新第二次文章內容","第二次替換文章內圖片");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("文章標題"         , Is.EqualTo(db.articles[0].title));
            Assert.That("測試摘要", Is.EqualTo(db.articles[0].summary));
            Assert.That("更新第二次文章內容", Is.EqualTo(db.articles[0].content));
            Assert.That("第二次替換文章內圖片", Is.EqualTo(db.articles[0].patterns));

            result = action.modifyArticleContent(db, 1, db.accounts[0], "更新文章內容22", "替換第二篇文章內圖片");
            Assert.That(true, Is.EqualTo(result));
            Assert.That("文章標題22"    , Is.EqualTo(db.articles[1].title));
            Assert.That("測試摘要22", Is.EqualTo(db.articles[1].summary));
            Assert.That("更新文章內容22", Is.EqualTo(db.articles[1].content));
            Assert.That("替換第二篇文章內圖片", Is.EqualTo(db.articles[1].patterns));

        }
        [Test]
        public void 非作者編輯文章內容_Action()
        {
            ForumDB db = new ForumDB();
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題", "測試摘要", "文章內容", "picture1")));
            Assert.That(true, Is.EqualTo(db.insertArticle("teamD", "文章標題22", "測試摘要22", "文章內容22", "picture1")));
            Action action = new Action();

            Account not_author = new Account(1);
            not_author.name = "not_author";
            not_author.password = "pw";

            bool result = action.modifyArticleContent(db, 0, not_author, "更新文章內容", "替換文章內圖片");
            Assert.That(false, Is.EqualTo(result));

            result = action.modifyArticleContent(db, 0, not_author, "更新第二次文章內容", "替換文章內圖片");
            Assert.That(false, Is.EqualTo(result));

            result = action.modifyArticleContent(db, 1, not_author, "更新文章內容22", "替換文章內圖片");
            Assert.That(false, Is.EqualTo(result));
        }

        [Test]
        public void 登入_Action()
        {
            ForumDB db = new ForumDB();
            Action action = new Action();
            bool isLogin = action.signin(db, "teamD", "test");
            Assert.That(true, Is.EqualTo(isLogin));
        }

        [Test]
        public void 登入失敗_Action()
        {
            ForumDB db = new ForumDB();
            Action action = new Action();
            bool isLogin = action.signin(db, "teamA", "1234");
            Assert.That(false, Is.EqualTo(isLogin));
        }

        [Test]
        public void 登出_Action()
        {
            ForumDB db = new ForumDB();
            Action action = new Action();
            bool isLogin = action.signin(db, "teamD", "test");
            Assert.That(true, Is.EqualTo(action.loggedin));
            action.signout(db);
            Assert.That(null, Is.EqualTo(action.user));
            Assert.That(false, Is.EqualTo(action.loggedin));
        }

        [Test]
        public void 新增文章_Action()
        {
            ForumDB db = new ForumDB();
            Action action = new Action();
            db.insertArticle("teamD", "測試標題", "測試摘要22", "測試內容","測試圖片");
            Assert.That("測試標題", Is.EqualTo(db.getTitle(0)));
            Assert.That("測試內容", Is.EqualTo(db.getArticle(0)));
            Assert.That("測試內容", Is.EqualTo(action.addArticle(db, db.accounts[0], "測試標題", "測試摘要", "測試內容")));
        }

        [Test]
        public void 新增评论_Action()
        {
            ForumDB db = new ForumDB();
            Action action = new Action();
            Article art = new Article();
            db.insertArticle("teamD", "測試標題", "測試摘要", "測試內容", "picture1");
            db.insertComment("測試內容","teamD",0);
            List<Comment> match = db.getComment(0);
            Assert.That("測試內容", Is.EqualTo(match[0].getContent()));
            Assert.That("測試內容", Is.EqualTo(action.addComment(db,db.accounts[0],art,"測試內容")));
        }

        [Test]
        public void 搜尋文章標題_Action()
        {
            ForumDB db = new ForumDB();
            db.insertArticle("teamD", "文章標題aa", "測試摘要", "文章內容","picture1");
            db.insertArticle("teamD", "文章標題aa2", "測試摘要", "文章內容", "picture1");
            db.insertArticle("teamD", "文章標題bb", "測試摘要", "文章內容", "picture1");
            db.insertArticle("teamD", "文章標題bb22", "測試摘要", "文章內容", "picture1");
            db.insertArticle("teamD", "文章標題ccc", "測試摘要", "文章內容", "picture1");
            Action action = new Action();
            List<Article> tmp = action.searchArticleTitle(db, "aa");
            Assert.That("文章標題aa", Is.EqualTo(tmp[0].title));
            Assert.That("文章標題aa2", Is.EqualTo(tmp[1].title));

            tmp = action.searchArticleTitle(db, "c");
            Assert.That("文章標題ccc", Is.EqualTo(tmp[0].title));


            tmp = action.searchArticleTitle(db, "2");
            Assert.That("文章標題aa2", Is.EqualTo(tmp[0].title));
            Assert.That("文章標題bb22", Is.EqualTo(tmp[1].title));
        }

        [Test]
        public void 搜尋文章內容_Action()
        {
            ForumDB db = new ForumDB();
            db.insertArticle("teamD", "文章標題aa", "測試摘要", "文章內容aa", "picture1");
            db.insertArticle("teamD", "文章標題aa2", "測試摘要", "文章內容aa2", "picture1");
            db.insertArticle("teamD", "文章標題bb", "測試摘要", "文章內容bb", "picture1");
            db.insertArticle("teamD", "文章標題bb22", "測試摘要", "文章內容bb22", "picture1");
            db.insertArticle("teamD", "文章標題ccc", "測試摘要", "文章內容ccc", "picture1");

            Action action = new Action();
            List<Article> tmp = action.searchArticleContent(db, "aa");
            Assert.That("文章內容aa", Is.EqualTo(tmp[0].content));
            Assert.That("文章內容aa2", Is.EqualTo(tmp[1].content));

            tmp = action.searchArticleContent(db, "c");
            Assert.That("文章內容ccc", Is.EqualTo(tmp[0].content));


            tmp = action.searchArticleContent(db, "2");
            Assert.That("文章內容aa2", Is.EqualTo(tmp[0].content));
            Assert.That("文章內容bb22", Is.EqualTo(tmp[1].content));
        }

        [Test]
        public void 搜尋文章摘要_Action()
        {
            ForumDB db = new ForumDB();
            db.insertArticle("teamD", "文章標題aa", "測試摘要1a", "文章內容aa", "pictures");
            db.insertArticle("teamD", "文章標題aa2", "測試摘要1b", "文章內容aa2", "pictures");
            db.insertArticle("teamD", "文章標題bb", "測試摘要1c", "文章內容bb", "pictures");
            db.insertArticle("teamD", "文章標題bb22", "測試摘要2a", "文章內容bb22", "pictures");
            db.insertArticle("teamD", "文章標題ccc", "測試摘要2b", "文章內容ccc", "pictures");

            Action action = new Action();
            List<Article> tmp = action.searchArticleSummary(db, "1");
            Assert.That("測試摘要1a", Is.EqualTo(tmp[0].summary));
            Assert.That("測試摘要1b", Is.EqualTo(tmp[1].summary));
            Assert.That("測試摘要1c", Is.EqualTo(tmp[2].summary));

            tmp = action.searchArticleSummary(db, "2");
            Assert.That("測試摘要2a", Is.EqualTo(tmp[0].summary));
            Assert.That("測試摘要2b", Is.EqualTo(tmp[1].summary));


            tmp = action.searchArticleSummary(db, "a");
            Assert.That("測試摘要1a", Is.EqualTo(tmp[0].summary));
            Assert.That("測試摘要2a", Is.EqualTo(tmp[1].summary));
        }

        [Test]
        public void 搜尋文章All_Action()
        {
            ForumDB db = new ForumDB();
            db.insertArticle("teamD", "文章標題aa", "測試摘要1a", "文章內容aa","pictures");
            db.insertArticle("teamD", "文章標題aa2", "測試摘要1b", "文章內容aa3", "pictures");
            db.insertArticle("teamD", "文章標題bb", "測試摘要1c", "文章內容bb", "pictures");
            db.insertArticle("teamD", "文章標題bb22", "測試摘要2a", "文章內容bb33", "pictures");
            db.insertArticle("teamD", "文章標題ccc", "測試摘要2b", "文章內容ccc", "pictures");

            Action action = new Action();
            List<Article> tmp = action.searchArticleAll(db, "1");
            Assert.That("測試摘要1a", Is.EqualTo(tmp[0].summary));
            Assert.That("測試摘要1b", Is.EqualTo(tmp[1].summary));
            Assert.That("測試摘要1c", Is.EqualTo(tmp[2].summary));

            tmp = action.searchArticleAll(db, "2");
            Assert.That("文章標題aa2", Is.EqualTo(tmp[0].title));
            Assert.That("測試摘要2a" , Is.EqualTo(tmp[1].summary));
            Assert.That("測試摘要2b" , Is.EqualTo(tmp[2].summary));


            tmp = action.searchArticleAll(db, "a");
            Assert.That("測試摘要1a" , Is.EqualTo(tmp[0].summary));
            Assert.That("文章標題aa2", Is.EqualTo(tmp[1].title));
            Assert.That("測試摘要2a" , Is.EqualTo(tmp[2].summary));
        }

        [Test]
        public void 讀取文章測試()
        {
            ForumDB db = new ForumDB();
            db.insertArticle("teamD", "文章標題aa", "測試摘要", "文章內容aa", "picture1");
            db.insertArticle("teamD", "文章標題aa2", "測試摘要", "文章內容aa2", "picture1");
            Action action = new Action();
            action.getArticle(db,0);//第0篇文章讀取五次
            action.getArticle(db,0);
            action.getArticle(db,0);
            action.getArticle(db,0);
            action.getArticle(db,0);
            action.getArticle(db,1);//第一篇文章讀取三次
            action.getArticle(db,1);
            action.getArticle(db,1);
            Assert.That(5, Is.EqualTo(action.getReads(db,0)));
            Assert.That(3, Is.EqualTo(action.getReads(db, 1)));
            Assert.That(0, Is.EqualTo(action.getReads(db, 2)));//尚無第二篇文章，瀏覽次數0
        }
    }
}
