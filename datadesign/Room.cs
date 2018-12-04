using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datadesign
{
    class Room
    {
        public String buildingnum;
        public String roomnum;
        public String brsex;
        public int size;
        public List<Room> roomlist = new List<Room>();
        public Room(string buildingnum, string roomnum, string brsex, int size)
        {
            this.buildingnum = buildingnum;
            this.roomnum = roomnum;
            this.brsex = brsex;
            this.size = size;
        }
        public void setRoom(String buildingnum, String roomnum, String brsex, int size)
        {
            this.buildingnum = buildingnum;
            this.roomnum = roomnum;
            this.brsex = brsex;
            this.size = size;
        }
        public new String ToString => buildingnum + "  " + roomnum + brsex + size.ToString();
        public void generate()
        {
            for (int i = 1; i <= 8; i++)
            {
                int roomnumber = 100;
                for (int j = 1; j <= 8; j++)
                {
                    for (int k = 1; k <= 20; k++)
                    {
                        roomnumber++;
                        Room temp = new Room(i.ToString(), roomnumber.ToString(), "", 6);
                        if (i % 2 == 0)
                        {
                            temp.setRoom(i.ToString(), roomnumber.ToString(), "男生宿舍", 6);
                        }
                        else
                        {
                            temp.setRoom(i.ToString(), roomnumber.ToString(), "女生宿舍", 4);
                        }
                        roomlist.Add(temp);
                    }
                    roomnumber -= 20;
                    roomnumber = roomnumber + 100;
                }
            }
        }
        public void show()
        {
            generate();
            foreach (Room i in roomlist)
            {
                Console.WriteLine(i.ToString);
            }
        }
        public List<Room> GetRoomList()
        {
            generate();
            return roomlist;
        }
    }
}
