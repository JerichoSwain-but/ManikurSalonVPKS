using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ManikurLib1;

namespace TestPrograms
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void AddDataToZapisTableMethod()
        {
            DataBaseN database = new DataBaseN();

            bool expected = true;

            bool actual = database.AddDataToZapisTable(
                3,
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
        public void DeleteDataFromYslygaTableMethod()
        {
            DataBaseN database = new DataBaseN();

            bool expected = true;

            bool actual = database.DeleteDataFromYslygaTable(
              6
                );

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditNameInMasterTableMethod()
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
        public void GetUserZ_ID_Method()
        {
            DataBaseN database = new DataBaseN();
            int user_id = 1;

            var expected = ManikurSalon.ManikurSalonEntities.GetContext().Zapis.Where(p => p.ID_Zapis == user_id).FirstOrDefault();

            var actual = database.GetUserZ_ID(user_id);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetYslygaByID_Method()
        {
            DataBaseN database = new DataBaseN();
            int user_id = 3;

            var expected = ManikurSalon.ManikurSalonEntities.GetContext().Yslyga.Where(p => p.ID_Yslyga == user_id).FirstOrDefault();

            var actual = database.GetYslygaByID(user_id);

            Assert.AreEqual(expected, actual);
        }
    }
}
