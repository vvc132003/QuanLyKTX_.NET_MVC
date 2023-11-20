using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    public interface TraPhongRepository
    {
        void TraPhong(TraPhong traPhong, int idphong, string masv, int idnguoidung);
        List<TraPhong> GetAllTinTraPhong();
    }
}
