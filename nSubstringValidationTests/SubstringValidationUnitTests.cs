using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nSubstringValidation;
using nSubstringModel;

namespace nSubstringValidationTests {
    [TestClass]
    public class SubstringValidationUnitTests {
        [TestMethod]
        public void TestValidateConvertInput() {
            SubstringModel substringModel = new SubstringModel();
            SubstringValidation.ValidateConvertInput(substringModel);
            Assert.IsTrue(substringModel.StatusMessages.Contains("Hello from SubstringValidation"));
        }
    }
}
