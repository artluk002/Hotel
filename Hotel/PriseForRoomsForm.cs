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
    public partial class PriseForRoomsForm : Form
    {
        private UInt32 B1 = 1, B2 = 2, B3 = 3, B4 = 4; 
        EntertainmentInfo Info;
        MainForm form;
        UserInfo user;
        DB db = DB.getInstance();

        private void buttonNextPage_Click(object sender, EventArgs e) // метод для обновления кнопок с информацие об развлечениях
        {
            if (!CheckConnection())
                return;
            if (B4 < 20)
            {
                B1 += 4;
                B2 += 4;
                B3 += 4;
                B4 += 4;
                UInt32[] IdMas = { B1, B2, B3, B4 };
                Button[] buttons = { button1, button2, button3, button4 };
                for (int i = 0; i < 4; i++)
                {
                    Info = new EntertainmentInfo(IdMas[i]);
                    buttons[i].Text = Info.getName();
                }
            }
        }

        private void buttonPrevPage_Click(object sender, EventArgs e)// метод для обновления кнопок с информацие об развлечениях
        {
            if (!CheckConnection())
                return;
            if (B1 > 1)
            {
                B1 -= 4;
                B2 -= 4;
                B3 -= 4;
                B4 -= 4;
                UInt32[] IdMas = { B1, B2, B3, B4 };
                Button[] buttons = { button1, button2, button3, button4 };
                for (int i = 0; i < 4; i++)
                {
                    Info = new EntertainmentInfo(IdMas[i]);
                    buttons[i].Text = Info.getName();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // обработчик нажатия на кнопку с информацие о развлечении
        {
            if (!CheckConnection())
                return;
            Info = new EntertainmentInfo(B1);
            textBoxInfo.Text = "Name: " + Info.getName() + Environment.NewLine + "Required age: " + Info.getAccessAge() + Environment.NewLine + "Required status: " + Info.getAccessStatus() + Environment.NewLine + "Price: " + Info.getPrice() + Environment.NewLine + "Description: " + Info.getDescription();
        }

        private void button2_Click(object sender, EventArgs e) // обработчик нажатия на кнопку с информацие о развлечении
        {
            if (!CheckConnection())
                return;
            Info = new EntertainmentInfo(B2);
            textBoxInfo.Text = "Name: " + Info.getName() + Environment.NewLine + "Required age: " + Info.getAccessAge() + Environment.NewLine + "Required status: " + Info.getAccessStatus() + Environment.NewLine + "Price: " + Info.getPrice() + Environment.NewLine + "Description: " + Info.getDescription();
        }

        private void button3_Click(object sender, EventArgs e) // обработчик нажатия на кнопку с информацие о развлечении
        {
            if (!CheckConnection())
                return;
            Info = new EntertainmentInfo(B3);
            textBoxInfo.Text = "Name: " + Info.getName() + Environment.NewLine + "Required age: " + Info.getAccessAge() + Environment.NewLine + "Required status: " + Info.getAccessStatus() + Environment.NewLine + "Price: " + Info.getPrice() + Environment.NewLine + "Description: " + Info.getDescription();
        }

        private void buttonExit_Click(object sender, EventArgs e) // обработчик нажатия кнопки выхода
        {
            form.Show();
            this.Close();
        }

        Point lastPoint;
        private void PriseForRoomsForm_MouseMove(object sender, MouseEventArgs e) // обработчик перемещения кнопки, которая позволяет перемещать форму 
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void PriseForRoomsForm_MouseDown(object sender, MouseEventArgs e) // обработчик нажатия кнопки, которая позволяет обновить координаты поля lastPoint
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonUserProfile_Click(object sender, EventArgs e) // обработчик кнопки пользовательского профиля, открывающий форму с пользовательской информацией
        {
            UserProfileForm UPF = new UserProfileForm(user.getUserID());
            UPF.Show();
        }

        private void button4_Click(object sender, EventArgs e) // обработчик нажатия на кнопку с информацие о развлечении
        {
            if (!CheckConnection())
                return;
            Info = new EntertainmentInfo(B4);
            textBoxInfo.Text = "Name: " + Info.getName() + Environment.NewLine + "Required age: " + Info.getAccessAge() + Environment.NewLine + "Required status: " + Info.getAccessStatus() + Environment.NewLine + "Price: " + Info.getPrice() + Environment.NewLine + "Description: " + Info.getDescription();
        }

        public PriseForRoomsForm(MainForm form, UInt32 ID) // конструктор с параметрами
        {
            try
            {
                this.form = form;
                InitializeComponent();
                user = UserInfo.getInstance(ID);
                UInt32[] IdMas = { B1, B2, B3, B4 };
                Button[] buttons = { button1, button2, button3, button4 };
                for (int i = 0; i < 4; i++)
                {
                    Info = new EntertainmentInfo(IdMas[i]);
                    buttons[i].Text = Info.getName();
                }
                buttonUserProfile.Text = user.getUserLogin();
            }
            catch (Exception exc)
            {
                MessageBox.Show(Convert.ToString(exc), "Error");
            }
        }

        private bool CheckConnection() // метод для проверки соединения с базой данных
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
    }
}
