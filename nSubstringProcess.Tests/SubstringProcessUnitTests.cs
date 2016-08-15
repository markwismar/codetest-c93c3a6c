using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nSubstringModel;

namespace nSubstringProcess.Tests {
    [TestClass]
    public class SubstringProcessUnitTests {
        [TestMethod]
        public void TestProcessNumber() {
            SubstringModel substringModel = new SubstringModel();
            SubstringProcessing.ProcessNumber(substringModel);
            Assert.IsTrue(substringModel.StatusMessages.Contains("Hello from SubstringProcessing"));
        }
    }
}
