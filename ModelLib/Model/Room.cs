using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.Model
{
    public class Room
    {

        private int _roomNo;
        private int _hotelNo;
        private string _kapacity;
        private int _price;

        public Room()
        {
        }

        public Room(int roomNo, int hotelNo, string kapacity, int price)
        {
            _roomNo = roomNo;
            _hotelNo = hotelNo;
            _kapacity = kapacity;
            _price = price;
        }

        public int RoomNo
        {
            get => _roomNo;
            set => _roomNo = value;
        }

        public int HotelNo
        {
            get => _hotelNo;
            set => _hotelNo = value;
        }

        public string Kapacity
        {
            get => _kapacity;
            set => _kapacity = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public override string ToString()
        {
            return $"{nameof(_roomNo)}: {_roomNo}, {nameof(_hotelNo)}: {_hotelNo}, {nameof(_kapacity)}: {_kapacity}, {nameof(_price)}: {_price}";
        }
    }
}
