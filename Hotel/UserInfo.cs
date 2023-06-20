using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal class UserInfo
    {
        private UInt32 ID;
        private String Login;
        private String Name;
        private String Password;
        private Int16 Age;
        private String Mail;
        private String PhoneNum;
        /*private UInt32 Room_Id;*/
        private String Status;
        private Boolean booking;
        DB db = DB.getInstance();
        private static UserInfo instance;

        private UserInfo() { } // приватный конструктор 

        public static UserInfo getInstance(UInt32 ID) // метод для возвращения текущего объекта класса или создания нового
        {
            if (instance == null)
                instance = new UserInfo(ID);
            return instance;
        }

        public static UserInfo getInstance() // метод для возвращения текущего объекта класса
        {
            return instance;
        }
        public UserInfo(UInt32 ID) // конструктор с параметрами
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `id` = @uI", db.getConnection());
            DataRow[] user_info;
            command.Parameters.Add("@uI", MySqlDbType.UInt32).Value = ID;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count <= 0)
                return;
            user_info = table.Select();
            this.ID = Convert.ToUInt32(user_info[0][0]);
            this.Login = Convert.ToString(user_info[0][1]);
            this.Name = Convert.ToString(user_info[0][2]);
            this.Password = Convert.ToString(user_info[0][3]);
            this.Age = Convert.ToInt16(user_info[0][4]);
            this.Mail = Convert.ToString(user_info[0][5]);
            this.PhoneNum = Convert.ToString(user_info[0][6]);
            this.Status = Convert.ToString(user_info[0][7]);
            BookingUpdate();
        }

        public UInt32 getUserID() // метод для полученмия Id пользователя
        {
            return this.ID;
        }
        public String getUserLogin() // метод для полученмия логина пользователя
        {
            return this.Login;
        }
        public String getUserName() // метод для полученмия имени пользователя
        {
            return this.Name;
        }
        public Int16 getUserAge() // метод для полученмия возраста пользователя
        {
            return this.Age;
        }
        public String getUserMail() // метод для полученмия почты пользователя
        {
            return this.Mail;
        }
        public String getPhoneNum() // метод для полученмия номера телефона пользователя
        {
            return this.PhoneNum;
        }
        public String getUserStatus() // метод для полученмия статуса пользователя
        {
            return this.Status;
        }
        public Boolean getUserBooking() // метод для полученмия поля booking
        {
            return booking;
        }
        private void BookingUpdate() // метод для обновления поля booking, которое в зависимости от статуса позволяет бронировать определённое количество комнат
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `booking` WHERE `user_id` = @uI AND `valid` = @bV", db.getConnection());
            command1.Parameters.Add("@uI", MySqlDbType.UInt32).Value = this.ID;
            command1.Parameters.Add("@bV", MySqlDbType.Int16).Value = 0;
            adapter.SelectCommand = command1;
            adapter.Fill(table);
            int CountOfRooms = table.Rows.Count;
            if (this.Status == "admin")
                booking = true;
            else if (this.Status == "Default")
                if (CountOfRooms < 3)
                    this.booking = true;
                else
                    this.booking = false;
            else if (this.Status == "VIP")
                if (CountOfRooms < 5)
                    this.booking = true;
                else
                    this.booking = false;
            else if (this.Status == "MVP")
                if (CountOfRooms < 8)
                    this.booking = true;
                else
                    this.booking = false;
            else
                booking = false;
        }
        public void Update() // метод обновляющий информацию о пользователе
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `id` = @uI", db.getConnection());
            DataRow[] user_info;
            command.Parameters.Add("@uI", MySqlDbType.UInt32).Value = ID;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            user_info = table.Select();
            this.ID = Convert.ToUInt32(user_info[0][0]);
            this.Login = Convert.ToString(user_info[0][1]);
            this.Name = Convert.ToString(user_info[0][2]);
            this.Password = Convert.ToString(user_info[0][3]);
            this.Age = Convert.ToInt16(user_info[0][4]);
            this.Mail = Convert.ToString(user_info[0][5]);
            this.PhoneNum = Convert.ToString(user_info[0][6]);
            this.Status = Convert.ToString(user_info[0][7]);
            BookingUpdate();
        }
    }
}
