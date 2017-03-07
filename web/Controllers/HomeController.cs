using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(string username,string password)
        {
            Model.Userone u = Bll.Register.User_Insert(username, password);
            if(u==null)
            {
                return Content("<script >alert('注册失败！用户名已被占用！');window.location.href='/home/index'</script >", "text/html");
            }
            Model.user_login u_l= Bll.Login.User_Login(u.name, password);
            if (u_l == null)
            {
                return Content("<script >alert('注册失败！用户名已被占用！');window.location.href='/home/index'</script >", "text/html");
            }
            HttpContext.Session.SetString("user_login", Gx.Json.ObjToStr(u_l));
            return Redirect("/user/index");
        }
        public IActionResult Login(string name,string pwd)
        {
            Gx.AjaxMessage ajax = new Gx.AjaxMessage();
            Model.user_login u_l = Bll.Login.User_Login(name, pwd);
            if (u_l == null)
            {
                ajax.result = false;
                ajax.message = "失败！";
                return Content(ajax.ToString());
            }
            Model.Userone u = Bll.Login.Get_User(u_l);
            if(u==null)
            {
                ajax.result = false;
                ajax.message = "失败！";
                return Content(ajax.ToString());
            }
            HttpContext.Session.SetString("user_login", Gx.Json.ObjToStr(u_l));
            ajax.result = true;
            ajax.message = (u.role == "管理员" ? "/admin/index" : "/user/index");
            return Content(ajax.ToString());
        }
    }
}