using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneCliM.UI;

namespace UnitTests.UI {
   [TestClass]
   public class CallMessageBoxTest {
      [TestMethod]
      public void TestCallMessageBoxConstructor() {
         Assert.IsNotNull(new CallMessageBox());
      }
   }
}
