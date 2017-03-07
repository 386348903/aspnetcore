using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace Bll
{
    /// <summary>
    /// 登录模块
    /// </summary>
    public class Login
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public static Model.user_login User_Login(string name,string pwd)
        {
            Model.Userone user = new Model.Userone() {name= name, pwd=Gx.DataCrypt.MD5(pwd) };
            if(!Dal.Userone.Exists(user))
                return null;
            Random ran = new Random();
            Model.user_login u_l = new Model.user_login();
            u_l.name = user.name;
            u_l.login = ran.Next(1000000, 10000000).ToString();
            u_l.token = ran.Next(1000000, 10000000).ToString();
            u_l.time = DateTime.Now;
            if (!Dal.user_login.Insert(u_l))
                return null;
            return u_l;
        }
        /// <summary>
        /// 修改登录凭证
        /// </summary>
        /// <param name="u_l">登录凭证</param>
        /// <returns></returns>
        public static Model.user_login User_Login_Update(Model.user_login u_l)
        {
            Random ran = new Random();
            u_l.token = ran.Next(1000000, 10000000).ToString();
            u_l.time = DateTime.Now;
            if (!Dal.user_login.Update(u_l))
                return null;
            return u_l;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="u_l">登录凭证</param>
        /// <returns></returns>
        public static Model.Userone Get_User(Model.user_login u_l)
        {
            if (!Dal.user_login.Exists(u_l))
            {
                Dal.user_login.Delete(u_l);
                return null;
            }
            Model.Userone user = new Model.Userone() { name = u_l.name };
            return Dal.Userone.Get_User(user);
        }
    }
}