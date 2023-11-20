using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    internal interface ChuyenPhongRepository
    {
        void ChuyenPhong(ChuyenPhong chuyenPhong, int idphongcu, int idphongmoi);
    }
}
