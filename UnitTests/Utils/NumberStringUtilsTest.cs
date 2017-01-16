using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneCliM.Utils;
using PhoneCliM.Utils.Constants;

namespace UnitTests.Utils {
   [TestClass]
   public class NumberStringUtilsTest {

      #region members

      string internalNumber = "123";
      string externalNumber = "07541700780";
      string noPossibleNumber = "-code/schnipsel XY+";
      string noPossibleNumber2 = "codeschnipselXY00";
      string noValidNumber = "01234567890";
      string externalWithSymbols = "(07541) 70078-0";
      string externalGerman = "+49 7541 / 70078-0";
      string externalAustria = "+43 7719 8811152";
      string externalAustria2 = "004377198811152";

      #endregion

      [TestMethod]
      public void TestIsValidPhoneNumber() {
         Assert.AreEqual(NumberStringUtils.IsValidPhoneNumber(internalNumber), NumberStringType.INTERNAL);
         Assert.AreEqual(NumberStringUtils.IsValidPhoneNumber(externalNumber),NumberStringType.EXTERNAL);
         Assert.AreEqual(NumberStringUtils.IsValidPhoneNumber(noPossibleNumber), NumberStringType.NOT_POSSIBLE);
         Assert.AreEqual(NumberStringUtils.IsValidPhoneNumber(noValidNumber), NumberStringType.NOT_VALID);
         Assert.AreEqual(NumberStringUtils.IsValidPhoneNumber(externalWithSymbols), NumberStringType.EXTERNAL);
         Assert.AreEqual(NumberStringUtils.IsValidPhoneNumber(externalGerman), NumberStringType.EXTERNAL);
         Assert.AreEqual(NumberStringUtils.IsValidPhoneNumber(externalAustria), NumberStringType.EXTERNAL);
         Assert.AreEqual(NumberStringUtils.IsValidPhoneNumber(externalAustria2), NumberStringType.EXTERNAL);
      }

      [TestMethod]
      public void FormatNumberString() {
         Assert.AreEqual(NumberStringUtils.FormatNumberString(internalNumber), internalNumber);
         Assert.AreEqual(NumberStringUtils.FormatNumberString(externalNumber), externalNumber);
         Assert.AreEqual(NumberStringUtils.FormatNumberString(noPossibleNumber), noPossibleNumber2);
         Assert.AreEqual(NumberStringUtils.FormatNumberString(noValidNumber), noValidNumber);
         Assert.AreEqual(NumberStringUtils.FormatNumberString(externalWithSymbols), externalNumber);
         Assert.AreEqual(NumberStringUtils.FormatNumberString(externalGerman), externalNumber);
         Assert.AreEqual(NumberStringUtils.FormatNumberString(externalAustria), externalAustria2);
         Assert.AreEqual(NumberStringUtils.FormatNumberString(externalAustria2), externalAustria2);
      }
   }
}
