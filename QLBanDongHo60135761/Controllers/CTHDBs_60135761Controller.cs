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
    public class CTHDBs_60135761Controller : Controller
    {
        private QLDHC_ThienPhatEntities db = new QLDHC_ThienPhatEntities();

        // GET: CTHDBs_60135761
        public ActionResult Index()
        {
            var cTHDBs = db.CTHDBs.Include(c => c.DongHo).Include(c => c.HoaDonBan);
            if (Session["idAdmin"] == null || Session["idAdmin"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Clients_60135761");
            }
            else
                return View(cTHDBs.ToList());
        }

        // GET: CTHDBs_60135761/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHDB cTHDB = db.CTHDBs.Find(id);
            if (cTHDB == null)
            {
                return HttpNotFound();
            }
            return View(cTHDB);
        }

        // GET: CTHDBs_60135761/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.DongHoes, "MaDH", "TenDongHo");
            ViewBag.MaHD = new SelectList(db.HoaDonBans, "MaHD", "MaHD");
            return View();
        }

        // POST: CTHDBs_60135761/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,SoLuong,DonGia,MaDH")] CTHDB cTHDB)
        {
            if (ModelState.IsValid)
            {
                db.CTHDBs.Add(cTHDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.DongHoes, "MaDH", "TenDongHo", cTHDB.MaDH);
            ViewBag.MaHD = new SelectList(db.HoaDonBans, "MaHD", "MaHD", cTHDB.MaHD);
            return View(cTHDB);
        }

        // GET: CTHDBs_60135761/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHDB cTHDB = db.CTHDBs.Find(id);
            if (cTHDB == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.DongHoes, "MaDH", "TenDongHo", cTHDB.MaDH);
            ViewBag.MaHD = new SelectList(db.HoaDonBans, "MaHD", "MaHD", cTHDB.MaHD);
            return View(cTHDB);
        }

        // POST: CTHDBs_60135761/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,SoLuong,DonGia,MaDH")] CTHDB cTHDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTHDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DongHoes, "MaDH", "TenDongHo", cTHDB.MaDH);
            ViewBag.MaHD = new SelectList(db.HoaDonBans, "MaHD", "MaHD", cTHDB.MaHD);
            return View(cTHDB);
        }

        // GET: CTHDBs_60135761/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHDB cTHDB = db.CTHDBs.Find(id);
            if (cTHDB == null)
            {
                return HttpNotFound();
            }
            return View(cTHDB);
        }

        // POST: CTHDBs_60135761/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTHDB cTHDB = db.CTHDBs.Find(id);
            db.CTHDBs.Remove(cTHDB);
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
