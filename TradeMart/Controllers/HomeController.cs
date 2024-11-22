using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using TradeMart.Model;

namespace TradeMart.Controllers
{
    public class HomeController : Controller
    {
        DBContextEntity dbContext;

        public HomeController()
        {
            dbContext = new DBContextEntity();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AgentLogin()
        {
            return View();
        }

        public ActionResult AgentRegister()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AgentDashboardDetails(string agentid)
        {
            var result = dbContext.GetLoggedIn_Agent_Details(agentid);
            List<RegisterModel> list = new List<RegisterModel>();
            // Iterates through each row within the data table
            foreach (DataRow row in result.Rows)
            {
                var category = new RegisterModel();
                category.AgentName = row[1].ToString();
                category.Email = row[2].ToString();
                category.DOB = row[3].ToString();
                category.Phone = row[4].ToString();
                category.Location = row[5].ToString();

                list.Add(category);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DashBoard()
        {
            if (Session["luid"] != null)
            {
                DataTable dt = (DataTable)Session["luid"];
                ViewBag.agentid = dt.Rows[0][0].ToString();
            }
            else
            {
                return View();
            }
            return View();
        }
       
        public ActionResult LogOff()
        {
            Session["luid"] = "";
            Session["luid"] = null;
            return View("Index");
        }

        [HttpPost]
        public JsonResult AgentDetails(List<RegisterModel> agent)
        {
            DataTable dt=new DataTable();
            dt = dbContext.Insert_Agent_Details(agent);

            if (dt.Rows.Count > 0)
            {
                ViewBag.Message = "Data Insertion success";
            }
            return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AgentEmailValidate(string email)
        {
            object result = dbContext.Agent_email_validate(email);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AgentLoginValidate(List<RegisterModel> agent)
        {
            DataTable dt = null;
            var result = "";
                foreach (var res in agent)
                {
                    dt = dbContext.Validte_Agent_Login(res.Email, res.AgentName);
                }

            if (dt.Rows.Count > 0 && dt != null)
            {
                result = dt.Rows[0][0].ToString();
                Session["luid"] = dt;
            }
               return Json(result, JsonRequestBehavior.AllowGet);
         }
    }
}