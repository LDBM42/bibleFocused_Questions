﻿namespace capaPresentacion
{
    partial class P_players
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_players));
            this.button1 = new System.Windows.Forms.Button();
            this.lab_Player1 = new System.Windows.Forms.Label();
            this.tbx_Player1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_Player2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(161)))), ((int)(((byte)(24)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(460, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lab_Player1
            // 
            this.lab_Player1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lab_Player1.AutoSize = true;
            this.lab_Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lab_Player1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(135)))));
            this.lab_Player1.Location = new System.Drawing.Point(106, 298);
            this.lab_Player1.Name = "lab_Player1";
            this.lab_Player1.Size = new System.Drawing.Size(139, 29);
            this.lab_Player1.TabIndex = 1;
            this.lab_Player1.Text = "Player One";
            // 
            // tbx_Player1
            // 
            this.tbx_Player1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbx_Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tbx_Player1.Location = new System.Drawing.Point(252, 295);
            this.tbx_Player1.Name = "tbx_Player1";
            this.tbx_Player1.Size = new System.Drawing.Size(187, 36);
            this.tbx_Player1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(161)))), ((int)(((byte)(24)))));
            this.label1.Location = new System.Drawing.Point(195, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select a NickName";
            // 
            // tbx_Player2
            // 
            this.tbx_Player2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbx_Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tbx_Player2.Location = new System.Drawing.Point(252, 337);
            this.tbx_Player2.Name = "tbx_Player2";
            this.tbx_Player2.Size = new System.Drawing.Size(187, 36);
            this.tbx_Player2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(135)))));
            this.label2.Location = new System.Drawing.Point(106, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Player Two";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(213, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // P_players
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(723, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbx_Player2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_Player1);
            this.Controls.Add(this.lab_Player1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P_players";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Players";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lab_Player1;
        private System.Windows.Forms.TextBox tbx_Player1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_Player2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}