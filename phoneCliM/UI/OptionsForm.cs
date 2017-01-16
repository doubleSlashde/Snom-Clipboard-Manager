using System;
using PhoneCliM.Objects.Configuration;
using PhoneCliM.Resources;

namespace PhoneCliM.UI {

   /// <summary>
   /// Form to change the options
   /// </summary>
   public partial class OptionsForm : SaveCancelForm {
      public OptionsForm() {
         InitializeComponent();

         SetLabels();
      }

      #region EventHandlers

      private void BtnSave_Click(object sender, EventArgs e) {
         if (SaveConfig()) {
            Close();
         }
      }

      #endregion

      #region Private Methods

      private bool SaveConfig() {
         bool result = true;

         Config.Instance.ShowBaloonTip = cbShowBaloonTip.Checked;

         return result;
      }

      private void SetLabels() {
         this.Text = UILabels.Options;
         cbShowBaloonTip.Text = UILabels.ShowBaloonTip;
         cbShowBaloonTip.Checked = Config.Instance.ShowBaloonTip;
      }

      #endregion
   }
}
