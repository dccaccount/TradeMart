using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeMart.Model
{
    public class RegisterModel
    {
        private string _agentname;
        private string _dob;
        private string _email;
        private string _phone;
        private string _location;

        public string AgentName
        {
            get { return _agentname; }
            set { _agentname = value; }
        }

        public string DOB
        {
            get { return _dob; }
            set { _dob = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
    }
}