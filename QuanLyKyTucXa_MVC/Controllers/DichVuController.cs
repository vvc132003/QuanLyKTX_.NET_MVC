using Microsoft.AspNetCore.Mvc;
using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Service;

namespace QuanLyKyTucXa_MVC.Controllers
{
    public class DichVuController : Controller
    {
        private readonly DichVuService dichVuService;
        private readonly BoPhanService boPhanService;

        public DichVuController(DichVuService dichVuServices, BoPhanService boPhanServiceS)
        {
            dichVuService = dichVuServices;
            boPhanService = boPhanServiceS;
        }
        public IActionResult Home()
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                List<DichVu> dichVus = dichVuService.GetAllDichVu();
                List<Modeldata> modeldataList = new List<Modeldata>();
                foreach (var dichVu in dichVus)
                {
                    Modeldata modeldata = new Modeldata
                    {
                        dichVu = dichVu
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
        public IActionResult bophan()
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                List<BoPhan> boPhans = boPhanService.GetAllBoPhan();
                List<Modeldata> modeldataList = new List<Modeldata>();
                foreach (var boPhan in boPhans)
                {
                    List<NhanVien> nhanViens = boPhanService.GetallNhanVientheoid(boPhan.id); 
                    Modeldata modeldata = new Modeldata
                    {
                        boPhans = boPhan,
                        nhanViens = nhanViens,
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

        // chức năng them dich vụ
        public IActionResult ThemDichVu(DichVu dichVu)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                dichVu.trangthai = "Còn sử dụng";
                dichVuService.ThemDichVu(dichVu);
                TempData["themdichvuthanhcong"] = "";
                return RedirectToAction("Home", "DichVu");
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }
        public IActionResult XoaDichVu(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tendangnhap") != null)
            {
                DichVu dichVu = new DichVu();
                dichVu.trangthai = "Hết sử dụng";
                dichVuService.XoaDichVu(dichVu, id);
                TempData["Xoadichvuthanhcong"] = "";
                return RedirectToAction("Home", "DichVu");
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }
    }
}
