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
    public class DongHoes_60135761Controller : Controller
    {
        private QLDHC_ThienPhatEntities db = new QLDHC_ThienPhatEntities();

        // GET: DongHoes_60135761
        public ActionResult Index()
        {
            var dongHoes = db.DongHoes.Include(d => d.LoaiDongHo).Include(d => d.NhaCungCap);
            if (Session["idAdmin"] == null || Session["idAdmin"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Clients_60135761");
            }
            else
                return View(dongHoes.ToList());
        }

        // GET: DongHoes_60135761/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongHo dongHo = db.DongHoes.Find(id);
            if (dongHo == null)
            {
                return HttpNotFound();
            }
            return View(dongHo);
        }

        // GET: DongHoes_60135761/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiDH = new SelectList(db.LoaiDongHoes, "MaLoaiDH", "TenLoaiDH");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            return View();
        }

        // POST: DongHoes_60135761/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,TenDongHo,AnhSanPham,GiaBan,Mota,GhiChu,MaLoaiDH,MaNCC")] DongHo dongHo)
        {
            var imgDH = Request.Files["Avatar"];

            string postedFileName = System.IO.Path.GetFileName(imgDH.FileName);

            var path = Server.MapPath("/Images/" + postedFileName);
            imgDH.SaveAs(path);

            if (ModelState.IsValid)
            {
                dongHo.AnhSanPham = postedFileName;
                db.DongHoes.Add(dongHo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiDH = new SelectList(db.LoaiDongHoes, "MaLoaiDH", "TenLoaiDH", dongHo.MaLoaiDH);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", dongHo.MaNCC);
            return View(dongHo);
        }

        // GET: DongHoes_60135761/Edit/5
        public ActionResult Edit(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongHo dongHo = db.DongHoes.Find(id);
            if (dongHo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiDH = new SelectList(db.LoaiDongHoes, "MaLoaiDH", "TenLoaiDH", dongHo.MaLoaiDH);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", dongHo.MaNCC);
            return View(dongHo);
        }

        // POST: DongHoes_60135761/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,TenDongHo,AnhSanPham,GiaBan,Mota,GhiChu,MaLoaiDH,MaNCC")] DongHo dongHo)
        {
            var imgDH = Request.Files["Avatar"];
            try
            {
                string postedFileName = System.IO.Path.GetFileName(imgDH.FileName);
                var path = Server.MapPath("/Images/" + postedFileName);
                imgDH.SaveAs(path);
            }
            catch
            { }
            if (ModelState.IsValid)
            {
                db.Entry(dongHo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiDH = new SelectList(db.LoaiDongHoes, "MaLoaiDH", "TenLoaiDH", dongHo.MaLoaiDH);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", dongHo.MaNCC);
            return View(dongHo);
        }

        // GET: DongHoes_60135761/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongHo dongHo = db.DongHoes.Find(id);
            if (dongHo == null)
            {
                return HttpNotFound();
            }
            return View(dongHo);
        }

        // POST: DongHoes_60135761/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DongHo dongHo = db.DongHoes.Find(id);
            db.DongHoes.Remove(dongHo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TimKiem_60135761(string maDH = "", string tenDH = "", string giaMin = "", string giaMax = "", string maloaiDH = "", string maNCC = "")
        {
            string min = giaMin, max = giaMax;
            ViewBag.maDH = maDH;
            ViewBag.tenDH = tenDH;
            if (giaMin == "")
            {
                ViewBag.giaMin = "";
                min = "0";
            }
            else
            {
                ViewBag.giaMin = giaMin;
                min = giaMin;
            }
            if (max == "")
            {
                max = Int32.MaxValue.ToString();
                ViewBag.giaMax = "";// Int32.MaxValue.ToString(); 
            }
            else
            {
                ViewBag.giaMax = giaMax;
                max = giaMax;
            }
            ViewBag.MaLoaiDH = new SelectList(db.LoaiDongHoes, "MaLoaiDH", "TenLoaiDH");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            var dongHoes = db.DongHoes.SqlQuery("DongHo_TimKiem'" + maDH + "',N'" + tenDH + "','" + min + "','" + max + "','" + maloaiDH + "','" + maNCC + "'");
            if (dongHoes.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(dongHoes.ToList());
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
