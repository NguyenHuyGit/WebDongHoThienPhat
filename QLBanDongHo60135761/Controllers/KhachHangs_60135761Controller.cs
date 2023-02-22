using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBanDongHo60135761.Models;

namespace QLBanDongHo60135761.Controllers
{
    public class KhachHangs_60135761Controller : Controller
    {
        private QLDHC_ThienPhatEntities db = new QLDHC_ThienPhatEntities();

        // GET: KhachHangs_60135761
        public ActionResult Index()
        {
            var khachHangs = db.KhachHangs.Include(k => k.LoaiKhachHang);
            if (Session["idAdmin"] == null || Session["idAdmin"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Clients_60135761");
            }
            else
                return View(khachHangs.ToList());
        }

        // GET: KhachHangs_60135761/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: KhachHangs_60135761/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiKH = new SelectList(db.LoaiKhachHangs, "MaLoaiKH", "TenLoaiKH");
            return View();
        }

        // POST: KhachHangs_60135761/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,HoTenKH,GioiTinhKH,DiaChiKH,NgaySinhKH,SoDTKH,Email,TenDangNhap,MatKhau,MaLoaiKH")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiKH = new SelectList(db.LoaiKhachHangs, "MaLoaiKH", "TenLoaiKH", khachHang.MaLoaiKH);
            return View(khachHang);
        }

        // GET: KhachHangs_60135761/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiKH = new SelectList(db.LoaiKhachHangs, "MaLoaiKH", "TenLoaiKH", khachHang.MaLoaiKH);
            return View(khachHang);
        }

        // POST: KhachHangs_60135761/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,HoTenKH,GioiTinhKH,DiaChiKH,NgaySinhKH,SoDTKH,Email,TenDangNhap,MatKhau,MaLoaiKH")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiKH = new SelectList(db.LoaiKhachHangs, "MaLoaiKH", "TenLoaiKH", khachHang.MaLoaiKH);
            return View(khachHang);
        }

        // GET: KhachHangs_60135761/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }


        // POST: KhachHangs_60135761/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TimKiemKH_60135761(string hotenKH = "", string gioiTinhKH = "", string diachiKH = "", string maloaiKH = "")
        {
            if (gioiTinhKH != "1" && gioiTinhKH != "0")
                gioiTinhKH = null;
            ViewBag.hoTenKH = hotenKH;
            ViewBag.gioiTinhKH = gioiTinhKH;
            ViewBag.diaChiKH = diachiKH;
            ViewBag.MaLoaiKH = new SelectList(db.LoaiKhachHangs, "MaLoaiKH", "TenLoaiKH");
            var khachHangs = db.KhachHangs.SqlQuery("KhachHang_TimKiem N'" + hotenKH + "','" + gioiTinhKH + "',N'" + diachiKH + "','" + maloaiKH + "'");
            if (khachHangs.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(khachHangs.ToList());
        }

        public ActionResult DangKy()
        {
            ViewBag.MaLoaiKH = new SelectList(db.LoaiKhachHangs, "MaLoaiKH", "TenLoaiKH");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang _customer)
        {
            if (ModelState.IsValid)
            {
                var check = db.KhachHangs.FirstOrDefault(s => s.Email == _customer.Email);
                if (check == null)
                {

                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(_customer);
                    db.SaveChanges();
                    return RedirectToAction("../Clients_60135761/ThanhCong");
                }
                else
                {
                    
                    ViewBag.error = "Email đã tồn tại, vui lòng nhập email khác.";
                    ViewBag.MaLoaiKH = new SelectList(db.LoaiKhachHangs, "MaLoaiKH", "TenLoaiKH", _customer.MaLoaiKH);
                    return View("../KhachHangs_60135761/DangKy", _customer);
                }
            }
            ViewBag.MaLoaiKH = new SelectList(db.LoaiKhachHangs, "MaLoaiKH", "TenLoaiKH", _customer.MaLoaiKH);
            return View();
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
