using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal
{
    public class bk
    {
        public static bool Insert(Model.bk m)
        {
            Gx.Sql sql = new Gx.Sql("(uid,sqly,name,zw,dw,jsxq,time,type) values(@uid,@sqly,@name,@zw,@dw,@jsxq,@time,@type)", "bk", "",m);
            if (sql.Insert() > 0)
                return true;
            return false;
        }
        public static bool Update(Model.bk m)
        {
            Gx.Sql sql = new Gx.Sql("type=@type", "bk", "where id=@id", m);
            if (sql.Update() > 0)
                return true;
            return false;
        }
        public static bool Delete(Model.bk m)
        {
            Gx.Sql sql = new Gx.Sql("", "bk", "where id=@id and uid=@uid", m);
            if (sql.Delete() > 0)
                return true;
            return false;
        }
        public static bool Exists(Model.bk m)
        {
            Gx.Sql sql = new Gx.Sql("*", "bk", "where (type=1 or type=0) and uid=@uid", m);
            return sql.Exists<Model.bk>();
        }
    }
}
