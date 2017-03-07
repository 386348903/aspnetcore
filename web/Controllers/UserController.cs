using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace web.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string json = HttpContext.Session.GetString("user_login");
            if (json == null)
            {
                return Redirect("/home/index");
            }
            Model.user_login u_l = Gx.Json.StrToObj<Model.user_login>(json);
            Model.Userone u = Bll.Login.Get_User(u_l);
            if(u==null)
            {
                return Redirect("/home/index");
            }
            List<Model.V_bk> l = Bll.shengpi.UserList(u.id);
            ViewBag.list = l;
            ViewBag.name = u.name;
            u_l = Bll.Login.User_Login_Update(u_l);
            if(u_l!=null)
                HttpContext.Session.SetString("user_login", Gx.Json.ObjToStr(u_l));
            return View();
        }
        public IActionResult sq(string reason, string name, string job, string address, string hobby)
        {
            string json = HttpContext.Session.GetString("user_login");
            if (json == null)
            {
                return Redirect("/home/index");
            }
            Model.user_login u_l = Gx.Json.StrToObj<Model.user_login>(json);
            Model.Userone u = Bll.Login.Get_User(u_l);
            if (u == null)
            {
                return Redirect("/home/index");
            }
            ///
            Gx.AjaxMessage ajax = new Gx.AjaxMessage();
            Model.bk b = new Model.bk() {
                uid = u.id,
                sqly = reason,
                name = name,
                zw = job,
                dw = address,
                jsxq = hobby,
                time =DateTime.Now,
                type =0
            };
            if (Bll.shengpi.Insert(b))
            {
                ajax.result = true;
                ajax.message = "申请成功请等待审核！";
            }
            else
            {
                ajax.result = false;
                ajax.message = "不能多次申请！";
            }
            ///
            u_l = Bll.Login.User_Login_Update(u_l);
            if (u_l != null)
                HttpContext.Session.SetString("user_login", Gx.Json.ObjToStr(u_l));
            return Content(ajax.ToString());
        }
        public IActionResult del(int id)
        {
            string json = HttpContext.Session.GetString("user_login");
            if (json == null)
            {
                return Redirect("/home/index");
            }
            Model.user_login u_l = Gx.Json.StrToObj<Model.user_login>(json);
            Model.Userone u = Bll.Login.Get_User(u_l);
            if (u == null)
            {
                return Redirect("/home/index");
            }
            ///
            Model.bk b = new Model.bk() { id=id,uid=u.id };
            Gx.AjaxMessage ajax = new Gx.AjaxMessage();
            if (Bll.shengpi.Delete(b))
            {
                ajax.result = true;
                ajax.message = "删除成功！";
            }
            else
            {
                ajax.result = false;
                ajax.message = "失败！";
            }
            ///
            u_l = Bll.Login.User_Login_Update(u_l);
            if (u_l != null)
                HttpContext.Session.SetString("user_login", Gx.Json.ObjToStr(u_l));
            return Content(ajax.ToString());
        }
    }
}