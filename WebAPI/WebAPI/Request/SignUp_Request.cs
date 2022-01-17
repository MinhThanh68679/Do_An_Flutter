using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Request
{
    public class SignUp_Request
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Pass { get; set; }
        public String Avatar { get; set; }
    }
}
