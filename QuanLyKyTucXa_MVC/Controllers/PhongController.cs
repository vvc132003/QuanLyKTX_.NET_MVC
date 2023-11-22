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
            List<Phong> Home = phongService.GetAllPhong();
            return View(Home);
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
            return View(sinhviens);
        }
    }
}
