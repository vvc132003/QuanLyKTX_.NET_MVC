using Microsoft.AspNetCore.Mvc;
using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Repository;
using QuanLyKyTucXa_MVC.Service;
using System.Runtime.InteropServices;

namespace QuanLyKyTucXa_MVC.Controllers
{
    public class PhongController : Controller
    {
        private readonly PhongRepository phongService;

        public PhongController(PhongRepository phongServiceS)
        {
            phongService = phongServiceS;
        }
        [HttpGet]
        public IActionResult PhongList()
        {
            List<Phong> PhongList = phongService.GetAllPhong();
            return View(PhongList);
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
    }
}
