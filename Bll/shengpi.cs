using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bll
{
    /// <summary>
    /// 博客审批
    /// </summary>
    public class shengpi
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="type">状态</param>
        /// <returns></returns>
        public static List<Model.V_bk> SelectList(int type)
        {
            Model.V_bk bk = new Model.V_bk() { type= type };
            return Dal.V_bk.SelectList(bk);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public static List<Model.V_bk> UserList(int uid)
        {
            Model.V_bk bk = new Model.V_bk() { uid = uid };
            return Dal.V_bk.UserList(bk);
        }
        public static bool Insert(Model.bk bk)
        {
            if (Dal.bk.Exists(bk))
                return false;
            return Dal.bk.Insert(bk);
        }
        public static bool Delete(Model.bk bk)
        {
            return Dal.bk.Delete(bk);
        }
        public static bool Update(Model.bk bk)
        {
            return Dal.bk.Update(bk);
        }
    }
}