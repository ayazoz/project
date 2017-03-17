using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Helper.External.Models;

namespace Demo.Helper.Tests
{
    [TestClass()]
    public class XMLReaderTests
    {
        [TestMethod()]
        public void ReturnListOfProductsTest()
        {
            List<Words> list = new List<Words>();
            Assert.AreEqual(list.Count, 0, "Liste ilk yaratıldığında listenin eleman sayısı sıfır olmalıdır.");
        }
    }
}