using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class user_login
    {
        public int id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string token { get; set; }
        public DateTime time { get; set; }
    }
}
