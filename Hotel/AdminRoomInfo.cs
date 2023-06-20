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
    
    public partial class AdminRoomInfo : Form
    {
        DB db = DB.getInstance();
        DataRow[] bookingInfo;
        
        DataTable table = new DataTable();
        public AdminRoomInfo(UInt32 roomId) // конструктор формы в которм инициализируется сама форма, берется информация из базы данных и переносится на форму
        {
            InitializeComponent();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `booking` WHERE `room_id` = @rI AND `valid` = @bV", db.getConnection());
            command.Parameters.Add("@rI", MySqlDbType.UInt32).Value = roomId;
            command.Parameters.Add("@bV", MySqlDbType.Int16).Value = 0;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            bookingInfo = table.Select();

            int countBooking = table.Rows.Count;
            if (countBooking > 0)
            {
                for (int i = 0; i < countBooking;i++)
                {
                    DataRow[] userInfo = SelectUser((UInt32)bookingInfo[i][1]);
                    if (userInfo != null)
                    {
                        textBoxBookingInfo.Text += $"{userInfo[0][1]}: From {bookingInfo[i][3]}, to {bookingInfo[i][4]}" + Environment.NewLine;
                        comboBoxUsers.Items.Add((String)userInfo[0][1]);
                    }
                }
            }
        }

        Point lastPoint;
        private void AdminRoomInfo_MouseMove(object sender, MouseEventArgs e) // обработчик движения курсора мыши, который позволяет перемещать форму
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void AdminRoomInfo_MouseDown(object sender, MouseEventArgs e) // обработчик нажатия левой кнопки мыши, который передаёт объкту lastPoint координаты текущего положения курсора
        {
            lastPoint = new Point(e.X, e.Y);
        }

        public DataRow[] SelectUser(UInt32 userId) // метод поиска пользователя из базы данных по его ID
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `user`.`id` = @uI", db.getConnection());
            command.Parameters.Add("@uI", MySqlDbType.UInt32).Value = userId;
            table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataRow[] userInfo;
            userInfo = table.Select();
            if (table.Rows.Count > 0)
            {
                return userInfo;
            }
            return null;
        }

        private void buttonExit_Click(object sender, EventArgs e) // обработчик нажатия на кнопку выхода
        {
            this.Close();
        }

        private void buttonShowRoomInfo_Click(object sender, EventArgs e) // обработчик нажати на кнопку показа информации о комнате
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = comboBoxUsers.SelectedItem;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            table = new DataTable();
            adapter.Fill(table);
            DataRow[] userinfo = table.Select();
            if (table.Rows.Count > 0)
            {
                textBoxLogin.Text = (String)userinfo[0][1];
                textBoxName.Text = (String)userinfo[0][2];
                textBoxAge.Text = Convert.ToString(Convert.ToInt16(userinfo[0][4]));
                textBoxMail.Text = (String)userinfo[0][5];
                textBoxPhone.Text = (String)userinfo[0][6];
                textBoxStatus.Text = (String)userinfo[0][7];
            }
        }
    }
}
