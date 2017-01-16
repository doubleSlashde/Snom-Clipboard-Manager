using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PhoneCliM.Objects;
using PhoneCliM.Resources;
using PhoneCliM.Utils.Constants;

namespace PhoneCliM.UI {

   /// <summary>
   /// Form to show a MessageBox with additional buttons.
   /// </summary>
   public partial class CallMessageBox : Form {
      public CallMessageBox() {
         StartPosition = FormStartPosition.CenterScreen;
         TopMost = true;
         System.Media.SystemSounds.Asterisk.Play();

         InitializeComponent();

         SetLabels();
      }

      #region EventHandlers

      private void btnCall_Click(object sender, EventArgs e) {
         SnomPhoneController.Instance.CallCurrentNumber();
         Close();
      }

      private void btnSearchBackwards_Click(object sender, EventArgs e) {
         Process.Start(string.Format(Constant.SEARCH_BACKWARDS_URL, NumberController.Instance.CurrentNumber));
      }

      private void btnCancel_Click(object sender, EventArgs e) {
         Close();
      }

      #endregion

      #region Private methods

      private void SetLabels() {
         this.Text = Constant.EMPTY;

         lblText.Text = string.Format(UILabels.CallText,NumberController.Instance.CurrentNumber);

         btnCall.Text = UILabels.Call;
         btnSearchBackwards.Text = UILabels.SearchBackwards;
         btnCancel.Text = UILabels.Cancel;
      }


      #endregion
   }
}
