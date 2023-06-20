namespace Hotel
{
    partial class buttonMakeReservation
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
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBoxWorker = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerDateOfDeparture = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDateOfDeparture = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerDateOfArrival = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDateOfArrival = new System.Windows.Forms.TextBox();
            this.textBoxDatesOfBooking = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonCancelReservation = new Hotel.RoundedButton();
            this.buttonMakeAReservatio = new Hotel.RoundedButton();
            this.buttonShowRoomInfo = new Hotel.RoundedButton();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(733, 1);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(34, 35);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxStatus.Location = new System.Drawing.Point(218, 70);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(489, 29);
            this.textBoxStatus.TabIndex = 4;
            // 
            // textBoxType
            // 
            this.textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.textBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxType.Location = new System.Drawing.Point(218, 105);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(489, 29);
            this.textBoxType.TabIndex = 5;
            // 
            // textBoxWorker
            // 
            this.textBoxWorker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.textBoxWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxWorker.Location = new System.Drawing.Point(218, 140);
            this.textBoxWorker.Name = "textBoxWorker";
            this.textBoxWorker.Size = new System.Drawing.Size(489, 29);
            this.textBoxWorker.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Worker:";
            // 
            // dateTimePickerDateOfDeparture
            // 
            this.dateTimePickerDateOfDeparture.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dateTimePickerDateOfDeparture.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dateTimePickerDateOfDeparture.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dateTimePickerDateOfDeparture.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dateTimePickerDateOfDeparture.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dateTimePickerDateOfDeparture.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateOfDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateOfDeparture.Location = new System.Drawing.Point(223, 320);
            this.dateTimePickerDateOfDeparture.Name = "dateTimePickerDateOfDeparture";
            this.dateTimePickerDateOfDeparture.Size = new System.Drawing.Size(200, 31);
            this.dateTimePickerDateOfDeparture.TabIndex = 13;
            this.dateTimePickerDateOfDeparture.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(227, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Date of departure";
            this.label5.Visible = false;
            // 
            // textBoxDateOfDeparture
            // 
            this.textBoxDateOfDeparture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDateOfDeparture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.textBoxDateOfDeparture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDateOfDeparture.Location = new System.Drawing.Point(218, 209);
            this.textBoxDateOfDeparture.Name = "textBoxDateOfDeparture";
            this.textBoxDateOfDeparture.Size = new System.Drawing.Size(489, 29);
            this.textBoxDateOfDeparture.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "Date of Departure:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "Date of arrival";
            this.label4.Visible = false;
            // 
            // dateTimePickerDateOfArrival
            // 
            this.dateTimePickerDateOfArrival.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dateTimePickerDateOfArrival.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dateTimePickerDateOfArrival.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dateTimePickerDateOfArrival.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dateTimePickerDateOfArrival.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dateTimePickerDateOfArrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateOfArrival.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateOfArrival.Location = new System.Drawing.Point(17, 320);
            this.dateTimePickerDateOfArrival.Name = "dateTimePickerDateOfArrival";
            this.dateTimePickerDateOfArrival.Size = new System.Drawing.Size(200, 31);
            this.dateTimePickerDateOfArrival.TabIndex = 20;
            this.dateTimePickerDateOfArrival.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "Date of Arrival:";
            // 
            // textBoxDateOfArrival
            // 
            this.textBoxDateOfArrival.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDateOfArrival.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.textBoxDateOfArrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDateOfArrival.Location = new System.Drawing.Point(218, 174);
            this.textBoxDateOfArrival.Name = "textBoxDateOfArrival";
            this.textBoxDateOfArrival.Size = new System.Drawing.Size(489, 29);
            this.textBoxDateOfArrival.TabIndex = 22;
            // 
            // textBoxDatesOfBooking
            // 
            this.textBoxDatesOfBooking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDatesOfBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.textBoxDatesOfBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDatesOfBooking.Location = new System.Drawing.Point(451, 285);
            this.textBoxDatesOfBooking.Multiline = true;
            this.textBoxDatesOfBooking.Name = "textBoxDatesOfBooking";
            this.textBoxDatesOfBooking.Size = new System.Drawing.Size(304, 248);
            this.textBoxDatesOfBooking.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(510, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "Dates of booking:";
            // 
            // buttonCancelReservation
            // 
            this.buttonCancelReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonCancelReservation.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonCancelReservation.BorderWidth = 0F;
            this.buttonCancelReservation.FlatAppearance.BorderSize = 0;
            this.buttonCancelReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancelReservation.Location = new System.Drawing.Point(26, 372);
            this.buttonCancelReservation.Name = "buttonCancelReservation";
            this.buttonCancelReservation.Size = new System.Drawing.Size(388, 63);
            this.buttonCancelReservation.TabIndex = 11;
            this.buttonCancelReservation.Text = "Cancel a reservation";
            this.buttonCancelReservation.UseVisualStyleBackColor = false;
            this.buttonCancelReservation.Visible = false;
            this.buttonCancelReservation.Click += new System.EventHandler(this.buttonCancelReservation_Click);
            // 
            // buttonMakeAReservatio
            // 
            this.buttonMakeAReservatio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonMakeAReservatio.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonMakeAReservatio.BorderWidth = 0F;
            this.buttonMakeAReservatio.FlatAppearance.BorderSize = 0;
            this.buttonMakeAReservatio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeAReservatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMakeAReservatio.Location = new System.Drawing.Point(26, 372);
            this.buttonMakeAReservatio.Name = "buttonMakeAReservatio";
            this.buttonMakeAReservatio.Size = new System.Drawing.Size(388, 63);
            this.buttonMakeAReservatio.TabIndex = 10;
            this.buttonMakeAReservatio.Text = "Make a reservation";
            this.buttonMakeAReservatio.UseVisualStyleBackColor = false;
            this.buttonMakeAReservatio.Click += new System.EventHandler(this.buttonMakeAReservatio_Click);
            // 
            // buttonShowRoomInfo
            // 
            this.buttonShowRoomInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonShowRoomInfo.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonShowRoomInfo.BorderWidth = 0F;
            this.buttonShowRoomInfo.FlatAppearance.BorderSize = 0;
            this.buttonShowRoomInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowRoomInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShowRoomInfo.Location = new System.Drawing.Point(26, 441);
            this.buttonShowRoomInfo.Name = "buttonShowRoomInfo";
            this.buttonShowRoomInfo.Size = new System.Drawing.Size(388, 63);
            this.buttonShowRoomInfo.TabIndex = 26;
            this.buttonShowRoomInfo.Text = "Show room Information";
            this.buttonShowRoomInfo.UseVisualStyleBackColor = false;
            this.buttonShowRoomInfo.Visible = false;
            this.buttonShowRoomInfo.Click += new System.EventHandler(this.buttonShowRoomInfo_Click);
            // 
            // buttonMakeReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(767, 545);
            this.Controls.Add(this.buttonShowRoomInfo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxDatesOfBooking);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxDateOfArrival);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerDateOfArrival);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxDateOfDeparture);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerDateOfDeparture);
            this.Controls.Add(this.buttonCancelReservation);
            this.Controls.Add(this.buttonMakeAReservatio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWorker);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "buttonMakeReservation";
            this.Text = "RoomInformation";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RoomInformation_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RoomInformation_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.TextBox textBoxWorker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RoundedButton buttonMakeAReservatio;
        private RoundedButton buttonCancelReservation;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateOfDeparture;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDateOfDeparture;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateOfArrival;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDateOfArrival;
        private System.Windows.Forms.TextBox textBoxDatesOfBooking;
        private System.Windows.Forms.Label label8;
        private RoundedButton buttonShowRoomInfo;
    }
}