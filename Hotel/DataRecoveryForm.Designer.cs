namespace Hotel
{
    partial class DataRecoveryForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUserMail = new System.Windows.Forms.TextBox();
            this.buttonSendMessage = new Hotel.RoundedButton();
            this.buttonAcceptCode = new Hotel.RoundedButton();
            this.textBoxRepitPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonChangePassword = new Hotel.RoundedButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(572, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(193, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter your e-mail:";
            // 
            // textBoxUserMail
            // 
            this.textBoxUserMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.textBoxUserMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUserMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUserMail.Location = new System.Drawing.Point(78, 139);
            this.textBoxUserMail.Name = "textBoxUserMail";
            this.textBoxUserMail.Size = new System.Drawing.Size(446, 29);
            this.textBoxUserMail.TabIndex = 3;
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonSendMessage.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonSendMessage.BorderWidth = 0F;
            this.buttonSendMessage.FlatAppearance.BorderSize = 0;
            this.buttonSendMessage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.buttonSendMessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.buttonSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSendMessage.Location = new System.Drawing.Point(180, 376);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(218, 67);
            this.buttonSendMessage.TabIndex = 4;
            this.buttonSendMessage.Text = "Send message";
            this.buttonSendMessage.UseVisualStyleBackColor = false;
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // buttonAcceptCode
            // 
            this.buttonAcceptCode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAcceptCode.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonAcceptCode.BorderWidth = 0F;
            this.buttonAcceptCode.Enabled = false;
            this.buttonAcceptCode.FlatAppearance.BorderSize = 0;
            this.buttonAcceptCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.buttonAcceptCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.buttonAcceptCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAcceptCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAcceptCode.Location = new System.Drawing.Point(180, 376);
            this.buttonAcceptCode.Name = "buttonAcceptCode";
            this.buttonAcceptCode.Size = new System.Drawing.Size(218, 67);
            this.buttonAcceptCode.TabIndex = 5;
            this.buttonAcceptCode.Text = "Enter";
            this.buttonAcceptCode.UseVisualStyleBackColor = false;
            this.buttonAcceptCode.Visible = false;
            this.buttonAcceptCode.Click += new System.EventHandler(this.buttonAcceptCode_Click);
            // 
            // textBoxRepitPassword
            // 
            this.textBoxRepitPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.textBoxRepitPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRepitPassword.Enabled = false;
            this.textBoxRepitPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRepitPassword.Location = new System.Drawing.Point(78, 204);
            this.textBoxRepitPassword.Name = "textBoxRepitPassword";
            this.textBoxRepitPassword.Size = new System.Drawing.Size(446, 29);
            this.textBoxRepitPassword.TabIndex = 6;
            this.textBoxRepitPassword.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(193, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Repit your password";
            this.label2.Visible = false;
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonChangePassword.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonChangePassword.BorderWidth = 0F;
            this.buttonChangePassword.Enabled = false;
            this.buttonChangePassword.FlatAppearance.BorderSize = 0;
            this.buttonChangePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.buttonChangePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.buttonChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangePassword.Location = new System.Drawing.Point(180, 376);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(218, 67);
            this.buttonChangePassword.TabIndex = 8;
            this.buttonChangePassword.Text = "Change";
            this.buttonChangePassword.UseVisualStyleBackColor = false;
            this.buttonChangePassword.Visible = false;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // DataRecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(604, 615);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRepitPassword);
            this.Controls.Add(this.buttonAcceptCode);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.textBoxUserMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DataRecoveryForm";
            this.Text = "DataRecoveryForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataRecoveryForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DataRecoveryForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUserMail;
        private RoundedButton buttonSendMessage;
        private RoundedButton buttonAcceptCode;
        private System.Windows.Forms.TextBox textBoxRepitPassword;
        private System.Windows.Forms.Label label2;
        private RoundedButton buttonChangePassword;
    }
}