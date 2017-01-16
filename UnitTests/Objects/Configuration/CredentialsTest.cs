using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneCliM.Objects.Configuration;

namespace UnitTests.Objects.Configuration {
   [TestClass]
   public class CredentialsTest {

      #region Members

      private bool CredentialsChanged = false;

      #endregion

      #region Public Methods

      [TestMethod]
      public void TestOnCredentialsChanged() {
         Credentials.Instance.CredentialsChanged += Instance_CredentialsChanged;

         // Change credentials to call the event method
         Credentials.Instance.User = "Test";

         Assert.IsTrue(CredentialsChanged);
      }

      #endregion

      #region Private Methods

      private void Instance_CredentialsChanged(object sender, System.EventArgs e) {
         CredentialsChanged = true;
      }

      #endregion

   }
}
