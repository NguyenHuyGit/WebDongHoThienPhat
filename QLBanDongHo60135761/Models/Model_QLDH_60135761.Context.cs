﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBanDongHo60135761.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QLDHC_ThienPhatEntities : DbContext
    {
        public QLDHC_ThienPhatEntities()
            : base("name=QLDHC_ThienPhatEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CTHDB> CTHDBs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DongHo> DongHoes { get; set; }
        public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiDongHo> LoaiDongHoes { get; set; }
        public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<QuanTriVien> QuanTriViens { get; set; }
        public virtual DbSet<QuocGia> QuocGias { get; set; }
        public virtual DbSet<QuyenDangNhapNhanVien> QuyenDangNhapNhanViens { get; set; }
    
        public virtual int DongHo_TimKiem(string maDH, string tenDongHo, string giaBanMin, string giaBanMax, string maLoaiDH, string maNCC)
        {
            var maDHParameter = maDH != null ?
                new ObjectParameter("MaDH", maDH) :
                new ObjectParameter("MaDH", typeof(string));
    
            var tenDongHoParameter = tenDongHo != null ?
                new ObjectParameter("TenDongHo", tenDongHo) :
                new ObjectParameter("TenDongHo", typeof(string));
    
            var giaBanMinParameter = giaBanMin != null ?
                new ObjectParameter("GiaBanMin", giaBanMin) :
                new ObjectParameter("GiaBanMin", typeof(string));
    
            var giaBanMaxParameter = giaBanMax != null ?
                new ObjectParameter("GiaBanMax", giaBanMax) :
                new ObjectParameter("GiaBanMax", typeof(string));
    
            var maLoaiDHParameter = maLoaiDH != null ?
                new ObjectParameter("MaLoaiDH", maLoaiDH) :
                new ObjectParameter("MaLoaiDH", typeof(string));
    
            var maNCCParameter = maNCC != null ?
                new ObjectParameter("MaNCC", maNCC) :
                new ObjectParameter("MaNCC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DongHo_TimKiem", maDHParameter, tenDongHoParameter, giaBanMinParameter, giaBanMaxParameter, maLoaiDHParameter, maNCCParameter);
        }
    
        public virtual int KhachHang_TimKiem(string hoTenKH, string gioiTinhKH, string diaChiKH, string maLoaiKH)
        {
            var hoTenKHParameter = hoTenKH != null ?
                new ObjectParameter("HoTenKH", hoTenKH) :
                new ObjectParameter("HoTenKH", typeof(string));
    
            var gioiTinhKHParameter = gioiTinhKH != null ?
                new ObjectParameter("GioiTinhKH", gioiTinhKH) :
                new ObjectParameter("GioiTinhKH", typeof(string));
    
            var diaChiKHParameter = diaChiKH != null ?
                new ObjectParameter("DiaChiKH", diaChiKH) :
                new ObjectParameter("DiaChiKH", typeof(string));
    
            var maLoaiKHParameter = maLoaiKH != null ?
                new ObjectParameter("MaLoaiKH", maLoaiKH) :
                new ObjectParameter("MaLoaiKH", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KhachHang_TimKiem", hoTenKHParameter, gioiTinhKHParameter, diaChiKHParameter, maLoaiKHParameter);
        }
    
        public virtual int NhanVien_TimKiem(string maNV, string hoTenNV, string gioiTinhNV, string diaChi, string luongMin, string luongMax, string maChucVu)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var hoTenNVParameter = hoTenNV != null ?
                new ObjectParameter("HoTenNV", hoTenNV) :
                new ObjectParameter("HoTenNV", typeof(string));
    
            var gioiTinhNVParameter = gioiTinhNV != null ?
                new ObjectParameter("GioiTinhNV", gioiTinhNV) :
                new ObjectParameter("GioiTinhNV", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var luongMinParameter = luongMin != null ?
                new ObjectParameter("LuongMin", luongMin) :
                new ObjectParameter("LuongMin", typeof(string));
    
            var luongMaxParameter = luongMax != null ?
                new ObjectParameter("LuongMax", luongMax) :
                new ObjectParameter("LuongMax", typeof(string));
    
            var maChucVuParameter = maChucVu != null ?
                new ObjectParameter("MaChucVu", maChucVu) :
                new ObjectParameter("MaChucVu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("NhanVien_TimKiem", maNVParameter, hoTenNVParameter, gioiTinhNVParameter, diaChiParameter, luongMinParameter, luongMaxParameter, maChucVuParameter);
        }
    }
}
