
namespace Crsch_2 {
    partial class MenuForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.SnglPlayByn = new System.Windows.Forms.Button();
            this.MltpPlayBtn = new System.Windows.Forms.Button();
            this.RecBtn = new System.Windows.Forms.Button();
            this.ExtiBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SnglPlayByn
            // 
            this.SnglPlayByn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SnglPlayByn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SnglPlayByn.Location = new System.Drawing.Point(390, 398);
            this.SnglPlayByn.Name = "SnglPlayByn";
            this.SnglPlayByn.Size = new System.Drawing.Size(100, 23);
            this.SnglPlayByn.TabIndex = 0;
            this.SnglPlayByn.Text = "Одиночная игра";
            this.SnglPlayByn.UseVisualStyleBackColor = true;
            this.SnglPlayByn.Click += new System.EventHandler(this.SnglPlayByn_Click);
            // 
            // MltpPlayBtn
            // 
            this.MltpPlayBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MltpPlayBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MltpPlayBtn.Location = new System.Drawing.Point(390, 427);
            this.MltpPlayBtn.Name = "MltpPlayBtn";
            this.MltpPlayBtn.Size = new System.Drawing.Size(100, 23);
            this.MltpPlayBtn.TabIndex = 1;
            this.MltpPlayBtn.Text = "Сетевая игра";
            this.MltpPlayBtn.UseVisualStyleBackColor = true;
            this.MltpPlayBtn.Click += new System.EventHandler(this.MltpPlayBtn_Click);
            // 
            // RecBtn
            // 
            this.RecBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RecBtn.Location = new System.Drawing.Point(390, 458);
            this.RecBtn.Name = "RecBtn";
            this.RecBtn.Size = new System.Drawing.Size(100, 23);
            this.RecBtn.TabIndex = 2;
            this.RecBtn.Text = "Рекорды";
            this.RecBtn.UseVisualStyleBackColor = true;
            this.RecBtn.Click += new System.EventHandler(this.RecBtn_Click);
            // 
            // ExtiBtn
            // 
            this.ExtiBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtiBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExtiBtn.Location = new System.Drawing.Point(390, 490);
            this.ExtiBtn.Name = "ExtiBtn";
            this.ExtiBtn.Size = new System.Drawing.Size(100, 23);
            this.ExtiBtn.TabIndex = 3;
            this.ExtiBtn.Text = "Выход";
            this.ExtiBtn.UseVisualStyleBackColor = true;
            this.ExtiBtn.Click += new System.EventHandler(this.ExtiBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Здравствуйте,";
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.Location = new System.Drawing.Point(12, 36);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(90, 13);
            this.PlayerNameLabel.TabIndex = 5;
            this.PlayerNameLabel.Text = "PlayerNameLabel";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(895, 586);
            this.Controls.Add(this.PlayerNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExtiBtn);
            this.Controls.Add(this.RecBtn);
            this.Controls.Add(this.MltpPlayBtn);
            this.Controls.Add(this.SnglPlayByn);
            this.Name = "MenuForm";
            this.Text = "Морской бой";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SnglPlayByn;
        private System.Windows.Forms.Button MltpPlayBtn;
        private System.Windows.Forms.Button RecBtn;
        private System.Windows.Forms.Button ExtiBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PlayerNameLabel;
    }
}

