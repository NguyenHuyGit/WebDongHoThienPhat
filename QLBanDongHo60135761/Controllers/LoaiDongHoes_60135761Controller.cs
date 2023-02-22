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
    public class LoaiDongHoes_60135761Controller : Controller
    {
        private QLDHC_ThienPhatEntities db = new QLDHC_ThienPhatEntities();

        // GET: LoaiDongHoes_60135761
        public ActionResult Index()
        {
            if (Session["idAdmin"] == null || Session["idAdmin"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Clients_60135761");
            }
            else
                return View(db.LoaiDongHoes.ToList());
        }

        // GET: LoaiDongHoes_60135761/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDongHo loaiDongHo = db.LoaiDongHoes.Find(id);
            if (loaiDongHo == null)
            {
                return HttpNotFound();
            }
            return View(loaiDongHo);
        }

        // GET: LoaiDongHoes_60135761/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiDongHoes_60135761/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiDH,TenLoaiDH")] LoaiDongHo loaiDongHo)
        {
            if (ModelState.IsValid)
            {
                db.LoaiDongHoes.Add(loaiDongHo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiDongHo);
        }

        // GET: LoaiDongHoes_60135761/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDongHo loaiDongHo = db.LoaiDongHoes.Find(id);
            if (loaiDongHo == null)
            {
                return HttpNotFound();
            }
            return View(loaiDongHo);
        }

        // POST: LoaiDongHoes_60135761/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiDH,TenLoaiDH")] LoaiDongHo loaiDongHo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiDongHo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiDongHo);
        }

        // GET: LoaiDongHoes_60135761/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDongHo loaiDongHo = db.LoaiDongHoes.Find(id);
            if (loaiDongHo == null)
            {
                return HttpNotFound();
            }
            return View(loaiDongHo);
        }

        // POST: LoaiDongHoes_60135761/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiDongHo loaiDongHo = db.LoaiDongHoes.Find(id);
            db.LoaiDongHoes.Remove(loaiDongHo);
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
