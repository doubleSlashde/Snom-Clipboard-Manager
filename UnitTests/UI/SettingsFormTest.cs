using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneCliM.UI;

namespace UnitTests.UI {
   [TestClass]
   public class SettingsFormTest {
      [TestMethod]
      public void TestSettingsFormConstructor() {
         Assert.IsNotNull(new SettingsForm());
      }
   }
}
