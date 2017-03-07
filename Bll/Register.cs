using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bll
{
    /// <summary>
    /// 注册模块
    /// </summary>
    public class Register
    {
        /// <summary>
        /// 添加账号
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public static Model.Userone User_Insert(string name,string pwd)
        {
            Model.Userone user = new Model.Userone() { name = name, pwd = Gx.DataCrypt.MD5(pwd), role = "用户", time = DateTime.Now };
            //唯一性检验
            if (Dal.Userone.Exists_Register(user))
            {
                return null;
            }
            if(!Dal.Userone.Insert(user))
            {
                return null;
            }
            return user;
        }
    }
}
