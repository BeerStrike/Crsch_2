
namespace Crsch_2 {
    partial class GameForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.Placed = new System.Windows.Forms.Button();
            this.GameStateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Placed
            // 
            this.Placed.Location = new System.Drawing.Point(537, 482);
            this.Placed.Name = "Placed";
            this.Placed.Size = new System.Drawing.Size(140, 23);
            this.Placed.TabIndex = 0;
            this.Placed.Text = "Корабли расставлены";
            this.Placed.UseVisualStyleBackColor = true;
            this.Placed.Click += new System.EventHandler(this.Placed_Click);
            // 
            // GameStateLabel
            // 
            this.GameStateLabel.AutoSize = true;
            this.GameStateLabel.Location = new System.Drawing.Point(517, 47);
            this.GameStateLabel.Name = "GameStateLabel";
            this.GameStateLabel.Size = new System.Drawing.Size(111, 13);
            this.GameStateLabel.TabIndex = 1;
            this.GameStateLabel.Text = "Расставьте корабли";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1410, 718);
            this.Controls.Add(this.GameStateLabel);
            this.Controls.Add(this.Placed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Placed;
        private System.Windows.Forms.Label GameStateLabel;
    }
}