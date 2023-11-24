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
        private readonly ChuyenPhongService chuyenPhongService;

        public SinhVienController(SinhVienService sinhVienServices, TraPhongService traPhongServices, PhongService phongServices, ThuePhongService thuePhongServices, ChuyenPhongService chuyenPhongServices)
        {
            sinhVienService = sinhVienServices;
            traPhongService = traPhongServices;
            phongService = phongServices;
            thuePhongService = thuePhongServices;
            chuyenPhongService = chuyenPhongServices;
        }

        /// thuê phòng
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
        public IActionResult ThuePhong(SinhVien sinhVien,ThuePhong thuePhong, int idp, int idnguoidung)
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
                        thuePhongService.ThuePhong(thuePhong, sinhVien.id, idp, idnguoidung);
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

        /// chuyển phòng
        [HttpGet]
        public IActionResult SinhVienChuyenPhong(string id)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                SinhVien sinhvien = sinhVienService.SinhVienGteById(id);
                ChuyenPhong chuyenPhong = new ChuyenPhong();
                List<Phong> danhSachPhong = phongService.GetAllPhong();
                if (danhSachPhong != null && danhSachPhong.Count > 0)
                {
                    Modeldata yourModel = new Modeldata
                    {
                        sinhVien = sinhvien,
                        chuyenPhong = chuyenPhong,
                        phongs = danhSachPhong
                    };
                    int idnd = HttpContext.Session.GetInt32("id").Value;
                    string tendangnhap = HttpContext.Session.GetString("tendangnhap");
                    ViewData["id"] = idnd;
                    ViewData["tendangnhap"] = tendangnhap;
                    return View("SinhVienChuyenPhong", yourModel);
                }
                else
                {
                    return RedirectToAction("DangNhap", "DangNhap");
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }



        [HttpPost]
        public IActionResult ChuyenPhong(ChuyenPhong chuyenPhong , string masv, int idnguoidung, int idphongmoi)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                Phong phongmoi = phongService.LayPhongTheoMa(idphongmoi);
                SinhVien sinhvien = sinhVienService.LayThongTinPhongVaNgayThue(masv);
                if (phongmoi != null && phongmoi.songuoio < phongmoi.sogiuong)
                {
                    if (phongmoi.loaiphong == sinhvien.gioitinh)
                    {
                        if (sinhvien.idphong != 0 && (chuyenPhong.ngaychuyen.Month >= sinhvien.ngayvao.Month
                                               || (chuyenPhong.ngaychuyen.Month == sinhvien.ngayvao.Month
                                               && chuyenPhong.ngaychuyen.Day >= sinhvien.ngayvao.Day)))
                        {
                            Phong phongupdatecu = phongService.LayPhongTheoMa(sinhvien.idphong);
                            phongService.CapNhatSoNguoiO(phongmoi, phongmoi.songuoio + 1);
                            phongService.CapNhatSoNguoiO(phongupdatecu, phongupdatecu.songuoio - 1);
                            chuyenPhongService.ChuyenPhong(chuyenPhong, sinhvien.idphong, idphongmoi, masv, idnguoidung);
                            sinhVienService.CapNhatPhongChoSinhVien(masv, idphongmoi);
                            TempData["chuyenphongthanhcong"] = "Chuyển phòng thành công!";
                            return RedirectToAction("Home", "Phong");
                        }
                    }
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            return RedirectToAction("SinhVienChuyenPhong", "SinhVien");
        }


        /// trả phòng
        [HttpGet]
        public IActionResult SinhVienTraPhong(string id)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                SinhVien sinhvien = sinhVienService.SinhVienGteById(id);
                TraPhong traphong = new TraPhong();

                Modeldata yourModel = new Modeldata
                {
                    sinhVien = sinhvien,
                    traPhong = traphong
                };
                int idnd = HttpContext.Session.GetInt32("id").Value;
                string tendangnhap = HttpContext.Session.GetString("tendangnhap");
                ViewData["id"] = idnd;
                ViewData["tendangnhap"] = tendangnhap;
                return View("SinhVienTraPhong", yourModel);
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }


        [HttpPost]
        public IActionResult TraPhong(TraPhong traphong, string masv, int idnguoidung)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                SinhVien sinhvien = sinhVienService.LayThongTinPhongVaNgayThue(masv);
                sinhvien.id = masv;
                sinhvien.trang_thai = "Đã trả";
                sinhVienService.UpdateTrangThaiStudent(sinhvien);
                Phong phongupdates = phongService.LayPhongTheoMa(sinhvien.idphong);
                phongService.CapNhatSoNguoiO(phongupdates, phongupdates.songuoio - 1);
                traPhongService.TraPhong(traphong, sinhvien.idphong, masv, idnguoidung);
                TempData["traphongthanhcong"] = "Trả phòng thành công!";
                return RedirectToAction("Home", "Phong");
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }
    }
}
