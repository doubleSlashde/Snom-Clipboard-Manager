using System;
using NLog;
using PhoneCliM.Properties;
using PhoneCliM.Resources;
using PhoneNumbers;

namespace PhoneCliM.Objects.Configuration {

   /// <summary>
   /// This class holds the settings
   /// </summary>
   public class Config {

      #region Members

      private static readonly Logger ClassLogger = LogManager.GetCurrentClassLogger();

      private static Config _instance;
      public event EventHandler<EventArgs> ConfigChanged;

      #endregion

      #region Properties

      public static Config Instance => _instance ?? (_instance = new Config());

      public string DefaultRegion
      {
         get
         {
            return Settings.Default.DefaultRegion;
         }
         set
         {
            if (PhoneNumberUtil.GetInstance().GetSupportedRegions().Contains(value)) {
               Settings.Default.DefaultRegion = value;
               OnConfigChanged(new EventArgs());
            } else {
               ClassLogger.Error(LogMessages.ErrorImpossibleDefaultRegion, value);
            }
         }
      }

      /// <summary>
      ///    Does the user use the phoneClipboardManager the first time?
      /// </summary>
      public bool FirstUse
      {
         get
         {
            return Settings.Default.FirstUse;
         }
         set
         {
            Settings.Default.FirstUse = value;
            OnConfigChanged(new EventArgs());
         }
      }

      public bool ShowBaloonTip
      {
         get
         {
            return Settings.Default.ShowBalloonTip;
         }
         set
         {
            Settings.Default.ShowBalloonTip = value;
            OnConfigChanged(new EventArgs());
         }
      }

      #endregion

      #region Constructor

      private Config() {
         ConfigChanged += Config_ConfigChanged;
      }

      #endregion

      #region Eventhandlers

      private void Config_ConfigChanged(object sender, EventArgs e) {
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

      private void OnConfigChanged(EventArgs e) {
         ConfigChanged?.Invoke(this, e);
      }

      #endregion

   }
}