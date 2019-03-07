using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.model
{
    public class Guest
    {
        private int _guestNo;
        private string _name;
        private string _phoneNo;
        private string _email;

        public Guest()
        {

        }

        public Guest(int guestNo, string name, string phoneNo, string email)
        {
            _guestNo = guestNo;
            _name = name;
            _phoneNo = phoneNo;
            _email = email;
        }

        public int GuestNo
        {
            get => _guestNo;
            set => _guestNo = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string PhoneNo
        {
            get => _phoneNo;
            set => _phoneNo = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public override string ToString()
        {
            return $"{nameof(_guestNo)}: {_guestNo}, {nameof(_name)}: {_name}, {nameof(_phoneNo)}: {_phoneNo}, {nameof(_email)}: {_email}";
        }
    }


}
