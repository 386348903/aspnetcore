using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal
{
    public class Userone
    {
        public static bool Insert(Model.Userone m)
        {
            Gx.Sql s = new Gx.Sql("(name,pwd,role,time) values(@name,@pwd,@role,@time)", "Userone", "",m);
            if (s.Insert()>0)
            {
                return true;
            }
            return false;
        }
        public static bool Exists_Register(Model.Userone m)
        {
            Gx.Sql s = new Gx.Sql("*", "Userone", "where name=@name", m);
            return s.Exists<Model.Userone>();
        }
        public static bool Exists(Model.Userone m)
        {
            Gx.Sql s = new Gx.Sql("*", "Userone", "where name=@name and pwd=@pwd", m);
            return s.Exists<Model.Userone>();
        }
        public static Model.Userone Get_User(Model.Userone m)
        {
            Gx.Sql s = new Gx.Sql("*", "Userone", "where name=@name", m);
            return s.SelectFirst<Model.Userone>();
        }
    }
}