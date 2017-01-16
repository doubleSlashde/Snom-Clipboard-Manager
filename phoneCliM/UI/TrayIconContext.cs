using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using dsDotNetUtils.Constants.Messages;
using dsDotNetUtils.Utils.Message;
using phoneCliM;
using PhoneCliM.Objects;
using PhoneCliM.Objects.Configuration;
using PhoneCliM.Resources;
using PhoneCliM.Utils;
using PhoneCliM.Utils.Constants;

namespace PhoneCliM.UI {

   /// <summary>
   /// Application Context to use a NotifyIcon without creating a Form
   /// </summary>
   public class TrayIconContext : ApplicationContext {

      #region Members

      private ContextMenuStrip _contextMenuStrip;

      private ToolStripMenuItem _callCurrentNumberMenuItem;
      private ToolStripMenuItem _optionsMenuItem;
      private ToolStripMenuItem _settingsMenuItem;
      private ToolStripMenuItem _closeMenuItem;

      private delegate void SetCallCurrentNumberMenuItemCallback();

      private const int BALLOON_TIP_TIME = 1000;
      #endregion

      #region Properties

      #endregion

      public NotifyIcon TrayIcon
      {
         get; set;
      }

      #region Constructors/Destructors

      public TrayIconContext() {

         Application.ApplicationExit += Application_ApplicationExit;
         NumberController.Instance.CurrentNumberChanged += NumberController_CurrentNumberChanged;

         InitializeComponent();
         TrayIcon.MouseUp += TrayIcon_MouseUp;
         TrayIcon.Visible = true;

         SetLabels();
         SetCallCurrentNumberMenuItem(); 

      }

      #endregion

      #region Eventhandlers

      private void Application_ApplicationExit(object sender, EventArgs e) {
         TrayIcon.Visible = false;
      }

      private void NumberController_CurrentNumberChanged(object sender, EventArgs e) {
         SetCallCurrentNumberMenuItem();

         ShowCurrentNumberChanged();

      }

      /// <summary>
      /// Triggering the same reaction of the Trayicon for a leftclick on it as when its rightclicked to open the menu correctly
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void TrayIcon_MouseUp(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Left) {
            System.Reflection.MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            mi.Invoke(TrayIcon, null);
         }
      }

      private void _callCurrentNumberMenuItem_Click(object sender, EventArgs e) {
         AskIfCallCurrentNumber();
      }

      private void _optionsMenuItem_Click(object sender, EventArgs e) {
         new OptionsForm().ShowDialog();
      }

      private void _settingsMenuItem_Click(object sender, EventArgs e) {
         new SettingsForm().ShowDialog();
      }

      private void _closeToolStripMenuItem_Click(object sender, EventArgs e) {
         Program.ShutDown();
      }

      private void TrayIcon_BalloonTipClicked(object sender, EventArgs e) {
         AskIfCallCurrentNumber();
      }

      #endregion

      #region Public Methods

      #endregion

      #region Internal Methods

      #endregion

      #region Protected Methods

      #endregion

      #region Private Methods

      private void InitializeComponent() {
         TrayIcon = new NotifyIcon();
         _contextMenuStrip = new ContextMenuStrip();

         _callCurrentNumberMenuItem = new ToolStripMenuItem();
         _optionsMenuItem = new ToolStripMenuItem();
         _settingsMenuItem = new ToolStripMenuItem();
         _closeMenuItem = new ToolStripMenuItem();

         // notifyIcon
         TrayIcon.Icon = GUIIcons.SnomCliM;
         TrayIcon.Text = UILabels.PhoneClipboardManager;
         TrayIcon.ContextMenuStrip = _contextMenuStrip;
         TrayIcon.BalloonTipClicked += TrayIcon_BalloonTipClicked;

         // contextMenuStrip 
         _contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _callCurrentNumberMenuItem,_optionsMenuItem ,_settingsMenuItem, _closeMenuItem});

         // callCurrentNumberMenuItem
         _callCurrentNumberMenuItem.Click += _callCurrentNumberMenuItem_Click;

         // optionsMenuItem
         _optionsMenuItem.Click += _optionsMenuItem_Click;

         // settingsMenuItem
         _settingsMenuItem.Click += _settingsMenuItem_Click;

         // closeMenuItem
         _closeMenuItem.Click += _closeToolStripMenuItem_Click;

      }

      private void SetLabels() {
         _optionsMenuItem.Text = UILabels.Options;
         _settingsMenuItem.Text = UILabels.Settings;
         _closeMenuItem.Text = UILabels.Close;
      }

      /// <summary>
      /// 
      /// Thread save call by invoking if necessary
      /// </summary>
      private void SetCallCurrentNumberMenuItem() {
         if (_contextMenuStrip.InvokeRequired) {
            SetCallCurrentNumberMenuItemCallback d = new SetCallCurrentNumberMenuItemCallback(SetCallCurrentNumberMenuItem);
            _contextMenuStrip.Invoke(d);
         } else {
            _callCurrentNumberMenuItem.Text = MessageHelper.CallCurrentNumberText;
            if (_callCurrentNumberMenuItem.Text == "") {
               _callCurrentNumberMenuItem.Available = false;
            } else {
               _callCurrentNumberMenuItem.Available = true;
               _contextMenuStrip.PerformLayout();
            }
         }
      }

      private void ShowCurrentNumberChanged() {
            TrayIcon.BalloonTipText = MessageHelper.NumberToClipboardMessage;
            if (Config.Instance.ShowBaloonTip) {
               TrayIcon.ShowBalloonTip(BALLOON_TIP_TIME);
            }  
      }

      private void AskIfCallCurrentNumber() {
         if (NumberController.Instance.CurrentNumber.Type == NumberStringType.INTERNAL) {
            if (CredentialsUtils.CheckConfiguration()) {
               DialogResult answer = MessageHelper.MessageBoxService.ShowOnTop(MessageType.InfoYesNo, MessageHelper.AskIfCallMessage);
               if (answer == DialogResult.Yes) {
                  SnomPhoneController.Instance.CallCurrentNumber();
               }
            }
         } else {
            new CallMessageBox().ShowDialog();
         }
      }

      #endregion

   }
}
