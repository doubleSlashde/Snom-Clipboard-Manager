using System;
using dsDotNetUtils.Utils.General;
using NLog;
using PhoneCliM.Properties;
using PhoneCliM.Resources;
using System.Windows.Forms;

namespace PhoneCliM.Objects.Configuration {

   /// <summary>
   /// This class holds the credentials
   /// </summary>
   public class Credentials {

      #region Members

      private static readonly Logger ClassLogger = LogManager.GetCurrentClassLogger();

      private static Credentials _instance;
      public event EventHandler<EventArgs> CredentialsChanged;

      #endregion

      #region Properties

      public static Credentials Instance => _instance ?? (_instance = new Credentials());

      public string User
      {
         get
         {
            return Settings.Default.Username;
         }
         set
         {
            Settings.Default.Username = value;
            ClassLogger.Info(LogMessages.CredentialsUser, Settings.Default.Username);

            OnCredentialsChanged(new EventArgs());
         }
      }

      public string Password
      {
         get
         {
            return Settings.Default.Password.Deobfuscate();
         }
         set
         {
            Settings.Default.Password = value.Obfuscate();
            ClassLogger.Info(LogMessages.CredentialsPassword); // Do not log the password, because it's secret!

            OnCredentialsChanged(new EventArgs());
         }
      }
      public Uri PhoneUri
      {
         get
         {
            try {
               return new Uri(Settings.Default.PhoneUrl);
            } catch (Exception) {
               return null;
            }
         }
         set
         {
            Settings.Default.PhoneUrl = value?.AbsoluteUri;
            ClassLogger.Info(LogMessages.CredentialsPhoneUrl, Settings.Default.PhoneUrl);

            OnCredentialsChanged(new EventArgs());
         }
      }

      public string OwnNumber
      {
         get
         {
               return Settings.Default.OwnNumber;
         }
         set
         {
            Settings.Default.OwnNumber = value;
            ClassLogger.Info(LogMessages.CredentialsOwnNumber, Settings.Default.OwnNumber);

            OnCredentialsChanged(new EventArgs());
         }
      }

      public CheckState AutoStart
      {
         get
         {
            return Settings.Default.AutoStart;
         }
         set
         {
            Settings.Default.AutoStart = value;

            OnCredentialsChanged(new EventArgs());
         }
      }
      #endregion

      #region Constructor

      private Credentials() {
         CredentialsChanged += Credentials_CredentialsChanged;
      }

      

      #endregion

      #region Eventhandlers

      private void Credentials_CredentialsChanged(object sender, EventArgs e) {
         Settings.Default.Save();
      }

      #endregion

      #region Public Methods

      #endregion

      #region Internal Methods

      #endregion

      #region Protected Methods

      #endregion

      #region Private Methods

      private void OnCredentialsChanged(EventArgs e) {
         CredentialsChanged?.Invoke(this, e);
      }

      #endregion

   }
}