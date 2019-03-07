using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.Model
{
    public class Booking
    {
        private int _bookingNo;
        private int _roomNo;
        private int _hotelNo;
        private int _guestNo;
        private string _startDate;
        private string _endDate;

        public Booking()
        {

        }

        public Booking(int bookingNo, int roomNo, int hotelNo, int guestNo, string startDate, string endDate)
        {
            _bookingNo = bookingNo;
            _roomNo = roomNo;
            _hotelNo = hotelNo;
            _guestNo = guestNo;
            _startDate = startDate;
            _endDate = endDate;
        }

        public int BookingNo
        {
            get => _bookingNo;
            set => _bookingNo = value;
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

        public int GuestNo
        {
            get => _guestNo;
            set => _guestNo = value;
        }

        public string StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        public string EndDate
        {
            get => _endDate;
            set => _endDate = value;
        }

        public override string ToString()
        {
            return $"{nameof(_bookingNo)}: {_bookingNo}, {nameof(_roomNo)}: {_roomNo}, {nameof(_hotelNo)}: {_hotelNo}, {nameof(_guestNo)}: {_guestNo}, {nameof(_startDate)}: {_startDate}, {nameof(_endDate)}: {_endDate}";
        }
    }
}
