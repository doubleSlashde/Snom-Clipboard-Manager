using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneCliM.Objects.Configuration;

namespace UnitTests.Objects.Configuration {
   [TestClass]
   public class ConfigTest {

      #region Members

      private bool ConfigChanged = false;

      #endregion

      #region Public Methods

      [TestMethod]
      public void TestOnConfigChanged() {
         Config.Instance.ConfigChanged += Instance_ConfigChanged;

         // Change credentials to call the event method
         Config.Instance.FirstUse = true;

         Assert.IsTrue(ConfigChanged);
      }

      [TestMethod]
      public void TestDefaultRegion() {
         string validCountry = "CZ";
         string validCountry2 = "DE";
         string invalidCountry = "XX";

         Config.Instance.DefaultRegion = validCountry;

         Assert.AreEqual(Config.Instance.DefaultRegion, validCountry);

         Config.Instance.DefaultRegion = validCountry2;

         Assert.AreEqual(Config.Instance.DefaultRegion, validCountry2);

         Config.Instance.DefaultRegion = invalidCountry;

         Assert.AreNotEqual(Config.Instance.DefaultRegion, invalidCountry);
      }

      #endregion

      #region Private Methods

      private void Instance_ConfigChanged(object sender, System.EventArgs e) {
         ConfigChanged = true;
      }

      #endregion

   }
}
