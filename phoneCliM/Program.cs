using System;
using System.Windows.Forms;
using PhoneCliM.Objects;
using PhoneCliM.Objects.ClipboardMonitoring;
using PhoneCliM.Objects.Configuration;
using PhoneCliM.UI;
using PhoneCliM.Utils;

namespace phoneCliM {
   class Program {

      static void Main(string[] args) {

         //These codelines are needed to use the NotifyIcon without a Form.
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         CredentialsUtils.CheckConfiguration();

         //Initialize NumberController
         NumberController.Initialize();

         //Start ClipboardMonitor
         ClipboardMonitor.Start();

         //Start TrayIcon
         Application.Run(new TrayIconContext());

      }

      #region Eventhandlers

      #endregion

      #region public methods

      public static void ShutDown() {
         ClipboardMonitor.Stop();
         Application.Exit();
      }

      #endregion

   }
}
