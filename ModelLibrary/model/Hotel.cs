using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.model
{
    public class Hotel
    {
        private int _id;
        private string _name;
        private string _address;
        private string _phoneNo;
        private string _eMail;

        public Hotel()
        {

        }

        public Hotel(int ID, string Name, string Address, string PhoneNo, string Email)
        {
            _id = ID;
            _name = Name;
            _address = Address;
            _phoneNo = PhoneNo;
            _eMail = Email;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public string PhoneNo
        {
            get => _phoneNo;
            set => _phoneNo = value;
        }

        public string Email
        {
            get => _eMail;
            set => _eMail = value;
        }

    }
}
