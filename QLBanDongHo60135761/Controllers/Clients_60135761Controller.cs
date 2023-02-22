using QLBanDongHo60135761.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanDongHo60135761.Controllers
{
    public class Clients_60135761Controller : Controller
    {
        QLDHC_ThienPhatEntities _db = new QLDHC_ThienPhatEntities();
        // GET: Clients_60135761
        public ActionResult TrangChu()
        {
            return View(_db.DongHoes.ToList());
        }
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string email, string password)
        {
            if (ModelState.IsValid)
            {

                var data = _db.QuanTriViens.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    Session["idAdmin"] = data.FirstOrDefault().IdAdmin;
                    return RedirectToAction("../DongHoes_60135761/Index");
                }
                else
                {
                    ViewBag.error = "Đăng nhập không thành công! Vui lòng đăng nhập lại.";
                    return View("../Clients_60135761/DangNhap");
                }
            }
            return View();
        }

        public ActionResult ThanhCong()
        {
            return View();
        }
    }
}