using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ManikurLib;

namespace TestPrograms
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void AddDataToZapisTable()
        {
            DataBaseN database = new DataBaseN();

            bool expected = true;

            bool actual = database.AddDataToZapisTable(
                2,
                2,
                5,
                "20:00",
                1,
                "FirstName",
                "SecondName",
                "OtchestvoName"
                );

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteDataFromYslygaTable()
        {
            DataBaseN database = new DataBaseN();

            bool expected = true;

            bool actual = database.DeleteDataFromYslygaTable(
              6
                );

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditNameInMasterTable()
        {
            DataBaseN database = new DataBaseN();

            bool expected = true;

            bool actual = database.EditNameInMasterTable(
              2,
              "Андрей",
              "Иванов",
              "Петрович"
                );

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUserZ_ID()
        {
            DataBaseN database = new DataBaseN();
            int user_id = 1;

            var expected = ManikurSalon.ManikurSalonEntities.GetContext().Zapis.Where(p => p.ID_Zapis == user_id).FirstOrDefault();

            var actual = database.GetUserZ_ID(user_id);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetYslygaByID()
        {
            DataBaseN database = new DataBaseN();
            int user_id = 3;

            var expected = ManikurSalon.ManikurSalonEntities.GetContext().Yslyga.Where(p => p.ID_Yslyga == user_id).FirstOrDefault();

            var actual = database.GetUserZ_ID(user_id);

            Assert.AreEqual(expected, actual);
        }
    }
}
