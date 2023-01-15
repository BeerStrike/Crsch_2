
namespace Crsch_2 {
    partial class ConnectForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.portInput = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.WaitForConnect = new System.Windows.Forms.Button();
            this.CancelConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ip-адрес:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Порт:";
            // 
            // ipInput
            // 
            this.ipInput.Location = new System.Drawing.Point(70, 9);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(100, 20);
            this.ipInput.TabIndex = 2;
            // 
            // portInput
            // 
            this.portInput.Location = new System.Drawing.Point(70, 36);
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(100, 20);
            this.portInput.TabIndex = 3;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(15, 62);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(149, 23);
            this.ConnectBtn.TabIndex = 4;
            this.ConnectBtn.Text = "Подключиться";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // WaitForConnect
            // 
            this.WaitForConnect.Location = new System.Drawing.Point(15, 92);
            this.WaitForConnect.Name = "WaitForConnect";
            this.WaitForConnect.Size = new System.Drawing.Size(149, 23);
            this.WaitForConnect.TabIndex = 5;
            this.WaitForConnect.Text = "Ожидать подключения";
            this.WaitForConnect.UseVisualStyleBackColor = true;
            this.WaitForConnect.Click += new System.EventHandler(this.WaitForConnect_Click);
            // 
            // CancelConnect
            // 
            this.CancelConnect.Location = new System.Drawing.Point(15, 80);
            this.CancelConnect.Name = "CancelConnect";
            this.CancelConnect.Size = new System.Drawing.Size(149, 23);
            this.CancelConnect.TabIndex = 6;
            this.CancelConnect.Text = "Отмена";
            this.CancelConnect.UseVisualStyleBackColor = true;
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 122);
            this.Controls.Add(this.CancelConnect);
            this.Controls.Add(this.WaitForConnect);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.portInput);
            this.Controls.Add(this.ipInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сетевая игра";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipInput;
        private System.Windows.Forms.TextBox portInput;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button WaitForConnect;
        private System.Windows.Forms.Button CancelConnect;
    }
}