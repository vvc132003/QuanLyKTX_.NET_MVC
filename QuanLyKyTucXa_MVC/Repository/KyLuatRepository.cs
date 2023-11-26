using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    public interface KyLuatRepository
    {
        List<KyLuat> GetAllKyLuat();
        void ThemKyLuat(KyLuat kyLuat, string idSinhVien);
        void HuyKyLuat(int id);
    }
}
