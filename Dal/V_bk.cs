using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal
{
    public class V_bk
    {
        public static List<Model.V_bk> SelectList(Model.V_bk m)
        {
            Gx.Sql s = new Gx.Sql("*", "v_bk", "where type=@type order by time desc", m);
            return s.SelectList<Model.V_bk>();
        }
        public static List<Model.V_bk> UserList(Model.V_bk m)
        {
            Gx.Sql s = new Gx.Sql("*", "v_bk", "where uid=@uid order by time desc", m);
            return s.SelectList<Model.V_bk>();
        }
    }
}
