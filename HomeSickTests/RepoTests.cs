using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeSick.Repository;
using HomeSick.Model;
using System.Collections.Generic;


namespace HomeSickTests
{
    [TestClass]
    public class RepoTests
    {
            private static RemedyRepository repo;

            [ClassInitialize]
            public static void SetUp(TestContext _context)
            {
                repo = new RemedyRepository();
                repo.Clear();
            }

            [ClassCleanup]
            public static void CleanUp()
            {
                repo.Clear();
                repo.Dispose();
            }

            [TestMethod]
            public void DatabaseAddItem()
            {
                Assert.AreEqual(0, repo.GetCount());
                repo.Add(new RemedyItem("Hot Cocoa", "Mix 1 tsp of 100 percent cocoa powder and 1 tsp of honey in hot water", "Sore Throat"));
                Assert.AreEqual(1, repo.GetCount());
            }

            [TestMethod]
            public void DatabaseGetCount()
            {
                repo.Clear();
                repo.Add(new RemedyItem("Hot Cocoa", "Mix 1 tsp of 100 percent cocoa powder and 1 tsp of honey in hot water", "Sore Throat"));
                repo.Add(new RemedyItem("Emergen-C", "Mix one Emergen-C packet in long glass of hot water. Drink with straw", "Sore Throat"));
                Assert.AreEqual(2, repo.GetCount());
            }

            [TestMethod]
            public void DatabaseClearAll()
            {
                repo.Add(new RemedyItem("Hot Cocoa", "Mix 1 tsp of 100 percent cocoa powder and 1 tsp of honey in hot water", "Sore Throat"));
                repo.Add(new RemedyItem("Emergen-C", "Mix one Emergen-C packet in long glass of hot water. Drink with straw", "Sore Throat"));
                repo.Clear();
                Assert.AreEqual(0, repo.GetCount());
            }

            [TestMethod]
            public void DatabaseGetRemedyByTreatmentFor()
            {
                repo.Clear();
                repo.Add(new RemedyItem("Hot Cocoa", "Mix 1 tsp of 100 percent cocoa powder and 1 tsp of honey in hot water", "Sore Throat"));
                repo.Add(new RemedyItem("Claratin", "One capsule per 24 hour period", "Allergies"));
                var expectedList = new List<RemedyItem>();
                expectedList.Add(new RemedyItem("Claratin", "One capsule per 24 hour period", "Allergies"));
                Assert.AreEqual(expectedList, repo.GetByTreatmentFor("Allergies"));
            }

            [TestMethod]
            public void DatabaseDeleteItem()
            {
                repo.Clear();
                Assert.AreEqual(0, repo.GetCount());
                RemedyItem cocoa = new RemedyItem("Hot Cocoa", "Mix 1 tsp of 100 percent cocoa powder and 1 tsp of honey in hot water", "Sore Throat");
                repo.Add(cocoa);
                repo.Delete(cocoa);
                Assert.AreEqual(0, repo.GetCount());
            

        }
    }
}
