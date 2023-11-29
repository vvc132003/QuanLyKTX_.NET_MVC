using Microsoft.AspNetCore.Mvc;
using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Repository;
using QuanLyKyTucXa_MVC.Service;
using System.Runtime.InteropServices;

namespace QuanLyKyTucXa_MVC.Controllers
{
    public class PhongController : Controller
    {
        private readonly PhongService phongService;
        private readonly SinhVienService sinhVienService;

        public PhongController(PhongService phongServices, SinhVienService sinhVienServices)
        {
            phongService = phongServices;
            sinhVienService = sinhVienServices;
        }

        [HttpGet]
        public IActionResult Home()
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("hoten") != null)
            {
                int id = HttpContext.Session.GetInt32("id").Value;
                string hoten = HttpContext.Session.GetString("hoten");
                List<Phong> Home = phongService.GetAllPhong();
                ViewData["id"] = id;
                ViewData["hoten"] = hoten;
                return View(Home);
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }


        [HttpGet]
        public IActionResult PhongCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PhongCreate(Phong phong)
        {
            phongService.ThemPhong(phong);
            return RedirectToAction("PhongList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            phongService.XoaPhong(id);
            return RedirectToAction("PhongList");
        }


        [HttpGet]
        public IActionResult GetAllStudentsIDPhong(int id)
        {
            List<SinhVien> sinhviens = sinhVienService.GetAllStudentsIDPhong(id);
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

    }
}
