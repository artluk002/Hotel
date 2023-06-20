using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Hotel
{
    public partial class RegistrationForm : Form
    {
        DB db = DB.getInstance();
        private Int32 num;
        private int attempts;
        private String userLogin;
        private String userName;
        private String userPassword;
        private Int16 userAge;
        private String userMail;
        private String userPhone;
        Regex phoneRegex = new Regex(@"^(\+375|80)(17|25|29|33|44)(\d{7})$");
        Regex loginRegex = new Regex(@"^(\w{4,20})$");
        Regex passwordRegex = new Regex(@"^.{8,20}$");
        Regex mailRegex = new Regex(@"^.+@.+\..+$");
        public RegistrationForm() // конструктор
        {
            InitializeComponent();
        }

        private void linkLabelBackToSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // обработчик на текст, который закрывает форму
        {
            this.Close();
        }

        private void buttonRegistration_Click(object sender, EventArgs e) // обработчик нажатия кнопки регистрации, проверяющий данные на корректность ввода
        {

            try
            {
                if (textBoxName.Text == "")
                    return;
                if (textBoxAge.Text == "")
                    return;
                if (!ValidateChildren(ValidationConstraints.Enabled))
                    return;

                userLogin = textBoxLogin.Text;
                userName = textBoxName.Text;
                userPassword = textBoxPassword.Text;
                userAge = Convert.ToInt16(textBoxAge.Text);
                userMail = textBoxEmail.Text;
                userPhone = textBoxPhoneNumber.Text;

                if (userAge < 0 | userAge > 120)
                {
                    MessageBox.Show("Your age can't be younger than 0 and elder than 120", "Error");
                    return;
                }

                if (!IsMail(userMail))
                {
                    MessageBox.Show("It's not email format!", "Error");
                    return;
                }

                if (IsMailExist())
                {
                    MessageBox.Show("e-mail " + userMail + " is busy", "Error");
                    return;
                }

                if (IsUserExist())
                {
                    MessageBox.Show("Login " + userLogin + " is busy", "Error!");
                    return;
                }

                if (userPassword == textBoxRepitPassword.Text)
                {
                    labelLogin.Visible = false;
                    labelName.Visible = false;
                    labelAge.Visible = false;
                    labelEmail.Visible = false;
                    labelPassword.Visible = false;
                    labelRepitPassword.Visible = false;
                    labelPhoneNumber.Visible = false;
                    textBoxAge.Visible = false;
                    textBoxEmail.Visible = false;
                    textBoxName.Visible = false;
                    textBoxPassword.Visible = false;
                    textBoxRepitPassword.Visible = false; 
                    textBoxPhoneNumber.Visible = false;
                    buttonRegistration.Enabled = false;
                    buttonRegistration.Visible = false;
                    ButtonConfirmCode.Enabled = true;
                    ButtonConfirmCode.Visible = true;
                    textBoxLogin.Text = "";
                    checkBox1.Visible = false;
                    labelSignIn.Text = "Enter you access code";
                    SendCodeMessage(userMail);
                }
                else
                    MessageBox.Show("Passwords do not match", "Error");
            }
            catch (Exception t)
            {
                MessageBox.Show(Convert.ToString(t), "Error");
            }
        }

        public void SendCodeMessage(String mailaddress) // метод отправляющий сообщение с кодом подтверждения на почту пользователя
        {
            try
            {
                Random r = new Random();
                num = r.Next();
                MailMessage mail = new MailMessageBuilder()
                    .From("mineboyplayyt@gmail.com")
                    .To(mailaddress)
                    .Subject("Registration code")
                    .Body($"Your access code: {num}", Encoding.UTF8)
                    .Build();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("mineboyplayyt@gmail.com", "pzovovnlxxixrxwr"),
                    EnableSsl = true
                };
                smtp.Send(mail);
                MessageBox.Show("message with access code was sent on your e-mail address");
            }
            catch (Exception exc)
            {
                MessageBox.Show(Convert.ToString(exc), "Error");
            }
        }

        public Boolean IsUserExist() // метод проверки существования пользователя в базе данных
        {
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBoxLogin.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public Boolean IsMailExist() // метод проверки существования почты в базе данных
        {
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `email` = @uM", db.getConnection());
            command.Parameters.Add("@uM", MySqlDbType.VarChar).Value = textBoxEmail.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public Boolean IsMail(String thisMail) // метод проверки на правильность ввода почты
        {
            try
            {
                MailAddress mail = new MailAddress(thisMail);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        Point lastPoint;
        private void RegistrationForm_MouseMove(object sender, MouseEventArgs e) // обработчик перемещения курсора, который позволяет перемещать форму
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void RegistrationForm_MouseDown(object sender, MouseEventArgs e) // обработчик нажатия левой кнопки мыши, который обновляет координаты поля lastPoint
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) // обработчик нажатия на чек-бокс, позволяющий отобразить или скрыть пароль
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxRepitPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxRepitPassword.UseSystemPasswordChar = true;
            }
        }

        private void ButtonConfirmCode_Click(object sender, EventArgs e) // обработчик нажатия кнопки подтвержденя кода подтверждения, который отправляет запрос в базу данных
        {
            try
            {
                if (textBoxLogin.Text == "")
                    return;
                if (attempts > 3)
                {
                    MessageBox.Show("Your atempts are over", "Error");
                }
                Int32 code = Convert.ToInt32(textBoxLogin.Text);
                if (num != code)
                {
                    attempts++;
                    MessageBox.Show("Codes don't match", "Error");
                    return;
                }

                MySqlCommand command = new MySqlCommand("INSERT INTO `user` (`login`, `name`, `password`, `age`, `email`, `phone`) VALUES (@uL, @uN, @uP, @uAge, @uM, @uPN)", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userLogin;
                command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = userName;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userPassword.GetHashCode().ToString();
                command.Parameters.Add("@uAge", MySqlDbType.Int16).Value = userAge;
                command.Parameters.Add("@uM", MySqlDbType.VarChar).Value = userMail;
                command.Parameters.Add("@uPN", MySqlDbType.VarChar).Value = userPhone;

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Account was created");
                else
                    MessageBox.Show("Account wasn't created");

                db.closeConnection();
                this.Close();
            }
            catch (FormatException exc)
            {
                MessageBox.Show(Convert.ToString(exc), "Format Error");
            }
            catch (Exception exc)
            {
                MessageBox.Show(Convert.ToString(exc), "Error");
            }
        }

        private void textBoxPhoneNumber_Validating(object sender, CancelEventArgs e) // обработчик валидации данных у номера телефона
        {
            if (!phoneRegex.IsMatch(textBoxPhoneNumber.Text))
            {
                e.Cancel = true;
                textBoxPhoneNumber.Focus();
                errorProvider1.SetError(textBoxPhoneNumber, "The phone number is incorrect!");
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void textBoxLogin_Validating(object sender, CancelEventArgs e) // обработчик валидации данных у логина
        {
            if (!loginRegex.IsMatch(textBoxLogin.Text))
            {
                e.Cancel = true;
                textBoxLogin.Focus();
                errorProvider1.SetError(textBoxLogin, "Login is invalid. Must be between 4 and 20 characters!");
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void textBoxPassword_Validating(object sender, CancelEventArgs e) // обработчик валидации данных у пароля
        {
            if (!passwordRegex.IsMatch(textBoxPassword.Text))
            {
                e.Cancel = true;
                textBoxPassword.Focus();
                errorProvider1.SetError(textBoxPassword, "Password is invalid. Must be between 8 and 20 characters!");
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void textBoxRepitPassword_Validating(object sender, CancelEventArgs e) // обработчик валидации данных у повтора пароля
        {
            if (textBoxPassword.Text != textBoxRepitPassword.Text)
            {
                errorProvider1.SetError(textBoxRepitPassword, "Passwords don't match");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBoxEmail_Validating(object sender, CancelEventArgs e) //обработчик валидации данных у почты
        {
            if (!mailRegex.IsMatch(textBoxEmail.Text))
            {
                e.Cancel = true;
                textBoxEmail.Focus();
                errorProvider1.SetError(textBoxEmail, "Email isn't correct!");
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }
    }
}
