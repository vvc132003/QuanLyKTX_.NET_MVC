using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    public interface ThuePhongRepository
    {
        void ThuePhong( String masv, int idphong, int idnguoidung, DateTime ngaythue);
        List<ThuePhong> GetAllTinThuePhong();
        int LayMaThuePhongTheoIDSV(string masv);
    }
}
