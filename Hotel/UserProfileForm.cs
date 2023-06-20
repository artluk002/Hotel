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
    public partial class UserProfileForm : Form
    {
        DataTable table = new DataTable();
        DB db = DB.getInstance();
        DataRow[] roomInfo;
        UserInfo user;
        bool AdminEnter;
        public UserProfileForm()
        {
            InitializeComponent();
        }
        public UserProfileForm(UInt32 UserID, bool admEnt = false) // конструктотр с параметрами
        {
            InitializeComponent();
            if (admEnt == false)
                this.user = UserInfo.getInstance(UserID);
            else
                this.user = new UserInfo(UserID);
            this.AdminEnter = admEnt;

            buttonUserProfile.Text = user.getUserLogin();
            textBoxLogin.Text = user.getUserLogin();
            textBoxEmail.Text = user.getUserMail();
            textBoxName.Text = user.getUserName();
            textBoxAge.Text = Convert.ToString(user.getUserAge());
            textBoxPhoneNumber.Text = user.getPhoneNum();
            textBoxUserStatus.Text = user.getUserStatus();
        }
        private void buttonExit_Click(object sender, EventArgs e) // обработчик нажати кнопки выхода, закрывающий форму 
        {
            this.Close();
        }

        Point lastPoint;
        private void UserProfileForm_MouseMove(object sender, MouseEventArgs e) // обработчик перемещения курсора, который позволяет перемещать форму
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void UserProfileForm_MouseDown(object sender, MouseEventArgs e) // обработчик нажатия левой кнопки мыши, который обновляет координаты поля lastPoint
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
