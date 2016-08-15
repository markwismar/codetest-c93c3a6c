using Microsoft.VisualStudio.TestTools.UnitTesting;
using nSubstringModel;
using nSubstringService.Controllers;

namespace nSubstringService.Tests {
    [TestClass]
    public class SubstringServiceUnitTests {
        [TestMethod]
        public void TestSubstringServiceController() {
            SubstringModel substringModel = new SubstringModel();            
            SubstringServiceController controller = new SubstringServiceController();
            controller.Post(substringModel);
            Assert.IsTrue(substringModel.StatusMessages.Contains("Hello from SubstringServiceController"));
        }
    }
}
