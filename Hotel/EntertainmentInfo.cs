using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    internal class EntertainmentInfo
    {
        private UInt32 ID;
        private String Name;
        private Int16 AccessAge;
        private String AccessStatus;
        private Int32 Price;
        private String description;
        DB db = DB.getInstance();

        public EntertainmentInfo(UInt32 ID) // конструктор с параметром id, который получает всю информацию из базы данных про развлечение через id
        {
            this.ID = ID;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataRow[] entertainmentInfo;

            MySqlCommand command = new MySqlCommand("SELECT * FROM `entertainment` WHERE `id` = @eI", db.getConnection());
            command.Parameters.Add("@eI", MySqlDbType.UInt32).Value = ID;
            
            adapter.SelectCommand = command;
            adapter.Fill(table);

            entertainmentInfo = table.Select();
            Name = Convert.ToString(entertainmentInfo[0][1]);
            AccessAge = Convert.ToInt16(entertainmentInfo[0][2]);
            AccessStatus = Convert.ToString(entertainmentInfo[0][3]);
            Price = Convert.ToInt32(entertainmentInfo[0][6]);
            description = Convert.ToString(entertainmentInfo[0][7]);
        }
        public string getName() // метод возвращающий название 
        {
            return this.Name;
        }
        public String getAccessAge() // метод возвращающий допустимый возраст
        {
            return Convert.ToString(this.AccessAge);
        }
        public String getAccessStatus() // метод возвращающий допустимый статус
        {
            return this.AccessStatus;
        }
        public String getPrice() // метод возвращающий цену 
        {
            return Convert.ToString(this.Price);
        }
        public String getDescription() // метод возвращающий описание
        {
            return this.description;
        }
    }
}
