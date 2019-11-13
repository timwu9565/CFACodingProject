using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading.Tasks;
using CFA.Service;
using Moq;
using System.Collections.Generic;

namespace CFA.API.Tests.Service
{
    [TestClass]
    public class CFAtest
    {
        private ICFAService _service;
        private string _Fakedata;
        [TestInitialize]
        public void Initialize()
        {
            _service = new CFAService();
            // this should be return a int 9     
            
        }

        [TestMethod]
        public void TestCase1()
        {
            _Fakedata = "{}";
            var result = _service.GetScore(_Fakedata);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void TestCase2()
        {
            _Fakedata = "{{{}}}";
            var result = _service.GetScore(_Fakedata);
            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void TestCase3()
        {
            _Fakedata = "{{},{}}";
            var result = _service.GetScore(_Fakedata);
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void TestCase4()
        {
            _Fakedata = "{{{},{},{{}}}}";
            var result = _service.GetScore(_Fakedata);
            Assert.AreEqual(16, result);
        }
        [TestMethod]
        public void TestCase5()
        {
            _Fakedata = "{<a>,<a>,<a>,<a>}";
            var result = _service.GetScore(_Fakedata);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void TestCase6()
        {
            _Fakedata = "{{<ab>},{<ab>},{<ab>},{<ab>}}";
            var result = _service.GetScore(_Fakedata);
            Assert.AreEqual(9, result);
        }
        [TestMethod]
        public void TestCase7()
        {
            _Fakedata = "{{<!!>},{<!!>},{<!!>},{<!!>}}";
            var result = _service.GetScore(_Fakedata);
            Assert.AreEqual(9, result);
        }
        [TestMethod]

        public void TestCase8()
        {
            _Fakedata = "{{<a!>},{<a!>},{<a!>},{<ab>}}";
            var result = _service.GetScore(_Fakedata);
            Assert.AreEqual(3, result);
        }


    }
}
