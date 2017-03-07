using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace web.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(int id=0)
        {
            string json = HttpContext.Session.GetString("user_login");
            if (json == null)
            {
                return Redirect("/home/index");
            }
            Model.user_login u_l = Gx.Json.StrToObj<Model.user_login>(json);
            Model.Userone u = Bll.Login.Get_User(u_l);
            if (u == null)
                return Redirect("/home/index");
            if(u.role!="管理员")
                return Redirect("/home/index");
            List<Model.V_bk> l = Bll.shengpi.SelectList(id);
            string n = "";
            switch(id)
            {
                case -1:n = "未通过"; break;
                case 0: n = "未审核"; break;
                case 1: n = "已通过"; break;
            }
            ViewBag.type = n;
            ViewBag.list = l;
            ViewBag.name = u.name;
            return View();
        }
        public IActionResult sp(int id,int type)
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
            Model.bk b = new Model.bk() {id=id, type= type};
            if (Bll.shengpi.Update(b))
            {
                ajax.result = true;
                ajax.message = "审批成功！";
            }
            else
            {
                ajax.result = false;
                ajax.message = "审批失败！";
            }
            ///
            u_l = Bll.Login.User_Login_Update(u_l);
            if (u_l != null)
                HttpContext.Session.SetString("user_login", Gx.Json.ObjToStr(u_l));
            return Content(ajax.ToString());
        }
    }
}