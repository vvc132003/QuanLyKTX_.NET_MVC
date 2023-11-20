using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    internal interface KyLuatRepository
    {
        void ThemKyLuat(KyLuat kyLuat, int idNguoiDung, string idSinhVien);
    }
}
