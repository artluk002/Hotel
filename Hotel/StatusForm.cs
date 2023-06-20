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
    public partial class StatusForm : Form
    {
        String Status;
        MainForm form;
        UserInfo user = UserInfo.getInstance();
        DB db = DB.getInstance();
        Status status1;


        public StatusForm(MainForm form,String Status) // конструктор с параметрами
        {
            this.form = form;
            this.Status = Status;
            InitializeComponent();
            buttonUserProfile.Text = user.getUserLogin();
            if (user.getUserStatus() == "admin")
            {
                this.roundedButtonChangeDescription.Visible = true;
                textBoxText.ReadOnly = false;
            }
            switch (Status)
            {
                case "VIP":
                    status1 = new VIP();
                    this.linkLabelStatus.LinkColor = Color.Gold;
                    this.linkLabelStatus.ActiveLinkColor = Color.Yellow;
                    this.buttonBuyStatus.BackColor = Color.Gold;
                    this.buttonBuyStatus.FlatAppearance.MouseDownBackColor = Color.Yellow;
                    break;
                case "MVP":
                    status1 = new MVP();
                    this.linkLabelStatus.LinkColor = Color.BlueViolet;
                    this.linkLabelStatus.ActiveLinkColor = Color.MediumSlateBlue;
                    this.buttonBuyStatus.BackColor = Color.BlueViolet;
                    this.buttonBuyStatus.FlatAppearance.MouseDownBackColor = Color.MediumSlateBlue;
                    break;
                case "Default":
                    status1 = new Default();
                    this.linkLabelStatus.LinkColor = Color.BlanchedAlmond;
                    this.linkLabelStatus.ActiveLinkColor = Color.Snow;
                    this.buttonBuyStatus.BackColor = Color.BlanchedAlmond;
                    this.buttonBuyStatus.FlatAppearance.MouseDownBackColor = Color.Snow;
                    break;
                default:
                    return;
            }
            this.linkLabelStatus.Text = status1.getStaus();
            textBoxText.Text = status1.getDescription();
            if (status1.canBuyStatus(user))
                this.buttonBuyStatus.Visible = true;
            else
                this.buttonBuyStatus.Visible = false;

        }

        private void buttonExit_Click(object sender, EventArgs e) // обработчик нажатия кнопки выхода, закрывающий форму
        {
            form.Show();
            this.Close();
        }

        private void buttonBuyStatus_Click(object sender, EventArgs e) // обработчик кнопки купить статус, который отправляет запрос в базу данных
        {
            MySqlCommand command = new MySqlCommand("UPDATE `user` SET `status` = @s WHERE `user`.`id` = @uI", db.getConnection());
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = status1.getStaus();
            command.Parameters.Add("@uI", MySqlDbType.Int16).Value = user.getUserID();
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            user.Update();
            form.Show();
            this.Close();
        }

        Point lastPoint;
        private void StatusForm_MouseDown(object sender, MouseEventArgs e) // обработчик нажатия левой кнопки мыши, который обновляет координаты поля lastPoint
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void StatusForm_MouseMove(object sender, MouseEventArgs e) // обработчик перемещения курсора, который позволяет перемещать форму
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void buttonUserProfile_Click(object sender, EventArgs e) // обработчик нажатия кнопки пользовательского профиля, открывающаяя окно с пользовательскими данными
        {
            UserProfileForm userProfileForm;
            if (user.getUserStatus() == "admin")
                userProfileForm = new UserProfileForm(user.getUserID(), true);
            else
                userProfileForm = new UserProfileForm(user.getUserID());
            userProfileForm.ShowDialog();
        }

        private void roundedButtonChangeDescription_Click(object sender, EventArgs e) // обработчик кнопки изменения описания статуса, доступна только администратору
        {
            MySqlCommand command = new MySqlCommand("UPDATE `status` SET `description` = @sD WHERE `status`.`id` = @sI", db.getConnection());
            command.Parameters.Add("@sI", MySqlDbType.UInt32).Value = status1.ID;
            command.Parameters.Add("@sD", MySqlDbType.VarChar).Value = textBoxText.Text;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }
    }

    abstract class Status // абстрактный класс представляющий общую форму для статуса
    {
        public abstract int ID { get; }
        public abstract String description { get; set; }
        public abstract string getStaus();
        public abstract string getDescription();
        public abstract void setDescription();
        public abstract bool canBuyStatus(UserInfo userInfo);

    }
    class Default : Status // конкретный класс, наследник абстрактного клсаа Status, представляющий статус Default
    {
        public override int ID { get; } // переопределённой свойство ID с возможностью только для получения ID
        public override String description { get; set; } // переопределённой свойство description с возможностью получения и установления description
        public Default() // конструктор 
        {
            ID = 1;
            setDescription();
        }
        public override string getStaus() // переопределённый метод возвращающий статус
        {
            return "Default";
        }
        public override string getDescription() // переопределённый метод возвращающий описание
        {
            return description;
        }
        public override void setDescription() // переопределённый метод обновляющий описание в базе данных
        {
            DB db = DB.getInstance();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `status` WHERE `type` = @sT", db.getConnection());
            command.Parameters.Add("@sT", MySqlDbType.VarChar).Value = "Default";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataRow[] row = table.Select();
            this.description = row[0][2].ToString();
        }
        public override bool canBuyStatus(UserInfo userInfo) //переопределённый метод возвращающий false, т.к нельзя купить default
        {
            return false;
        }
    }
    class VIP : Status // конкретный класс, наследник абстрактного клсаа Status, представляющий статус VIP
    {
        public override int ID { get; } // переопределённой свойство ID с возможностью только для получения ID
        public override String description { get; set; } // переопределённой свойство description с возможностью получения и установления description
        public VIP() // конструктор 
        {
            ID = 2;
            setDescription();
        }
        public override string getStaus() // переопределённый метод возвращающий статус
        {
            return "VIP";
        }
        public override string getDescription() // переопределённый метод возвращающий описание
        {
            return description;
        }
        public override void setDescription() // переопределённый метод обновляющий описание в базе данных
        {
            DB db = DB.getInstance();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `status` WHERE `type` = @sT", db.getConnection());
            command.Parameters.Add("@sT", MySqlDbType.VarChar).Value = "VIP";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataRow[] row = table.Select();
            this.description = row[0][2].ToString();
        }
        public override bool canBuyStatus(UserInfo userInfo) //переопределённый метод возвращающий false или true, в зависимости от текущего статуса пользователя
        {
            if (userInfo.getUserStatus() == "MVP" | userInfo.getUserStatus() == "VIP" | userInfo.getUserStatus() == "admin")
                return false;
            else
                return true;
        }
    }
    class MVP : Status
    {
        public override int ID { get; } // переопределённой свойство ID с возможностью только для получения ID
        public override String description { get; set; } // переопределённой свойство description с возможностью получения и установления description

        public MVP() // конструктор 
        {
            ID = 3;
            setDescription();
        }
        public override string getStaus() // переопределённый метод возвращающий статус
        {
            return "MVP";
        }
        public override string getDescription() // переопределённый метод возвращающий описание
        {
            return description;
        }
        public override void setDescription() // переопределённый метод обновляющий описание в базе данных
        {
            DB db = DB.getInstance();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `status` WHERE `type` = @sT", db.getConnection());
            command.Parameters.Add("@sT", MySqlDbType.VarChar).Value = "MVP";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataRow[] row = table.Select();
            this.description = row[0][2].ToString();
        }
        public override bool canBuyStatus(UserInfo userInfo) //переопределённый метод возвращающий false или true, в зависимости от текущего статуса пользователя
        {
            if (userInfo.getUserStatus() == "MVP" | userInfo.getUserStatus() == "admin")
                return false;
            else
                return true;
        }
    }

}
