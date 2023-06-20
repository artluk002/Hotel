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
    internal class RIBClick
    {
        Button Btns;
        String Status;
        bool booking;
        UInt32 userId;
        UserInfo user;
        DB db = DB.getInstance();
        Room room;
        public RIBClick(Button Btns, bool booking, UInt32 userId) // конструктор с параметрами
        {
            this.Btns = Btns;
            this.booking = booking;
            this.userId = userId;
            user = UserInfo.getInstance(userId);
            this.Status = user.getUserStatus();
            room = new Room(Convert.ToInt32(Btns.Text));
        }

        public void getAllInformation() // метод полчуния информации
        {
            if (room.getUserRoom())
            {
                buttonMakeReservation window = new buttonMakeReservation(Convert.ToInt32(Btns.Text), userId);
                window.ShowDialog();
            }
            else if (Status != "admin")
            {
                buttonMakeReservation window = new buttonMakeReservation(Convert.ToInt32(Btns.Text), booking, userId);
                window.ShowDialog();
            }
            else
            {
                buttonMakeReservation window = new buttonMakeReservation(Convert.ToInt32(Btns.Text), booking, userId);
                window.ShowDialog();
            }
        }
    }
}
