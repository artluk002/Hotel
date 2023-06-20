using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class MainForm : Form
    {
        DataTable table;
        DataRow[] userInfo;
        UserInfo user;
        DB db = DB.getInstance();

        public MainForm(DataTable uInfo) // конструктор формы с параметрами
        {
            try
            {
                InitializeComponent();

                table = uInfo;
                userInfo = uInfo.Select();
                user = UserInfo.getInstance(Convert.ToUInt32(userInfo[0][0]));
                buttonUserProfile.Text = Convert.ToString(userInfo[0][1]);
            }
            catch (Exception t)
            {
                MessageBox.Show(Convert.ToString(t), "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e) // обработчик кнопки выхода
        {
            Application.Exit();
        }

        Point lastPoint;
        private void MainForm_MouseMove(object sender, MouseEventArgs e) // обработчик перемещения курсора, позволяющий перемещать форму
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e) // обработчик нажатия левой кнопки мыши, который обновляет координаты в поле lastPoint
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonUserProfile_Click(object sender, EventArgs e) // обработчик нажатия на кнопку пользовательского профиля, которая открывает форму с пользовательскими данными
        {
            UserProfileForm usp = new UserProfileForm(user.getUserID());
            usp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) // обработчик нажатия на кнопку комнат, открывает форму для бронирования комнат
        {
            if (!CheckConnection())
                return;
            AvailableRoomForm ARF = new AvailableRoomForm(user.getUserID(), this);
            ARF.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) // обработчи нажатия на кнопку платных развлечений, которая открывает новую форму для просмотра информации об развлечениях доступных для посещения
        {
            if (!CheckConnection())
                return;
            PriseForRoomsForm PFRF = new PriseForRoomsForm(this, user.getUserID());
            PFRF.Show();
            this.Hide();
        }

        private bool CheckConnection() // метод проверки соединения с базой данных
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // обработчик нажатия на текст для просмотра информации о статусе MVP
        {
            StatusForm statusForm = new StatusForm(this, "MVP");
            statusForm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // обработчик нажатия на текст для просмотра информации о статусе Default
        {
            StatusForm statusForm = new StatusForm(this, "Default");
            statusForm.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // обработчик нажатия на текст для просмотра информации о статусе VIP
        {
            StatusForm statusForm = new StatusForm(this, "VIP");
            statusForm.Show();
            this.Hide();
        }
    }
}
