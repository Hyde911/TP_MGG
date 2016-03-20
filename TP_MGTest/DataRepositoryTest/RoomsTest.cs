using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_MG.DataGens;
using TP_MG.Repositories;

namespace TP_MGTest.DataRepositoryTest
{
    [TestClass]
    class RoomsTest
    {
        private DataRepository testData;

        [TestInitialize]
        public void testInit()
        {
            testData = new DataRepository(new SmallDataGenerator());
        }
    }
}
