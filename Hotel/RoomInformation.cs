using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Hotel
{
    public partial class buttonMakeReservation : Form
    {
        bool booking;
        DB db = DB.getInstance();
        DataRow[] room_info;
        DataRow[] booking_info;
        UInt32 userId;
        UserInfo user;
        public buttonMakeReservation(int number, bool booking, UInt32 userId) // конструктор с параметрами, для комнаты не зарегистрированной пользователем или администратора
        {
            try
            {
                InitializeComponent();
                this.booking = booking; 
                user = UserInfo.getInstance(userId);
                this.userId = userId;
                if (user.getUserStatus() == "admin")
                {
                    buttonShowRoomInfo.Visible = true;
                }
                if (booking)
                {
                    buttonMakeAReservatio.Visible = true;
                    dateTimePickerDateOfArrival.Visible = true;
                    dateTimePickerDateOfDeparture.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                }
                else
                {
                    buttonMakeAReservatio.Visible = false;
                    dateTimePickerDateOfArrival.Visible = false;
                    dateTimePickerDateOfDeparture.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                }

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `room` WHERE `number` = @rN", db.getConnection());
                command.Parameters.Add("@rN", MySqlDbType.Int32).Value = number;

                adapter.SelectCommand = command;
                adapter.Fill(table);
                room_info = table.Select();
                textBoxWorker.Text = Convert.ToString(room_info[0][4]);
                textBoxType.Text = Convert.ToString(room_info[0][2]);

                table = new DataTable();

                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `booking` WHERE `room_id` = @rI AND `valid` = @bV", db.getConnection());
                command1.Parameters.Add("@rI", MySqlDbType.UInt32).Value = (UInt32)room_info[0][0];
                command1.Parameters.Add("@bV", MySqlDbType.Int16).Value = 0;
                adapter.SelectCommand = command1;
                adapter.Fill(table);
                booking_info = table.Select();
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (!(Boolean)booking_info[i][5])
                        {
                            dateTimePickerDateOfArrival.Text = Convert.ToString(booking_info[i][3]);
                            dateTimePickerDateOfDeparture.Text = Convert.ToString(booking_info[i][4]);
                            textBoxDatesOfBooking.Text += "From: " + dateTimePickerDateOfArrival.Value.Date.ToShortDateString() + ", to: " + dateTimePickerDateOfDeparture.Value.Date.ToShortDateString() + Environment.NewLine;

                            DateTime DOA = new DateTime(dateTimePickerDateOfArrival.Value.Ticks);
                            DateTime DOD = new DateTime(dateTimePickerDateOfDeparture.Value.Ticks);
                            if (DateTime.Today >= DOA && DateTime.Today <= DOD)
                            {
                                textBoxDateOfArrival.Text = Convert.ToString(booking_info[i][3]);
                                textBoxDateOfDeparture.Text = Convert.ToString(booking_info[i][4]);
                                textBoxStatus.Text = "Room is booked";
                            }
                            else
                            {
                                textBoxStatus.Text = "Room is free";
                            }
                        }
                    } 
                }
                else
                {
                    textBoxStatus.Text = "Room is free";
                }
            }
            catch (Exception t)
            {
                MessageBox.Show(Convert.ToString(t), "Error");
            }
        }

        public buttonMakeReservation(int number, UInt32 userId) // конструктор с параметрами, для комнаты зарегистрированной пользователем
        {
            try
            {
                InitializeComponent();
                this.userId = userId;
                user = UserInfo.getInstance(userId);

                if (user.getUserStatus() == "admin")
                {
                    buttonShowRoomInfo.Visible = true;
                }
                buttonCancelReservation.Visible = true;
                dateTimePickerDateOfArrival.Visible = false;
                dateTimePickerDateOfDeparture.Visible = false;

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `room` WHERE `number` = @rN", db.getConnection());
                command.Parameters.Add("@rN", MySqlDbType.Int32).Value = number;

                adapter.SelectCommand = command;
                adapter.Fill(table);
                room_info = table.Select();
                textBoxWorker.Text = Convert.ToString(room_info[0][4]);
                textBoxType.Text = Convert.ToString(room_info[0][2]);
                textBoxStatus.Text = "This room is your";
                table = new DataTable();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `booking` WHERE `room_id` = @rI", db.getConnection());
                command1.Parameters.Add("@rI", MySqlDbType.UInt32).Value = (UInt32)room_info[0][0];
                adapter.SelectCommand = command1;
                adapter.Fill(table);
                booking_info = table.Select();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (!(Boolean)booking_info[i][5])
                    {
                        if (user.getUserID() == (UInt32)booking_info[i][1])
                        {
                            textBoxDateOfArrival.Text = (String)booking_info[i][3];
                            textBoxDateOfDeparture.Text = (String)booking_info[i][4];
                        }
                        dateTimePickerDateOfArrival.Text = Convert.ToString(booking_info[i][3]);
                        dateTimePickerDateOfDeparture.Text = Convert.ToString(booking_info[i][4]);
                        textBoxDatesOfBooking.Text += "From: " + dateTimePickerDateOfArrival.Value.Date.ToShortDateString() + ", to: " + dateTimePickerDateOfDeparture.Value.Date.ToShortDateString() + Environment.NewLine;

                    }
                }
            }
            catch (Exception t)
            {
                MessageBox.Show(Convert.ToString(t), "Error");
            }
        }
        Point lastPoint;
        private void RoomInformation_MouseMove(object sender, MouseEventArgs e) // обработчик перемещения курсора, который позволяет перемещать форму
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void RoomInformation_MouseDown(object sender, MouseEventArgs e) // обработчик нажатия левой кнопки мыши, который обновляет координаты поля lastPoint
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void buttonExit_Click(object sender, EventArgs e) // обработчик нажатия кнопки закрытия формы 
        {
            this.Close();
        }
        private void buttonMakeAReservatio_Click(object sender, EventArgs e) // обработчик нажатия кнопки бронирования комнаты, который отправляет запрос в базу данных, предварительно проевряя даты на корректность 
        {
            if (!CheckConnection())
                return;
            DateTime ArrivalDate = new DateTime(dateTimePickerDateOfArrival.Value.Ticks);
            DateTime DepartureDate = new DateTime(dateTimePickerDateOfDeparture.Value.Ticks);
            TimeSpan CountDaysReservation = DepartureDate.Subtract(ArrivalDate);
            //////
            if (dateTimePickerDateOfDeparture.Value <= DateTime.Now)
            {
                MessageBox.Show("Departure time cannot be set to the current day or befor\nChange your Date and try again", "Time error");
                return;
            }
            else if (CountDaysReservation.Days > 30)
            {
                MessageBox.Show("More than 30 days between your arrival and departure\nChange your Date and try again", "Time Error");
                return;
            } 
            else if (CountDaysReservation.Days < 0)
            {
                MessageBox.Show("Date of departure cannot be less that date of arrival", "Time Error");
                return;
            }
            for (int i = 0; i < booking_info.Length; i++)
            {
                DateTime BDOA = Convert.ToDateTime(booking_info[i][3]);
                DateTime BDOD = Convert.ToDateTime(booking_info[i][4]);
                if ((ArrivalDate >= BDOA && ArrivalDate <= BDOD) || (DepartureDate >= BDOA && DepartureDate <= BDOD))
                {
                    MessageBox.Show("The period of time you select falls within the period of the other person's booking.", "Error");
                    return;
                }
            }
            MySqlCommand command = new MySqlCommand("INSERT INTO `booking` (`user_id`, `room_id`, `date_of_arrival`, `date_of_departure`, `valid`) VALUES (@uI, @rI, @dA, @dD, @bV);", db.getConnection());
            command.Parameters.Add("@uI", MySqlDbType.Int32).Value = user.getUserID();
            command.Parameters.Add("@rI", MySqlDbType.UInt32).Value = Convert.ToUInt32(room_info[0][0]);
            command.Parameters.Add("@dA", MySqlDbType.VarChar).Value = dateTimePickerDateOfArrival.Text;
            command.Parameters.Add("@dD", MySqlDbType.VarChar).Value = dateTimePickerDateOfDeparture.Text;
            command.Parameters.Add("@bV", MySqlDbType.Int16).Value = 0;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("You book this room");
            db.closeConnection();
            user.Update();
            this.Close();
        }

        private void buttonCancelReservation_Click(object sender, EventArgs e) // обработчик нажатия кнопки отмены бронирования, которая позволяет отменить бронирование комнаты
        {
            if (!CheckConnection())
                return;
            MySqlCommand command = new MySqlCommand("UPDATE `booking` SET `valid` = @bV WHERE `user_id` = @uI AND `room_id` = @rI", db.getConnection());
            command.Parameters.Add("@uI", MySqlDbType.UInt32).Value = user.getUserID();
            command.Parameters.Add("@rI", MySqlDbType.UInt32).Value = (UInt32)room_info[0][0];
            command.Parameters.Add("@bV", MySqlDbType.Int16).Value = 1;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Room is free now");
            db.closeConnection();
            user.Update();
            this.Close();
        }
        private bool CheckConnection() // метод проверяющий соединение приложения с базой данных
        {
            try
            {
                db.openConnection();
                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("you do not have an Internet connection or the database is disabled\n\n" + Convert.ToString(exc), "Error");
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }
        public void update() // метод обновления информации об комнате
        {
            DataTable roomTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `booking` WHERE `room_id` = @rI", db.getConnection());
            command.Parameters.Add("@rI", MySqlDbType.UInt32).Value = (UInt32)room_info[0][0];
            adapter.SelectCommand = command;
            adapter.Fill(roomTable);
            DataRow[] rooms = roomTable.Select();
            if (roomTable.Rows.Count > 0)
            {
                for (int i = 0; i < roomTable.Rows.Count; i++)
                {
                    DateTimePicker dateOfArrival = new DateTimePicker();
                    DateTimePicker dateOfDeparture = new DateTimePicker();
                    dateOfArrival.Text = (String)rooms[i][3];
                    DateTime DOA = new DateTime(dateOfArrival.Value.Ticks);
                    dateOfDeparture.Text = (String)rooms[i][4];
                    DateTime DOD = new DateTime(dateOfDeparture.Value.Ticks);
                    TimeSpan dif = DOD.Subtract(DOA);
                }
            }
        }

        private void buttonShowRoomInfo_Click(object sender, EventArgs e) // обработчик нажатия кнопки показа информации об всех пользователях комнаты, доступно только для администратора
        {
            AdminRoomInfo adminWindow = new AdminRoomInfo((UInt32)room_info[0][0]);
            adminWindow.ShowDialog();
        }
    }
}
