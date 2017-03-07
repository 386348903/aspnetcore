using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gx
{
    public class DataCrypt
    {
        public static string MD5(string s)
        {
            var m= System.Security.Cryptography.MD5.Create();
            s= ASCIIEncoding.ASCII.GetString(m.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s)));
            return s;
        }
    }
}
