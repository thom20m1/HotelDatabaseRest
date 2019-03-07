using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.Model
{
    public class Facility
    {
        private int _hotelNo;
        private int _facilityNo;
        private string _type;

        public Facility()
        {
        }

        public Facility(int hotelNo, int facilityNo, string type)
        {
            _hotelNo = hotelNo;
            _facilityNo = facilityNo;
            _type = type;
        }

        public int HotelNo
        {
            get => _hotelNo;
            set => _hotelNo = value;
        }

        public int FacilityNo
        {
            get => _facilityNo;
            set => _facilityNo = value;
        }

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public override string ToString()
        {
            return $"{nameof(_hotelNo)}: {_hotelNo}, {nameof(_facilityNo)}: {_facilityNo}, {nameof(_type)}: {_type}";
        }
    }
}
