using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    public interface PhongRepository
    {
        List<Phong> GetAllPhong();
        void ThemPhong(Phong phong);
        void CapNhatPhong(Phong phong);
        void XoaPhong(int id);
        void CapNhatSoNguoiO(Phong phong, int songuoio);
        Phong LayPhongTheoMa(int id);
    }
}
