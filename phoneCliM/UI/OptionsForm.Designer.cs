namespace PhoneCliM.UI {
   partial class OptionsForm {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.cbShowBaloonTip = new System.Windows.Forms.CheckBox();
         this.buttonPanel.SuspendLayout();
         this.contentPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonPanel
         // 
         this.buttonPanel.Location = new System.Drawing.Point(0, 70);
         this.buttonPanel.Size = new System.Drawing.Size(281, 52);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(175, 17);
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(27, 17);
         this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
         // 
         // contentPanel
         // 
         this.contentPanel.Controls.Add(this.cbShowBaloonTip);
         this.contentPanel.Size = new System.Drawing.Size(281, 77);
         // 
         // cbShowBaloonTip
         // 
         this.cbShowBaloonTip.AutoSize = true;
         this.cbShowBaloonTip.Location = new System.Drawing.Point(27, 28);
         this.cbShowBaloonTip.Name = "cbShowBaloonTip";
         this.cbShowBaloonTip.Size = new System.Drawing.Size(113, 17);
         this.cbShowBaloonTip.TabIndex = 0;
         this.cbShowBaloonTip.Text = "cbShowBaloonTip";
         this.cbShowBaloonTip.UseVisualStyleBackColor = true;
         // 
         // OptionsForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(281, 120);
         this.Name = "OptionsForm";
         this.Text = "OptionsForm";
         this.buttonPanel.ResumeLayout(false);
         this.contentPanel.ResumeLayout(false);
         this.contentPanel.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.CheckBox cbShowBaloonTip;
   }
}