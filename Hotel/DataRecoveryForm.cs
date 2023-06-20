using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class DataRecoveryForm : Form
    {
        private int num;
        private int attempts = 0;
        private DataRow[] userInfo;
        DB db = DB.getInstance();
        public DataRecoveryForm() // конструктор формы DataRecoveryForm
        {
            InitializeComponent();
        }

        public bool IsValid(string emailaddress) // метод проверки корректности ввода почтового адреса
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                Regex r = new Regex("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])");
                if (!(r.IsMatch(emailaddress)))
                    return false;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public bool IsExist(string emailaddress) // метод проверки существования введённого адреса в базе данных 
        {
            try
            {
                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `email` = @uM", db.getConnection());
                command.Parameters.Add("@uM", MySqlDbType.VarChar).Value = emailaddress;

                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    userInfo = table.Select();
                    return true;
                }
                else
                {
                    MessageBox.Show("E-mail isn't correct");
                    return false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(Convert.ToString(exc), "Error");
                return false;
            }
        }
        public void SendCode(MailMessage m) // метод отправки сообщения на адрес пользователя с кодом подтверждения
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("mineboyplayyt@gmail.com", "pzovovnlxxixrxwr"),
                    EnableSsl = true
                };
                smtp.Send(m);
                MessageBox.Show("message was sent on your e-mail");
            }
            catch (Exception exc)
            {
                MessageBox.Show(Convert.ToString(exc), "Error");
            }
        }
        private void buttonSendMessage_Click(object sender, EventArgs e) // обработчик нажатия кнопки buttonSendMessage, который отправляет код на почту пользователя
        {
            try
            {
                if (textBoxUserMail.Text == "")
                    return;
                String UserMail = textBoxUserMail.Text;
                if (!IsValid(UserMail))
                {
                    return;
                }
                if (!IsExist(UserMail))
                {
                    MessageBox.Show("User with this e-mail isn't Exist", "Error");
                    return;
                }
                Random r = new Random();
                num = r.Next();
                MailMessage mail = new MailMessageBuilder()
                    .From("mineboyplayyt@gmail.com")
                    .To(UserMail)
                    .Subject("Data Recovery!")
                    .Body($"Your access code: {num}", Encoding.UTF8)
                    .Build();
                SendCode(mail);
                buttonSendMessage.Enabled = false;
                buttonSendMessage.Visible = false;
                buttonAcceptCode.Location = buttonSendMessage.Location;
                buttonAcceptCode.Enabled = true;
                buttonAcceptCode.Visible = true;
                textBoxUserMail.Text = "";
                label1.Text = "Enter your Code";
            }
            catch (Exception exc)
            {
                MessageBox.Show(Convert.ToString(exc), "Error");
            }
        }

        private void buttonAcceptCode_Click(object sender, EventArgs e) // обработчик кнопки buttonAcceptCode, которая проверят введённый код на соответствие с отправленным
        {
            try
            {
                if (attempts > 3)
                {
                    MessageBox.Show("Your attempts are over", "Error");
                    return;
                }
                if (textBoxUserMail.Text == "")
                {
                    return;
                }
                if (!(num == Convert.ToInt32(textBoxUserMail.Text)))
                {
                    attempts++;
                    MessageBox.Show("Codes don't match", "Error");
                    return;
                }
                label1.Text = "Enter a new password";
                label2.Visible = true;
                textBoxRepitPassword.Enabled = true;
                textBoxRepitPassword.Visible = true;
                buttonChangePassword.Location = buttonSendMessage.Location;
                buttonChangePassword.Visible = true;
                buttonChangePassword.Enabled = true;
                buttonAcceptCode.Visible = false;
                buttonAcceptCode.Enabled = false;
                textBoxUserMail.Text = "";
            }
            catch (Exception exc)
            {
                MessageBox.Show(Convert.ToString(exc), "Error");
            }
        }

        Point lastPoint;
        private void DataRecoveryForm_MouseMove(object sender, MouseEventArgs e) // обработчик перемешения курсора, который позволяет перемещать форму
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void DataRecoveryForm_MouseDown(object sender, MouseEventArgs e) // обработчик нажатия левой кнопки мыши, который обновляет координаты поля lastPoint
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e) // обработчик кнопки закрытия формы
        {
            this.Close();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e) // обработчик кнопки обновления пароля, который переписывает пароль
        {
            try
            {
                if (textBoxUserMail.Text != textBoxRepitPassword.Text)
                {
                    MessageBox.Show("Passwords don't match", "Error");
                    return;
                }
                if (textBoxRepitPassword.Text == "" || textBoxRepitPassword.Text == "")
                    return;

                MySqlCommand command = new MySqlCommand("UPDATE `user` SET `password` = @uP WHERE `user`.`id` = @uI;", db.getConnection());
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = textBoxUserMail.Text.GetHashCode().ToString();
                command.Parameters.Add("@uI", MySqlDbType.UInt32).Value = Convert.ToUInt32(userInfo[0][0]);

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Your password have been changed");
                    this.Close();
                }
                db.closeConnection();
            }
            catch (Exception exc)
            {
                MessageBox.Show(Convert.ToString(exc), "Error");
            }
        }
    }
}
