﻿namespace QuanLyKyTucXa_MVC.Models
{
    public class Modeldata
    {
        public List<Phong> phongs { get; set; }
        public Phong phong { get; set; }
        public SinhVien sinhVien { get; set; }
        public NguoiDung nguoiDung { get; set; }
        public ThuePhong thuePhong { get; set; }
        public ChuyenPhong chuyenPhong { get; set; }
        public DichVu dichVu { get; set; }
        public ThueDichVu thueDichVu { get; set; }
        public KyLuat kyLuat { get; set; }
        public ThongTinKhenThuong thongTinKhenThuong { get; set; }
        public TraPhong traPhong { get; set; }
        public List<NhanVien> nhanViens { get; set; }
        public BoPhan boPhans { get; set; }
    }
}
