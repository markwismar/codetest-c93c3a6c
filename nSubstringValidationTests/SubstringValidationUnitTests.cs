using Microsoft.VisualStudio.TestTools.UnitTesting;
using nSubstringModel;
using nSubstringValidation;

namespace nSubstringValidationTests {
    [TestClass]
    public class SubstringValidationUnitTests {
        [TestMethod]
        public void TestValidateConvertInput() {
            SubstringModel substringModel = new SubstringModel();
            substringModel.Input = "12";
            substringModel.SubstringSum = 10;
            substringModel.StartingNumber = 0;

            SubstringValidation.ValidateConvertInput(substringModel);
            Assert.IsTrue(substringModel.StatusMessages.Contains("Hello from SubstringValidation"));
        }

        [TestMethod]
        public void TestValidateConvertInputGoodNumber() {
            SubstringModel substringModel = new SubstringModel();
            substringModel.Input = "12";
            substringModel.SubstringSum = 10;
            substringModel.StartingNumber = 0;

            bool result = SubstringValidation.ValidateConvertInput(substringModel);
            Assert.AreEqual(12, substringModel.ConvertedInput);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestValidateConvertInputText() {
            SubstringModel substringModel = new SubstringModel();
            substringModel.Input = "abc";
            substringModel.SubstringSum = 10;
            substringModel.StartingNumber = 0;

            bool result = SubstringValidation.ValidateConvertInput(substringModel);
            Assert.AreNotEqual(12, substringModel.ConvertedInput);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestValidateConvertInputPuncuation() {
            SubstringModel substringModel = new SubstringModel();
            substringModel.Input = "!@#$";
            substringModel.SubstringSum = 10;
            substringModel.StartingNumber = 0;

            bool result = SubstringValidation.ValidateConvertInput(substringModel);
            Assert.AreNotEqual(12, substringModel.ConvertedInput);
            Assert.AreEqual(false, result);
        }
    }
}
