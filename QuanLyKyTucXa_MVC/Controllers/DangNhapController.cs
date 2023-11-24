using Microsoft.AspNetCore.Mvc;
using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Service;

namespace QuanLyKyTucXa_MVC.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly NguoiDungService nguoiDungService;

        public DangNhapController(NguoiDungService nguoiDungServices)
        {
            nguoiDungService = nguoiDungServices;
        }
        [HttpGet]
        public IActionResult DangNhap()
        {
            NguoiDung nguoidung = new NguoiDung();
            Modeldata yourModel = new Modeldata
            {
                nguoiDung = nguoidung,
            };
            return View(yourModel);
        }

        [HttpPost]
        public IActionResult DangNhapVaoHeThong(string tendangnhap, string matkhau)
        {
            var luudangnhap = nguoiDungService.CheckThongTinDangNhap(matkhau, tendangnhap);
            if (luudangnhap != null)
            {
                HttpContext.Session.SetInt32("id", luudangnhap.id);
                HttpContext.Session.SetString("tendangnhap", luudangnhap.tendangnhap);
                HttpContext.Session.SetString("hoten", luudangnhap.hoten);
                return RedirectToAction("Home", "Phong");
            }
            else
            {
                Console.WriteLine("Ten dang nhap hoac mat khau bi sai!!!");
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }

    }
}