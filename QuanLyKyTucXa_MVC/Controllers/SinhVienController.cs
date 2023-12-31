﻿using DocumentFormat.OpenXml.Office2010.Excel;
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
        public IActionResult Home()
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                List<SinhVien> sinhviens = sinhVienService.GetAllStudents();
                List<Modeldata> modeldataList = new List<Modeldata>();
                foreach (var sinhVien in sinhviens)
                {
                    Modeldata modeldata = new Modeldata
                    {
                        sinhVien = sinhVien
                    };
                    modeldataList.Add(modeldata);
                }
                return View(modeldataList);
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
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
        public IActionResult ThuePhong(SinhVien sinhVien, ThuePhong thuePhong, int idp, int idnguoidung)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                Phong phong = phongService.LayPhongTheoMa(idp);
                if (phong != null && phong.songuoio < phong.sogiuong)
                {
                    if (phong.loaiphong == sinhVien.gioitinh)
                    {
                        if (sinhVien.ngaysinh.Day < sinhVien.ngayvao.Day ||
                        sinhVien.ngaysinh.Month < sinhVien.ngayvao.Month)
                        {
                            sinhVien.idphong = idp;
                            sinhVien.solanvipham = 0;
                            sinhVien.trang_thai = "Đã thuê";
                            sinhVienService.ThemSinhVien(sinhVien);
                            phongService.CapNhatSoNguoiO(phong, phong.songuoio + 1);
                            thuePhong.trangthai = "Đã thuê";
                            thuePhongService.ThuePhong(thuePhong, sinhVien.id, idp, idnguoidung);
                            sinhVienService.GuiEmail(sinhVien, thuePhong.ngaythue);
                            TempData["thuephongthanhcong"] = "Thuê phòng thành công!";
                            return RedirectToAction("Home", "Phong");
                        }
                        else
                        {
                            TempData["loigioitinh"] = "";
                            return RedirectToAction("SinhVienThuePhong", "SinhVien", new { id = idp });
                        }
                    }
                    else
                    {
                        TempData["loigioitinh"] = "";
                        return RedirectToAction("SinhVienThuePhong", "SinhVien", new { id = idp });
                    }
                }
                else
                {
                    TempData["loisonguoi"] = "";
                    return RedirectToAction("SinhVienThuePhong", "SinhVien", new { id = idp });
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
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
        public IActionResult ChuyenPhong(ChuyenPhong chuyenPhong, string id, int idnguoidung, int idphongmoi)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                Phong phongmoi = phongService.LayPhongTheoMa(idphongmoi);
                SinhVien sinhvien = sinhVienService.SinhVienGteById(id);
                if (phongmoi != null && phongmoi.songuoio < phongmoi.sogiuong)
                {
                    if (phongmoi.loaiphong == sinhvien.gioitinh)
                    {
                        if (sinhvien.idphong != 0 && (chuyenPhong.ngaychuyen >= sinhvien.ngayvao))
                        {
                            Phong phongupdatecu = phongService.LayPhongTheoMa(sinhvien.idphong);
                            phongService.CapNhatSoNguoiO(phongmoi, phongmoi.songuoio + 1);
                            phongService.CapNhatSoNguoiO(phongupdatecu, phongupdatecu.songuoio - 1);
                            chuyenPhongService.ChuyenPhong(chuyenPhong, sinhvien.idphong, idphongmoi, id, idnguoidung);
                            sinhVienService.CapNhatPhongChoSinhVien(id, idphongmoi);
                            TempData["chuyenphongthanhcong"] = "";
                            return RedirectToAction("Home", "Phong");
                        }
                        else
                        {
                            TempData["loichuyenphong"] = "";
                            return RedirectToAction("SinhVienChuyenPhong", "SinhVien", new { id });
                        }
                    }
                    else
                    {
                        TempData["loichuyenphonggt"] = "loichuyenphonggt";
                        return RedirectToAction("SinhVienChuyenPhong", "SinhVien", new { id });
                    }
                }
                else
                {
                    TempData["loisonguoi"] = "";
                    return RedirectToAction("SinhVienChuyenPhong", "SinhVien", new { id });
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
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
                SinhVien sinhvien = sinhVienService.SinhVienGteById(masv);
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