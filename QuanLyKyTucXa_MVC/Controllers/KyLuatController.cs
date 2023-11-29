using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Service;

namespace QuanLyKyTucXa_MVC.Controllers
{
    public class KyLuatController : Controller
    {
        private readonly KyLuatService kyLuatService;
        private readonly SinhVienService sinhVienService;
        public KyLuatController(SinhVienService sinhVienServices, KyLuatService kyLuatServices)
        {
            sinhVienService = sinhVienServices;
            kyLuatService = kyLuatServices;
        }

        /// trang chủ kỷ luật
        public IActionResult Home()
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                int idnd = HttpContext.Session.GetInt32("id").Value;
                string tendangnhap = HttpContext.Session.GetString("tendangnhap");
                ViewData["id"] = idnd;
                ViewData["tendangnhap"] = tendangnhap;
                List<KyLuat> kyLuats = kyLuatService.GetAllKyLuat();
                List<Modeldata> modeldataList = new List<Modeldata>();
                foreach (var kyLuat in kyLuats)
                {
                    Modeldata modeldata = new Modeldata
                    {
                        kyLuat = kyLuat
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
        // chức năng kyer luật
        public IActionResult KyLuat(KyLuat kyLuat, string masv)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                if (sinhVienService.KiemTraTonTaiMaSinhVien(masv))
                {
                    SinhVien sinhvien = sinhVienService.SinhVienGteById(masv);
                    if (sinhvien != null)
                    {
                        kyLuatService.ThemKyLuat(kyLuat, masv);
                        sinhVienService.CapNhatSoLanViPhamChoSinhVien(masv, sinhvien.solanvipham + 1);
                    }
                    TempData["kyluatthanhcong"] = "";
                    return RedirectToAction("Home", "KyLuat");
                }
                else
                {
                    return RedirectToAction("Home", "KyLuat");
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }
        // chức năng huỷ kỷ luật
        public IActionResult HuyKyLuat(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                KyLuat kyLuat = kyLuatService.KyLuatGetID(id);
                if (kyLuat != null)
                {
                    SinhVien sinhvien = sinhVienService.SinhVienGteById(kyLuat.idsinhvien);
                    if (sinhvien != null)
                    {
                        if (sinhvien.solanvipham > 0)
                        {
                            sinhVienService.CapNhatSoLanViPhamChoSinhVien(kyLuat.idsinhvien, sinhvien.solanvipham - 1);
                        }
                    }
                    kyLuatService.HuyKyLuat(id);
                }
                return RedirectToAction("Home", "KyLuat");
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }

    }
}