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
    public class NhaCungCaps_60135761Controller : Controller
    {
        private QLDHC_ThienPhatEntities db = new QLDHC_ThienPhatEntities();

        // GET: NhaCungCaps_60135761
        public ActionResult Index()
        {
            var nhaCungCaps = db.NhaCungCaps.Include(n => n.QuocGia);
            if (Session["idAdmin"] == null || Session["idAdmin"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Clients_60135761");
            }
            else
                return View(nhaCungCaps.ToList());
        }

        // GET: NhaCungCaps_60135761/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(id);
            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }
            return View(nhaCungCap);
        }

        // GET: NhaCungCaps_60135761/Create
        public ActionResult Create()
        {
            ViewBag.MaQuocGia = new SelectList(db.QuocGias, "MaQuocGia", "TenQuocGia");
            return View();
        }

        // POST: NhaCungCaps_60135761/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNCC,TenNCC,MaQuocGia")] NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                db.NhaCungCaps.Add(nhaCungCap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaQuocGia = new SelectList(db.QuocGias, "MaQuocGia", "TenQuocGia", nhaCungCap.MaQuocGia);
            return View(nhaCungCap);
        }

        // GET: NhaCungCaps_60135761/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(id);
            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaQuocGia = new SelectList(db.QuocGias, "MaQuocGia", "TenQuocGia", nhaCungCap.MaQuocGia);
            return View(nhaCungCap);
        }

        // POST: NhaCungCaps_60135761/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNCC,TenNCC,MaQuocGia")] NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaCungCap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaQuocGia = new SelectList(db.QuocGias, "MaQuocGia", "TenQuocGia", nhaCungCap.MaQuocGia);
            return View(nhaCungCap);
        }

        // GET: NhaCungCaps_60135761/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(id);
            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }
            return View(nhaCungCap);
        }

        // POST: NhaCungCaps_60135761/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(id);
            db.NhaCungCaps.Remove(nhaCungCap);
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
