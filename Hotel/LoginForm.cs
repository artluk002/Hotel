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
    public partial class LoginForm : Form
    {
        DB db = DB.getInstance();
        public LoginForm()
        {
            InitializeComponent();
            ReservationUpdate();
        }

        private void buttonExit_Click(object sender, EventArgs e) // обработчик нажатия кнопки выход
        {
            this.Close();
        }
        Point lastPoint;
        private void LoginForm_MouseMove(object sender, MouseEventArgs e) // обработчик перемещения курсора, который позволяет перемещать форму
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e) // обработчик нажатия левой кнопки мыши, который обновляет координаты поля lastPoint
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void linkLabelRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // обработчик нажатия на синий текст, который открывает форму регистрации
        {
            RegistrationForm reg = new RegistrationForm();
            reg.ShowDialog();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e) // обработчик нажатия на чек-бокс, позволяющий отобразить или скрыть пароль
        {
            if (checkBoxShowPassword.CheckState == CheckState.Checked)
                textBoxPassword.UseSystemPasswordChar = false;
            else
                textBoxPassword.UseSystemPasswordChar = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e) // обработчик нажатия кнопки входа, которая проверят данных для вохда в программу
        {
            try
            {
                String userLogin = textBoxLogin.Text;
                String userPassword = textBoxPassword.Text;

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @uL AND `password` = @uP", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userLogin;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userPassword.GetHashCode().ToString();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    DataRow[] foundrow = table.Select();
                    this.Hide();
                    MainForm mF = new MainForm(table);
                    mF.Show();
                }
                else
                    MessageBox.Show("User with such data does not exist!");
            }
            catch(Exception t)
            {
                MessageBox.Show(Convert.ToString(t), "Error");
            }
        }

        private void linkLabelForgotData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // обработчик нажатия на синий текст, который открывает форму восстановления пароля
        {
            DataRecoveryForm f = new DataRecoveryForm();
            f.ShowDialog();
        }

        private void ReservationUpdate() // метод обновления информации бронировании
        {
            try
            {
                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `booking`", db.getConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (IsEvict((String)table.Rows[i]["date_of_departure"]))
                    {
                        EvictUser((UInt32)table.Rows[i]["id"]);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(Convert.ToString(exc), "Error");
            }
        }

        private Boolean IsEvict(String date) // метод проверки даты выезда с текщей датой
        {
            dateTimePicker1.Text = date;
            DateTime DOD = new DateTime(dateTimePicker1.Value.Ticks);
            DateTime CurrDay = DateTime.Now;
            TimeSpan Difference = DOD.Subtract(CurrDay);
            if (Difference.Days < 0)
            {
                return true;
            }
            return false;
        }
        private void EvictUser(UInt32 Id) // метод обновления базый данных 
        {
            MySqlCommand command = new MySqlCommand("UPDATE `booking` SET `valid` = @bV WHERE `booking`.`id` = @bI", db.getConnection());
            command.Parameters.Add("@bI", MySqlDbType.UInt32).Value = Id;
            command.Parameters.Add("@bV", MySqlDbType.Int16).Value = 1;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }
    }
}
