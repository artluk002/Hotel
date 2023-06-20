namespace Hotel
{
    partial class StatusForm
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.linkLabelStatus = new System.Windows.Forms.LinkLabel();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.buttonBuyStatus = new Hotel.RoundedButton();
            this.buttonUserProfile = new Hotel.RoundedButton();
            this.roundedButtonChangeDescription = new Hotel.RoundedButton();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(766, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(33, 31);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // linkLabelStatus
            // 
            this.linkLabelStatus.ActiveLinkColor = System.Drawing.Color.Snow;
            this.linkLabelStatus.AutoSize = true;
            this.linkLabelStatus.Font = new System.Drawing.Font("Palatino Linotype", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelStatus.LinkColor = System.Drawing.Color.BlanchedAlmond;
            this.linkLabelStatus.Location = new System.Drawing.Point(328, 12);
            this.linkLabelStatus.Name = "linkLabelStatus";
            this.linkLabelStatus.Size = new System.Drawing.Size(260, 87);
            this.linkLabelStatus.TabIndex = 8;
            this.linkLabelStatus.TabStop = true;
            this.linkLabelStatus.Text = "Default";
            // 
            // textBoxText
            // 
            this.textBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.textBoxText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxText.Location = new System.Drawing.Point(12, 129);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.ReadOnly = true;
            this.textBoxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxText.Size = new System.Drawing.Size(776, 396);
            this.textBoxText.TabIndex = 9;
            // 
            // buttonBuyStatus
            // 
            this.buttonBuyStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.buttonBuyStatus.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonBuyStatus.BorderWidth = 0F;
            this.buttonBuyStatus.FlatAppearance.BorderSize = 0;
            this.buttonBuyStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuyStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBuyStatus.Location = new System.Drawing.Point(308, 531);
            this.buttonBuyStatus.Name = "buttonBuyStatus";
            this.buttonBuyStatus.Size = new System.Drawing.Size(205, 69);
            this.buttonBuyStatus.TabIndex = 10;
            this.buttonBuyStatus.Text = "buy";
            this.buttonBuyStatus.UseVisualStyleBackColor = false;
            this.buttonBuyStatus.Click += new System.EventHandler(this.buttonBuyStatus_Click);
            // 
            // buttonUserProfile
            // 
            this.buttonUserProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonUserProfile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonUserProfile.BorderWidth = 0F;
            this.buttonUserProfile.FlatAppearance.BorderSize = 0;
            this.buttonUserProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUserProfile.Location = new System.Drawing.Point(12, 12);
            this.buttonUserProfile.Name = "buttonUserProfile";
            this.buttonUserProfile.Size = new System.Drawing.Size(100, 94);
            this.buttonUserProfile.TabIndex = 6;
            this.buttonUserProfile.Text = "UserProfile";
            this.buttonUserProfile.UseVisualStyleBackColor = false;
            this.buttonUserProfile.Click += new System.EventHandler(this.buttonUserProfile_Click);
            // 
            // roundedButtonChangeDescription
            // 
            this.roundedButtonChangeDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButtonChangeDescription.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.roundedButtonChangeDescription.BorderWidth = 0F;
            this.roundedButtonChangeDescription.FlatAppearance.BorderSize = 0;
            this.roundedButtonChangeDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonChangeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roundedButtonChangeDescription.Location = new System.Drawing.Point(632, 531);
            this.roundedButtonChangeDescription.Name = "roundedButtonChangeDescription";
            this.roundedButtonChangeDescription.Size = new System.Drawing.Size(156, 41);
            this.roundedButtonChangeDescription.TabIndex = 11;
            this.roundedButtonChangeDescription.Text = "Change";
            this.roundedButtonChangeDescription.UseVisualStyleBackColor = false;
            this.roundedButtonChangeDescription.Visible = false;
            this.roundedButtonChangeDescription.Click += new System.EventHandler(this.roundedButtonChangeDescription_Click);
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(800, 604);
            this.Controls.Add(this.roundedButtonChangeDescription);
            this.Controls.Add(this.buttonBuyStatus);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.linkLabelStatus);
            this.Controls.Add(this.buttonUserProfile);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatusForm";
            this.Text = "StatusForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StatusForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private RoundedButton buttonUserProfile;
        private System.Windows.Forms.LinkLabel linkLabelStatus;
        private System.Windows.Forms.TextBox textBoxText;
        private RoundedButton buttonBuyStatus;
        private RoundedButton roundedButtonChangeDescription;
    }
}