using System;
using lifbi.bookers.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lifbi.bookers.data.ef.tests
{
    [TestClass]
    public class EFContextTests
    {
        [TestMethod]
        public void EFContext_Can_Init_Context()
        {
            var inst = new EFContext();
        }

        [TestMethod]
        public void EFContext_Can_Create_DB()
        {
            //"using" da die DB ein IDisposible ist, nach dem Test wird daher der Context sauber geschlossen 
            using (var inst = new EFContext())
            {
                //Prüfe ob die DB schon vorhanden, ansonsten lösche sie erst einmal um die DB danach wieder zu erstellen 
                if (inst.Database.Exists())
                {
                    inst.Database.Delete();
                }

                Assert.IsFalse(inst.Database.Exists());

                inst.Database.Create();

                Assert.IsTrue(inst.Database.Exists());
            }
        }

        //CRUD Tests -> Create, Remove, Update, Delete

        [TestMethod]
        public void EFContext_Can_CRUD_Book()
        {
            var book = new Book() { Author = "me", Pages = 24, Price = 2.5m, Title = "Your first board game" };

            using (var inst = new EFContext())
            {
                var books = inst.Book;
                inst.Book.Add(book);
                inst.SaveChanges();
            }

            //Test insert ohne cache daher neuer using-Block
            string newTitle = "Ready Player One";
            using (var inst = new EFContext()) {
                var b = inst.Book.Find(book.ID);
                Assert.IsNotNull(b);
                Assert.AreEqual(b.Title, book.Title);

                //Update
                b.Title = newTitle;
                inst.SaveChanges();
            }

            //Check Update + Delete
            using (var inst = new EFContext())
            {
                var bUpdated = inst.Book.Find(book.ID);

                Assert.IsNotNull(bUpdated);
                Assert.AreEqual(bUpdated.Title, newTitle);

                inst.Book.Remove(bUpdated);
                inst.SaveChanges();
            }

            //Check Delete
            using (var inst = new EFContext())
            {
                var b = inst.Book.Find(book.ID);
                Assert.IsNull(b);
            }
        }


    }
}
