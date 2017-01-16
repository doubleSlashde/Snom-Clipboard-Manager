using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneCliM.UI;

namespace UnitTests.UI {
   [TestClass]
   public class OptionsFormTest {
      [TestMethod]
      public void TestOptionsFormConstructor() {
         Assert.IsNotNull(new OptionsForm());
      }
   }
}
