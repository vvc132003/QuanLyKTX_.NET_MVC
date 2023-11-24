using Microsoft.AspNetCore.Mvc;
using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Service;

namespace QuanLyKyTucXa_MVC.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly SinhVienService sinhVienService;
        private readonly TraPhongService traPhongService;
        private readonly PhongService phongService;
        private readonly ThuePhongService thuePhongService;

        public SinhVienController(SinhVienService sinhVienServices, TraPhongService traPhongServices, PhongService phongServices, ThuePhongService thuePhongServices)
        {
            sinhVienService = sinhVienServices;
            traPhongService = traPhongServices;
            phongService = phongServices;   
            thuePhongService = thuePhongServices;
        }
       
        [HttpGet]
        public IActionResult SinhVienChuyenPhong(string id)
        {
            SinhVien sinhvien = sinhVienService.SinhVienGteById(id);
            return View("SinhVienChuyenPhong", sinhvien);
        }
        [HttpGet]
        public IActionResult SinhVienTraPhong(string id)
        {
            SinhVien sinhvien = sinhVienService.SinhVienGteById(id);
            TraPhong traphong = new TraPhong();

            Modeldata yourModel = new Modeldata
            {
                sinhVien = sinhvien,
                traPhong = traphong
            };

            return View("SinhVienTraPhong", yourModel);
        }

        public IActionResult SinhVienThuePhong(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                Phong phong = phongService.LayPhongTheoMa(id);
                SinhVien sinhvien = new SinhVien();
                ThuePhong thuePhong = new ThuePhong();
                Modeldata yourModel = new Modeldata
                {
                    phong = phong,
                    sinhVien = sinhvien,
                    thuePhong = thuePhong
                };
                int idnd = HttpContext.Session.GetInt32("id").Value;
                string tendangnhap = HttpContext.Session.GetString("tendangnhap");
                ViewData["id"] = idnd;
                ViewData["tendangnhap"] = tendangnhap;
                return View("SinhVienThuePhong", yourModel);
                }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }

        [HttpPost]
        public IActionResult ThuePhong(SinhVien sinhVien,ThuePhong thuePhong, int idp, int idphong)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                Phong phong = phongService.LayPhongTheoMa(idp);
                if (phong != null && phong.songuoio < phong.sogiuong)
                {
                    if (phong.loaiphong == sinhVien.gioitinh && sinhVien.ngaysinh.Day < sinhVien.ngayvao.Day ||
                        sinhVien.ngaysinh.Month < sinhVien.ngayvao.Month)
                    {
                        sinhVien.idphong = idp;
                        sinhVien.solanvipham = 0;
                        sinhVien.trang_thai = "Đã thuê";
                        sinhVienService.ThemSinhVien(sinhVien);
                        phongService.CapNhatSoNguoiO(phong, phong.songuoio + 1);
                        thuePhong.trangthai = "Đã thuê";
                        thuePhongService.ThuePhong(thuePhong, sinhVien.id, idp, idphong);
                        TempData["thuephongthanhcong"] = "Thuê phòng thành công!";
                        return RedirectToAction("Home", "Phong");
                    }
                    else
                    {
                        Console.WriteLine("Loai phong do la danh cho" + phong.loaiphong + "chu khong phai la " + sinhVien.gioitinh);
                    }
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            return RedirectToAction("SinhVienThuePhong", "SinhVien");
        }

        [HttpPost]
        public IActionResult TraPhong(string id)
        {
            SinhVien sinhvien = new SinhVien();
            TraPhong traphong = new TraPhong();
            Tuple<int, DateTime, string, int> sts = sinhVienService.LayThongTinPhongVaNgayThue(id);
            int idphong = sts.Item1;
            int idnguoidung3 = 1;
            sinhvien.trang_thai = "Đã trả";
            sinhVienService.UpdateTrangThaiStudent(sinhvien, id);
            Phong phongupdates = phongService.LayPhongTheoMa(idphong);
            phongService.CapNhatSoNguoiO(phongupdates, phongupdates.songuoio - 1);
            traPhongService.TraPhong(traphong, idphong, id, idnguoidung3);
            return RedirectToAction("PhongList","PhongController");
        }
    }
}
