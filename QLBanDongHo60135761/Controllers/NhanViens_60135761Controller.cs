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
    public class NhanViens_60135761Controller : Controller
    {
        private QLDHC_ThienPhatEntities db = new QLDHC_ThienPhatEntities();

        // GET: NhanViens_60135761
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.ChucVu).Include(n => n.QuyenDangNhapNhanVien);
            if (Session["idAdmin"] == null || Session["idAdmin"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Clients_60135761");
            }
            else
                return View(nhanViens.ToList());
        }

        // GET: NhanViens_60135761/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens_60135761/Create
        public ActionResult Create()
        {
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu");
            ViewBag.MaQuyenDangNhap = new SelectList(db.QuyenDangNhapNhanViens, "MaQuyenDangNhap", "TenQuyenDangNhap");
            return View();
        }

        // POST: NhanViens_60135761/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoTenNV,NgayLamViec,GioiTinhNV,SDTNV,DiaChiNV,AnhNV,Luong,Email,MatKhau,MaQuyenDangNhap,MaChucVu")] NhanVien nhanVien)
        {
            var imgNV = Request.Files["Avatar"];

            string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);

            var path = Server.MapPath("/Images/" + postedFileName);
            imgNV.SaveAs(path);

            if (ModelState.IsValid)
            {
                nhanVien.AnhNV = postedFileName;
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaQuyenDangNhap = new SelectList(db.QuyenDangNhapNhanViens, "MaQuyenDangNhap", "TenQuyenDangNhap", nhanVien.MaQuyenDangNhap);
            return View(nhanVien);
        }

        // GET: NhanViens_60135761/Edit/5
        public ActionResult Edit(string id)
        {           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaQuyenDangNhap = new SelectList(db.QuyenDangNhapNhanViens, "MaQuyenDangNhap", "TenQuyenDangNhap", nhanVien.MaQuyenDangNhap);
            return View(nhanVien);
        }

        // POST: NhanViens_60135761/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoTenNV,NgayLamViec,GioiTinhNV,SDTNV,DiaChiNV,AnhNV,Luong,Email,MatKhau,MaQuyenDangNhap,MaChucVu")] NhanVien nhanVien)
        {
            var imgNV = Request.Files["Avatar"];
            try
            {
                string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
                var path = Server.MapPath("/Images/" + postedFileName);
                imgNV.SaveAs(path);
            }
            catch
            { }
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaQuyenDangNhap = new SelectList(db.QuyenDangNhapNhanViens, "MaQuyenDangNhap", "TenQuyenDangNhap", nhanVien.MaQuyenDangNhap);
            return View(nhanVien);
        }

        // GET: NhanViens_60135761/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens_60135761/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TimKiemNV_60135761(string maNV = "", string hoTen = "", string gioiTinh = "", string diaChi = "", string luongMin = "", string luongMax = "", string MaChucVu = "")
        {
            string min = luongMin, max = luongMax;
            if (gioiTinh != "1" && gioiTinh != "0")
                gioiTinh = null;
            ViewBag.maNV = maNV;
            ViewBag.hoTen = hoTen;
            ViewBag.gioiTinh = gioiTinh;
            if (luongMin == "")
            {
                ViewBag.luongMin = "";
                min = "0";
            }
            else
            {
                ViewBag.luongMin = luongMin;
                min = luongMin;
            }
            if (max == "")
            {
                max = Int32.MaxValue.ToString();
                ViewBag.luongMax = "";// Int32.MaxValue.ToString(); 
            }
            else
            {
                ViewBag.luongMax = luongMax;
                max = luongMax;
            }

            ViewBag.diaChi = diaChi;
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu");
            var nhanViens = db.NhanViens.SqlQuery("NhanVien_TimKiem'" + maNV + "',N'" + hoTen + "','" + gioiTinh + "',N'" + diaChi + "','" + min + "','" + max + "','" + MaChucVu + "'");
            if (nhanViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(nhanViens.ToList());
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
