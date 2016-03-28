using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TP_MG.DataGens;
using TP_MG.Model;
using TP_MG.Repositories;

namespace TP_MGTest.DataRepositoryTests
{
    [TestClass]
    public class CustomerCollectionTests
    {
        private DataRepository testData;
        [TestInitialize]
        public void Initialize()
        {
            testData = new DataRepository(new SmallDataGenerator());
        }

        [TestMethod]
        public void addCustomerValidDataTest()
        {
            testData.addCustomer("Frank", "Zapp", category.vip);
            string expected = "name: Frank Zapp category: vip";
            string result = testData.getAllCustomers()[testData.getAllCustomers().Keys.Max()].ToString();
            Assert.AreEqual(expected, result, true);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void addCustomerNullFirstNameParameterTest()
        {
            testData.addCustomer(null, "Zappa", category.vip);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void addCustomerNullLastNameParameterTest()
        {
            testData.addCustomer("Frank", null, category.vip);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void addCustomerEmptyFirstNameParameterTest()
        {
            testData.addCustomer("", "Zappa", category.vip);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void addCustomerEmptyLastNameParameterTest()
        {
            testData.addCustomer("Frank", "", category.vip);
        }

        [TestMethod]
        public void addCustomerNumberOfElementsCheck()
        {
            testData.addCustomer("Eric", "Dolphy", category.vip);
            int expected = 8;
            int result = testData.getAllCustomers().Count();
            Assert.AreEqual(expected, result, 0.0);
        }

        [TestMethod]
        public void deleteCustomerNonExistentTest()
        {
            int expected = 7;
            testData.deleteCustomer(10);
            int result = testData.getAllCustomers().Count();
            Assert.AreEqual(expected, result, 0.0);
        }

        [TestMethod]
        public void deleteCustomerExistentTest()
        {
            int expected = 6;
            testData.deleteCustomer(2);
            int result = testData.getAllCustomers().Count();
            Assert.AreEqual(expected, result, 0.0);
        }

        [TestMethod]
        public void getCustomersByLastNameTest()
        {
            int expected = 2;
            Dictionary<int, Customer> tmplist;
            tmplist = testData.getCustomersByLastName("Nixon");
            int result = tmplist.Count();
            Assert.AreEqual(expected, result, 0.0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void getCustomersByLastNameNullParamaterTest()
        {
            testData.getCustomersByLastName(null);
        }

        [TestMethod]
        
        public void getCustomersByLastNameNonExistentTest()
        {
            int expected = 0;
            Dictionary<int,Customer> customers = testData.getCustomersByLastName("Zapp");
            int result = customers.Count();
            Assert.AreEqual(expected, result, 0.0);
        }
    

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void getCustomersByLastNameEmptyStringTest()
        {
            testData.getCustomersByLastName("");
        }

        [TestMethod]
        public void getCustomersByCategoryTest()
        {
            int expected = 2;
            Dictionary<int, Customer> tmplist;
            tmplist = testData.getCustomersByCategory(category.businesclass);
            int result = tmplist.Count();
            Assert.AreEqual(expected, result, 0.0);
        }

        [TestMethod]
        public void getCustomerByIdValidIdTest()
        {
            string expected = "Zappa";
            Customer customer = testData.getCustomerById(0);
            string result = customer.LastName;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void getCustomerByIdInvalidIdTest()
        {
            testData.getCustomerById(18);
        }

        [TestMethod]
        public void getCustomerByFirstAndLastNameValidDataTest()
        {
            string expected = "Bowie";
            Customer customer = testData.getCustomerByFirstAndLastName("David", "Bowie");
            string result = customer.LastName;
            Assert.AreEqual(expected, result);
        }
    }
}
