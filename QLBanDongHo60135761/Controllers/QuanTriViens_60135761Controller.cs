using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanDongHo60135761.Controllers
{
    public class QuanTriViens_60135761Controller : Controller
    {
        // GET: QuanTriViens_60135761
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("../Clients_60135761/TrangChu");
        }
    }
}