using System;
using System.Text.RegularExpressions;
using dsDotNetUtils.Constants.Messages;
using dsDotNetUtils.Utils.Message;
using PhoneCliM.Objects.Configuration;
using PhoneCliM.Resources;
using PhoneCliM.UI;

namespace PhoneCliM.Utils {

   /// <summary>
   /// Utils for the Credentials class and its content
   /// </summary>
   static class CredentialsUtils {

      #region Members

      private static readonly Regex IP_ADDRESS_EX = new Regex("([0-2]?\\d{1,2}\\.){3}[0-2]?\\d{1,2}");

      #endregion

      #region Properties

      #endregion

      #region Constructors/Destructors

      #endregion

      #region Eventhandlers

      #endregion

      #region Public Methods

      public static bool IsValidIpAddress(string ipAddress) {
         bool result = false;
         if (!string.IsNullOrEmpty(ipAddress)) {
            result = IP_ADDRESS_EX.Match(ipAddress).ToString() == ipAddress;
         }
         return result;
      }

      public static bool IsValidUser(string user) {
         return !string.IsNullOrEmpty(user);
      }

      public static bool IsValidPassword(string password) {
         return !string.IsNullOrEmpty(password);
      }

      public static bool IsValidOwnNumber(string ownnumber) {
         bool result = false;
         int n;
         if (int.TryParse(ownnumber,out n)){
            if (ownnumber.Length > 0 && ownnumber.Length < 4 && ownnumber != "0" && ownnumber != "00" && ownnumber != "000") {
               result = true;
            } else {
               result = false;
            }
         } else {
            result = false;
         }
         return result;
      }

      /// <summary>
      /// Checks if the tool is configuted and opens the settings dialog if not.
      /// </summary>
      /// <returns>if the tool is configured</returns>
      public static bool CheckConfiguration() {
         bool result = true;

         if (PhoneUriIsNullOrEmpty() && UserIsNullOrEmpty() && PasswordIsNullOrEmpty() && OwnNumberIsNullOrEmpty()) {
            MessageHelper.MessageBoxService.ShowOnTop(MessageType.Warning, MessageBoxMessages.NotConfigured);
            // Open the settings dialog to let the user enter a configuration.
            new SettingsForm().ShowDialog();

            // Check the Config again in case the user canceled the input.
            result = !(PhoneUriIsNullOrEmpty() && UserIsNullOrEmpty() && PasswordIsNullOrEmpty() && OwnNumberIsNullOrEmpty());
         }

         return result;
      }

      #endregion

      #region Internal Methods

      #endregion

      #region Protected Methods

      #endregion

      #region Private Methods

      private static bool PhoneUriIsNullOrEmpty() {
         bool result = true;

         if (Credentials.Instance.PhoneUri != null) {
            result = string.IsNullOrEmpty(Credentials.Instance.PhoneUri.AbsolutePath);
         }

         return result;
      }

      private static bool UserIsNullOrEmpty() {
         return string.IsNullOrEmpty(Credentials.Instance.User);
      }

      private static bool PasswordIsNullOrEmpty() {
         return string.IsNullOrEmpty(Credentials.Instance.Password);
      }

      private static bool OwnNumberIsNullOrEmpty() {
         return string.IsNullOrEmpty(Credentials.Instance.OwnNumber);
      }
      #endregion

   }
}
