using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nSubstringModel;

namespace nSubstringProcess.Tests {
    [TestClass]
    public class SubstringProcessUnitTests {
        [TestMethod]
        public void TestProcessNumber() {
            SubstringModel substringModel = new SubstringModel();
            substringModel.ConvertedInput = 100;
            substringModel.Input = "100";
            substringModel.SubstringSum = 10;
            substringModel.StartingNumber = 0;


            SubstringProcessing.ProcessNumber(substringModel);
            Assert.IsTrue(substringModel.StatusMessages.Contains("Hello from SubstringProcessing"));
        }

        [TestMethod]
        public void TestProcessNumber100() {
            SubstringModel substringModel = new SubstringModel();
            substringModel.ConvertedInput = 100;
            substringModel.Input = "100";
            substringModel.SubstringSum = 10;
            substringModel.StartingNumber = 0;


            SubstringProcessing.ProcessNumber(substringModel);
            Assert.AreEqual(19, substringModel.Results[0]);
            Assert.AreEqual(28, substringModel.Results[1]);
            Assert.AreEqual(37, substringModel.Results[2]);
            Assert.AreEqual(46, substringModel.Results[3]);
            Assert.AreEqual(55, substringModel.Results[4]);
            Assert.AreEqual(64, substringModel.Results[5]);
            Assert.AreEqual(73, substringModel.Results[6]);
            Assert.AreEqual(82, substringModel.Results[7]);
            Assert.AreEqual(91, substringModel.Results[8]);
        }

        [TestMethod]
        public void TestProcessNumber3523014() {
            SubstringModel substringModel = new SubstringModel();
            substringModel.ConvertedInput = 3523014;
            substringModel.Input = "3523014";
            substringModel.SubstringSum = 10;
            substringModel.StartingNumber = 0;


            SubstringProcessing.ProcessNumber(substringModel);
            Assert.IsTrue(substringModel.StatusMessages.Contains("Hello from SubstringProcessing"));
        }
    }
}
