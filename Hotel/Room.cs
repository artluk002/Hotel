using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal class Room
    {
        int room_number;
        protected Boolean IsBooked;
        DataRow[] room_info;
        DataRow[] booking_info;
        protected String room_type;
        protected String room_worker;
        protected UInt32 ID;
        protected Boolean UserRoom = false;
        UserInfo user = UserInfo.getInstance();
        DB db = DB.getInstance();
        public Room(int number) // конструктор с параметрами для получения информации о комнате и пользователях, которые в данный момент забронировали комнату
        {
            room_number = number;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `room` WHERE `number` = @rN", db.getConnection());
            command.Parameters.Add("@rN", MySqlDbType.Int32).Value = room_number;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                room_info = table.Select();
                room_type = Convert.ToString(room_info[0][2]);
                room_worker = Convert.ToString(room_info[0][4]);
                ID = Convert.ToUInt32(room_info[0][0]);
            }

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `booking` WHERE `room_id` = @rI", db.getConnection());
            command1.Parameters.Add("@rI", MySqlDbType.UInt32).Value = (UInt32)room_info[0][0];

            table = new DataTable();
            adapter.SelectCommand = command1;
            adapter.Fill(table);

            booking_info = table.Select();
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (!(Boolean)booking_info[i][5])
                    {
                        DateTime DOA = Convert.ToDateTime(booking_info[i][3].ToString());
                        DateTime DOD = Convert.ToDateTime(booking_info[i][4].ToString());

                        if (DateTime.Today >= DOA && DateTime.Today <= DOD)
                        {
                            IsBooked = true;
                        }
                        if (user.getUserID() == Convert.ToUInt32(booking_info[i][1]))
                        {
                            UserRoom = true;
                        }
                    }
                }
            }
            else
            {
                IsBooked = false;
            }
        }
        public Boolean getIsBooked() // метод получения поля IsBooked
        {
            return IsBooked;
        }
        public String getRoomWorker() // метод получения поля room_worker
        {
            return room_worker;
        }
        public UInt32 getRoomId() // метод получения поля ID
        {
            return ID;
        }
        public Boolean getUserRoom() // метод получения поля UserRoom
        {
            return UserRoom;
        }
        public Boolean isActiveRoom(String type) // метод получения true или false, которые показывают забронирована ли комната 
        {
            if (type == (String)room_info[0][2])
                return true;
            return false;
        }
    }
}
