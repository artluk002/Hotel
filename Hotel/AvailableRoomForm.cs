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
    public partial class AvailableRoomForm : Form
    {
        MainForm mainForm;
        DataTable table = new DataTable();
        bool booking;
        DB db = DB.getInstance();
        public Button[] Btns = new Button[20];
        UserInfo user;
        public AvailableRoomForm(UInt32 UserID, MainForm mainForm) // конструктор формы AvailableRoomForm, который заполнят форму данными
        {
            InitializeComponent();

            this.mainForm = mainForm;
            user = UserInfo.getInstance(UserID);
            buttonUserProfile.Text = user.getUserLogin();

            booking = user.getUserBooking();

            Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20 };
            Btns = buttons;

            for (int i = 0; i < 20; i++)
            {
                Room value = new Room(Convert.ToInt32(Btns[i].Text));
                if (value.getUserRoom())
                    Btns[i].BackColor = Color.Yellow;
                else if (value.getIsBooked())
                    Btns[i].BackColor = Color.Red;
                else
                    Btns[i].BackColor = Color.Green;
            }
        }
        public void update() // метод обновления формы
        {
            booking = user.getUserBooking();
            for (int i = 0; i < 20; i++)
            {
                Room value = new Room(Convert.ToInt32(Btns[i].Text));
                if (value.getUserRoom())
                    Btns[i].BackColor = Color.Yellow;
                else if (value.getIsBooked())
                    Btns[i].BackColor = Color.Red;
                else
                    Btns[i].BackColor = Color.Green;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e) // обработчик нажатия кнопки выхода
        {
            Application.Exit();
        }

        private void button21_Click(object sender, EventArgs e) // обработчик нажатия кнопки возврата на главную форму
        {
            this.Close();
            mainForm.Show();
        }

        private void buttonUserProfile_Click(object sender, EventArgs e) // обработчик нажатия кнопки информация о пользователе, который показывает пользовательскую информацию
        {
            UserProfileForm usp = new UserProfileForm(user.getUserID());
            usp.ShowDialog();
            this.update();
        }

        Point lastPoint;
        private void AvailableRoomForm_MouseMove(object sender, MouseEventArgs e) // обрабочик движения курсора для изменения положения окна
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void AvailableRoomForm_MouseDown(object sender, MouseEventArgs e) // обработчик нажатия левой кнопки мыши, который присваивает новые координаты объекту lastPoint
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[0], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void buttonNextPage_Click(object sender, EventArgs e) // обработчик нажатия кнопки следующая страница, которая показывает следующие 20 комнат
        {
            if (!CheckConnection())
                return;
            if (!(Convert.ToInt32(Btns[0].Text) > 400))
            {
                for (int i = 0; i < 20; i++)
                {
                    Btns[i].Text = Convert.ToString(Convert.ToInt32(Btns[i].Text) + 100);
                }
                for (int i = 0; i < 20; i++)
                {
                    Room value = new Room(Convert.ToInt32(Btns[i].Text));
                    if (value.getUserRoom())
                        Btns[i].BackColor = Color.Yellow;
                    else if (value.getIsBooked())
                        Btns[i].BackColor = Color.Red;
                    else
                        Btns[i].BackColor = Color.Green;
                }
            }
            checkedListBox1_SelectedIndexChanged(sender, e);
        }

        private void buttonPrevPage_Click(object sender, EventArgs e) // обработчик нажатия кнопки предыдущаяя страница, кторая показывает предыдущие 20 комнат
        {
            if (!CheckConnection())
                return;
            if (!(Convert.ToInt32(Btns[0].Text) < 102))
            {
                for (int i = 0; i < 20; i++)
                {
                    Btns[i].Text = Convert.ToString(Convert.ToInt32(Btns[i].Text) - 100);
                }
                for (int i = 0; i < 20; i++)
                {
                    Room value = new Room(Convert.ToInt32(Btns[i].Text));
                    if (value.getUserRoom())
                        Btns[i].BackColor = Color.Yellow;
                    else if (value.getIsBooked())
                        Btns[i].BackColor = Color.Red;
                    else
                        Btns[i].BackColor = Color.Green;
                }
            }
            checkedListBox1_SelectedIndexChanged(sender, e);
        }

        private void button8_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[7], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button3_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[2], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button4_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[3], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button5_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[4], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button6_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[5], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button7_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[6], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button2_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[1], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button9_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[8], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button10_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[9], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button11_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[10], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button12_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[11], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button13_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[12], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button14_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[13], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button15_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[14], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button16_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[15], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button17_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[16], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button18_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[17], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button19_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[18], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private void button20_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра информации об комнате
        {
            if (!CheckConnection())
                return;
            RIBClick b1 = new RIBClick(Btns[19], booking, user.getUserID());
            b1.getAllInformation();
            this.update();
        }

        private bool CheckConnection() // метод проветки соединения приложения с базой данных
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) // обработчик выбора типа комнаты, котрые будут показаны 
        {
            if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked)
                foreach (var item in Btns)
                {
                    Room value = new Room(Convert.ToInt32(item.Text));
                    if (value.isActiveRoom("One-room"))
                        item.Visible = true;
                }
            else
                foreach (var item in Btns)
                {
                    Room value = new Room(Convert.ToInt32(item.Text));
                    if (value.isActiveRoom("One-room"))
                        item.Visible = false;
                }

            if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
                foreach (var item in Btns)
                {
                    Room value = new Room(Convert.ToInt32(item.Text));
                    if (value.isActiveRoom("Two-room"))
                        item.Visible = true;
                }
            else
                foreach (var item in Btns)
                {
                    Room value = new Room(Convert.ToInt32(item.Text));
                    if (value.isActiveRoom("Two-room"))
                        item.Visible = false;
                }
            if (checkedListBox1.GetItemCheckState(2) == CheckState.Checked)
                foreach (var item in Btns)
                {
                    Room value = new Room(Convert.ToInt32(item.Text));
                    if (value.isActiveRoom("Three-room"))
                        item.Visible = true;
                }
            else
                foreach (var item in Btns)
                {
                    Room value = new Room(Convert.ToInt32(item.Text));
                    if (value.isActiveRoom("Three-room"))
                        item.Visible = false;
                }
            if (checkedListBox1.GetItemCheckState(0) == CheckState.Unchecked & checkedListBox1.GetItemCheckState(1) == CheckState.Unchecked & checkedListBox1.GetItemCheckState(2) == CheckState.Unchecked)
                foreach (var item in Btns)
                {
                    item.Visible = true;
                }
        }
    }
}
