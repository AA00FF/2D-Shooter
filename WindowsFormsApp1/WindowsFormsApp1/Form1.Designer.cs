namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_player = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.pictureBox_player);
<<<<<<< HEAD
            this.panel1.Location = new System.Drawing.Point(311, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 325);
=======
            this.panel1.Location = new System.Drawing.Point(260, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1540, 770);
>>>>>>> 8aa478b737d169ea128fc96e2a2db6ce90450701
            this.panel1.TabIndex = 0;
            // 
            // pictureBox_player
            // 
<<<<<<< HEAD
            this.pictureBox_player.ImageLocation = "Spaceship.png";
            this.pictureBox_player.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_player.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox_player.Name = "pictureBox_player";
            this.pictureBox_player.Size = new System.Drawing.Size(67, 65);
=======
            this.pictureBox_player.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_player.Image")));
            this.pictureBox_player.ImageLocation = "";
            this.pictureBox_player.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_player.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_player.Name = "pictureBox_player";
            this.pictureBox_player.Size = new System.Drawing.Size(100, 100);
            this.pictureBox_player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
>>>>>>> 8aa478b737d169ea128fc96e2a2db6ce90450701
            this.pictureBox_player.TabIndex = 0;
            this.pictureBox_player.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(987, 346);
=======
            this.ClientSize = new System.Drawing.Size(1808, 793);
>>>>>>> 8aa478b737d169ea128fc96e2a2db6ce90450701
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_player;
    }
}

