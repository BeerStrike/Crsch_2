
namespace Crsch_2 {
    partial class RecsForm {
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
            this.TableHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TableHeader
            // 
            this.TableHeader.AutoSize = true;
            this.TableHeader.Location = new System.Drawing.Point(12, 9);
            this.TableHeader.Name = "TableHeader";
            this.TableHeader.Size = new System.Drawing.Size(104, 13);
            this.TableHeader.TabIndex = 0;
            this.TableHeader.Text = "Таблица рекордов:";
            // 
            // RecsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 174);
            this.Controls.Add(this.TableHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RecsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рекорды";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TableHeader;
    }
}