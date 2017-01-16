using System.Windows.Forms;
using Microsoft.Win32;

namespace PhoneCliM.UI
{
   using System;

   using dsDotNetUtils.Constants.Messages;

   using PhoneCliM.Objects;
   using PhoneCliM.Objects.Configuration;
   using PhoneCliM.Resources;
   using PhoneCliM.Utils;
   using PhoneCliM.Utils.Constants;
   

   /// <summary>
   /// Form to change the settings
   /// </summary>
   public partial class SettingsForm : SaveCancelForm
   {
      public SettingsForm()
         : base()
      {
         this.InitializeComponent();

         this.SetLabels();
      }

      private void BtnSave_Click(object sender, EventArgs e)
      {
         if (this.SaveCredentials())
         {
            this.Close();
            MessageHelper.MessageBoxService.Show(MessageType.Info, MessageBoxMessages.SettingsSaved);
         }
      }

      private bool SaveCredentials()
      {
         string ipAddress = this.tbIpAddress.Text;
         Uri ipAddressUri = null;
         string user = this.tbUser.Text;
         string password = this.tbPassword.Text;
         string ownnumber = this.tbOwnNumber.Text;
         CheckState autostart = this.cbAutoStart.CheckState;

         bool ipAddressValid = CredentialsUtils.IsValidIpAddress(ipAddress);
         bool userValid = CredentialsUtils.IsValidUser(user);
         bool passwordValid = CredentialsUtils.IsValidPassword(password);
         bool ownnumberValid = CredentialsUtils.IsValidOwnNumber(ownnumber);

         ConnectionType connectionType = ConnectionType.NO_CONNECTION;
         bool connectionValid = false;

         bool credentialsValid = !(!userValid && passwordValid);

         if (ipAddressValid && credentialsValid && ownnumberValid)
         {
            ipAddressUri = new Uri(Constant.HTTP + ipAddress);
            connectionType = SnomPhoneController.Instance.CheckConnection(ipAddressUri, user, password);
            connectionValid = connectionType == ConnectionType.VALID;
         }

         if (connectionValid)
         {
            Credentials.Instance.PhoneUri = ipAddressUri;
            Credentials.Instance.User = user;
            Credentials.Instance.Password = password;
            Credentials.Instance.OwnNumber = ownnumber;
            SetStartup();
         }
         else
         {
            MessageHelper.MessageBoxService.Show(
               MessageType.Warning,
               MessageHelper.WrongSettingsMessage(ipAddressValid, userValid, passwordValid, ownnumberValid, connectionType));
         }

         return connectionValid;
      }

      private void SetLabels()
      {
         this.Text = UILabels.Settings;

         this.lblIP.Text = UILabels.IpAddress;
         this.lblUser.Text = UILabels.User;
         this.lblPassword.Text = UILabels.Password;
         this.lblOwnNumber.Text = UILabels.OwnNumber;
         this.lblLine.Text = UILabels.Line;
         this.cbAutoStart.Text = UILabels.AutoStart;

         if (Credentials.Instance.PhoneUri != null)
         {
            this.tbIpAddress.Text = Credentials.Instance.PhoneUri.Host;
         }
         else
         {
            this.tbIpAddress.Text = Constant.EMPTY;
         }

         this.tbUser.Text = Credentials.Instance.User;
         this.tbPassword.Text = Credentials.Instance.Password;
         this.tbOwnNumber.Text = Credentials.Instance.OwnNumber;
         this.cbAutoStart.CheckState = Credentials.Instance.AutoStart;
      }

      private void SetStartup() {
         RegistryKey rk = Registry.CurrentUser.OpenSubKey
             ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

         if (cbAutoStart.CheckState == CheckState.Checked) {
            Credentials.Instance.AutoStart = CheckState.Checked;
            rk.SetValue("SnomCliMSetup", Application.ExecutablePath.ToString());
         } else if(cbAutoStart.CheckState == CheckState.Unchecked) {
            Credentials.Instance.AutoStart = CheckState.Unchecked;
            rk.DeleteValue("SnomCliMSetup", false);
         }

      }

      private void label1_Click(object sender, EventArgs e) {

      }
   }
}