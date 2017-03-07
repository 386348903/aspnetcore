using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal
{
    public class user_login
    {
        public static bool Update(Model.user_login m)
        {
            Gx.Sql s = new Gx.Sql("login=@login,token=@token,time=@time", "user_login", "where name=@name", m);
            if (s.Update() > 0)
                return true;
            return false;
        }
        public static bool Delete(Model.user_login m)
        {
            Gx.Sql s = new Gx.Sql("", "user_login", "where name=@name", m);
            if (s.Delete() > 0)
                return true;
            return false;
        }
        public static bool Insert(Model.user_login m)
        {
            Delete(m);
            Gx.Sql s = new Gx.Sql("(name,login,token,time)values(@name,@login,@token,@time)", "user_login", "", m);
            if (s.Insert() > 0)
                return true;
            return false;
        }
        public static bool Exists(Model.user_login m)
        {
            Gx.Sql s = new Gx.Sql("*", "user_login", "where name=@name and login=@login and token=@token", m);
            return s.Exists<Model.user_login>();
        }
    }
}
