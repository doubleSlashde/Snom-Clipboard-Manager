using System;
using System.Windows.Forms;
using PhoneCliM.Resources;

namespace PhoneCliM.UI {
   /// <summary>
   /// Base form for forms which can save things.
   /// Also privides a cancel putton to clote without saving.
   /// </summary>
   public partial class SaveCancelForm : Form {
      public SaveCancelForm() {
         StartPosition = FormStartPosition.CenterScreen;
         InitializeComponent();

         SetLabels();
      }

      #region Private Methods

      private void SetLabels() {
         btnSave.Text = UILabels.Save;
         btnCancel.Text = UILabels.Cancel;
      }

      private void BtnCancel_Click(object sender, EventArgs e) {
         Close();
      }

      #endregion

   }
}
