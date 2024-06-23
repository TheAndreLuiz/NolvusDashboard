﻿namespace Vcc.Nolvus.Dashboard.Frames.Settings
{
    partial class GameFrame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameFrame));
            this.LblError = new System.Windows.Forms.Label();
            this.BtnDetect = new Vcc.Nolvus.Components.Controls.FlatButton();
            this.BtnBrowse = new Vcc.Nolvus.Components.Controls.FlatButton();
            this.TxtBxGamePath = new System.Windows.Forms.TextBox();
            this.LblCheck = new System.Windows.Forms.Label();
            this.BtnContinue = new Vcc.Nolvus.Components.Controls.FlatButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.PnlMessage = new System.Windows.Forms.Panel();
            this.LblMessage = new System.Windows.Forms.Label();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.PnlMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LblError
            // 
            this.LblError.AutoSize = true;
            this.LblError.ForeColor = System.Drawing.Color.White;
            this.LblError.Location = new System.Drawing.Point(19, 239);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(38, 13);
            this.LblError.TabIndex = 12;
            this.LblError.Text = "Error...";
            this.LblError.Visible = false;
            // 
            // BtnDetect
            // 
            this.BtnDetect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.BtnDetect.BorderColor = System.Drawing.Color.White;
            this.BtnDetect.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnDetect.ForeColor = System.Drawing.Color.White;
            this.BtnDetect.Location = new System.Drawing.Point(16, 90);
            this.BtnDetect.Name = "BtnDetect";
            this.BtnDetect.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.BtnDetect.Size = new System.Drawing.Size(115, 29);
            this.BtnDetect.TabIndex = 11;
            this.BtnDetect.Text = "Auto Detect";
            this.BtnDetect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDetect.UseVisualStyleBackColor = false;
            this.BtnDetect.Click += new System.EventHandler(this.BtnDetect_Click);
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.BtnBrowse.BorderColor = System.Drawing.Color.White;
            this.BtnBrowse.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnBrowse.ForeColor = System.Drawing.Color.White;
            this.BtnBrowse.Location = new System.Drawing.Point(486, 47);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.BtnBrowse.Size = new System.Drawing.Size(20, 20);
            this.BtnBrowse.TabIndex = 10;
            this.BtnBrowse.Text = "...";
            this.BtnBrowse.UseVisualStyleBackColor = false;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // TxtBxGamePath
            // 
            this.TxtBxGamePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.TxtBxGamePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBxGamePath.ForeColor = System.Drawing.Color.White;
            this.TxtBxGamePath.Location = new System.Drawing.Point(16, 47);
            this.TxtBxGamePath.Name = "TxtBxGamePath";
            this.TxtBxGamePath.Size = new System.Drawing.Size(464, 20);
            this.TxtBxGamePath.TabIndex = 9;
            // 
            // LblCheck
            // 
            this.LblCheck.AutoSize = true;
            this.LblCheck.ForeColor = System.Drawing.Color.White;
            this.LblCheck.Location = new System.Drawing.Point(13, 15);
            this.LblCheck.Name = "LblCheck";
            this.LblCheck.Size = new System.Drawing.Size(262, 13);
            this.LblCheck.TabIndex = 8;
            this.LblCheck.Text = "Select your Skyrim Special Edition installation directory";
            // 
            // BtnContinue
            // 
            this.BtnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.BtnContinue.BorderColor = System.Drawing.Color.White;
            this.BtnContinue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnContinue.ForeColor = System.Drawing.Color.White;
            this.BtnContinue.Location = new System.Drawing.Point(817, 428);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.BtnContinue.Size = new System.Drawing.Size(94, 42);
            this.BtnContinue.TabIndex = 7;
            this.BtnContinue.Text = "Next";
            this.BtnContinue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnContinue.UseVisualStyleBackColor = false;
            this.BtnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // PnlMessage
            // 
            this.PnlMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlMessage.BackColor = System.Drawing.Color.Orange;
            this.PnlMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlMessage.Controls.Add(this.LblMessage);
            this.PnlMessage.Controls.Add(this.PicBox);
            this.PnlMessage.Location = new System.Drawing.Point(16, 139);
            this.PnlMessage.Name = "PnlMessage";
            this.PnlMessage.Size = new System.Drawing.Size(895, 75);
            this.PnlMessage.TabIndex = 21;
            // 
            // LblMessage
            // 
            this.LblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMessage.ForeColor = System.Drawing.Color.White;
            this.LblMessage.Location = new System.Drawing.Point(44, 7);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(842, 53);
            this.LblMessage.TabIndex = 1;
            this.LblMessage.Text = resources.GetString("LblMessage.Text");
            this.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PicBox
            // 
            this.PicBox.Image = global::Vcc.Nolvus.Dashboard.Properties.Resources.Warning_Message;
            this.PicBox.Location = new System.Drawing.Point(6, 16);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(32, 32);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBox.TabIndex = 0;
            this.PicBox.TabStop = false;
            // 
            // GameFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Controls.Add(this.PnlMessage);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.BtnDetect);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.TxtBxGamePath);
            this.Controls.Add(this.LblCheck);
            this.Controls.Add(this.BtnContinue);
            this.Name = "GameFrame";
            this.Size = new System.Drawing.Size(925, 484);
            this.PnlMessage.ResumeLayout(false);
            this.PnlMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblError;
        private Components.Controls.FlatButton BtnDetect;
        private Components.Controls.FlatButton BtnBrowse;
        private System.Windows.Forms.TextBox TxtBxGamePath;
        private System.Windows.Forms.Label LblCheck;
        private Components.Controls.FlatButton BtnContinue;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel PnlMessage;
        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.PictureBox PicBox;
    }
}
