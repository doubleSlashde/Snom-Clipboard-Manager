namespace PhoneCliM.UI {
   partial class SaveCancelForm{
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveCancelForm));
         this.buttonPanel = new System.Windows.Forms.Panel();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnSave = new System.Windows.Forms.Button();
         this.contentPanel = new System.Windows.Forms.Panel();
         this.buttonPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonPanel
         // 
         this.buttonPanel.BackColor = System.Drawing.SystemColors.ControlDark;
         this.buttonPanel.Controls.Add(this.btnCancel);
         this.buttonPanel.Controls.Add(this.btnSave);
         this.buttonPanel.Location = new System.Drawing.Point(0, 179);
         this.buttonPanel.Name = "buttonPanel";
         this.buttonPanel.Size = new System.Drawing.Size(263, 52);
         this.buttonPanel.TabIndex = 3;
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(162, 15);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "btnCancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(27, 14);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(75, 23);
         this.btnSave.TabIndex = 0;
         this.btnSave.Text = "btnSave";
         this.btnSave.UseVisualStyleBackColor = true;
         // 
         // contentPanel
         // 
         this.contentPanel.BackColor = System.Drawing.SystemColors.Control;
         this.contentPanel.Location = new System.Drawing.Point(0, -1);
         this.contentPanel.Name = "contentPanel";
         this.contentPanel.Size = new System.Drawing.Size(263, 174);
         this.contentPanel.TabIndex = 4;
         // 
         // SaveCancelForm
         // 
         this.AcceptButton = this.btnSave;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(261, 230);
         this.Controls.Add(this.contentPanel);
         this.Controls.Add(this.buttonPanel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SaveCancelForm";
         this.Text = "SaveCancelForm";
         this.buttonPanel.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion
      protected System.Windows.Forms.Panel buttonPanel;
      protected System.Windows.Forms.Button btnCancel;
      protected System.Windows.Forms.Button btnSave;
      protected System.Windows.Forms.Panel contentPanel;
   }
}