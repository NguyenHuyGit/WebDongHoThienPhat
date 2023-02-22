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
    public class QuyenDangNhapNhanViens_60135761Controller : Controller
    {
        private QLDHC_ThienPhatEntities db = new QLDHC_ThienPhatEntities();

        // GET: QuyenDangNhapNhanViens_60135761
        public ActionResult Index()
        {
            if (Session["idAdmin"] == null || Session["idAdmin"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Clients_60135761");
            }
            else
                return View(db.QuyenDangNhapNhanViens.ToList());
        }

        // GET: QuyenDangNhapNhanViens_60135761/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyenDangNhapNhanVien quyenDangNhapNhanVien = db.QuyenDangNhapNhanViens.Find(id);
            if (quyenDangNhapNhanVien == null)
            {
                return HttpNotFound();
            }
            return View(quyenDangNhapNhanVien);
        }

        // GET: QuyenDangNhapNhanViens_60135761/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuyenDangNhapNhanViens_60135761/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaQuyenDangNhap,TenQuyenDangNhap")] QuyenDangNhapNhanVien quyenDangNhapNhanVien)
        {
            if (ModelState.IsValid)
            {
                db.QuyenDangNhapNhanViens.Add(quyenDangNhapNhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quyenDangNhapNhanVien);
        }

        // GET: QuyenDangNhapNhanViens_60135761/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyenDangNhapNhanVien quyenDangNhapNhanVien = db.QuyenDangNhapNhanViens.Find(id);
            if (quyenDangNhapNhanVien == null)
            {
                return HttpNotFound();
            }
            return View(quyenDangNhapNhanVien);
        }

        // POST: QuyenDangNhapNhanViens_60135761/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaQuyenDangNhap,TenQuyenDangNhap")] QuyenDangNhapNhanVien quyenDangNhapNhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quyenDangNhapNhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quyenDangNhapNhanVien);
        }

        // GET: QuyenDangNhapNhanViens_60135761/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyenDangNhapNhanVien quyenDangNhapNhanVien = db.QuyenDangNhapNhanViens.Find(id);
            if (quyenDangNhapNhanVien == null)
            {
                return HttpNotFound();
            }
            return View(quyenDangNhapNhanVien);
        }

        // POST: QuyenDangNhapNhanViens_60135761/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuyenDangNhapNhanVien quyenDangNhapNhanVien = db.QuyenDangNhapNhanViens.Find(id);
            db.QuyenDangNhapNhanViens.Remove(quyenDangNhapNhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
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
