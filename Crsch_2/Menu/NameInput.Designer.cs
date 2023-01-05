
namespace Crsch_2 {
    partial class NameInput {
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
            this.OK_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameInputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OK_btn
            // 
            this.OK_btn.Location = new System.Drawing.Point(109, 30);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(75, 23);
            this.OK_btn.TabIndex = 0;
            this.OK_btn.Text = "Ок";
            this.OK_btn.UseVisualStyleBackColor = true;
            this.OK_btn.Click += new System.EventHandler(this.OK_btnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите имя игрока:";
            // 
            // NameInputBox
            // 
            this.NameInputBox.Location = new System.Drawing.Point(3, 30);
            this.NameInputBox.Name = "NameInputBox";
            this.NameInputBox.Size = new System.Drawing.Size(100, 20);
            this.NameInputBox.TabIndex = 2;
            // 
            // NameInput
            // 
            this.AcceptButton = this.OK_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(224, 62);
            this.Controls.Add(this.NameInputBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "NameInput";
            this.Text = "Введите имя";
            this.Load += new System.EventHandler(this.NameInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameInputBox;
    }
}