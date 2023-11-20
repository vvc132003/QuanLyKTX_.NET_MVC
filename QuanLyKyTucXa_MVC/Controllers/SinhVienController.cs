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

        public SinhVienController(SinhVienService sinhVienServices, TraPhongService traPhongServices, PhongService phongServices)
        {
            sinhVienService = sinhVienServices;
            traPhongService = traPhongServices;
            phongService = phongServices;
        }
        [HttpGet]
        public IActionResult SinhVienList()
        {
            return View();
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
            traPhongService.TraPhong(traphong, idphong, id, idnguoidung3);
            Phong phongupdates = phongService.LayPhongTheoMa(idphong);
            phongService.CapNhatSoNguoiO(phongupdates, phongupdates.songuoio - 1);
            return RedirectToAction("PhongList","PhongController");
        }
    }
}
