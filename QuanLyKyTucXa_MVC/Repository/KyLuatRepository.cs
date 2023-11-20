using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    public interface KyLuatRepository
    {
        void ThemKyLuat(KyLuat kyLuat, int idNguoiDung, string idSinhVien);
    }
}
