using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    internal interface TraPhongRepository
    {
        void TraPhong(TraPhong traPhong, int idphong);
        List<TraPhong> GetAllTinTraPhong();
    }
}
