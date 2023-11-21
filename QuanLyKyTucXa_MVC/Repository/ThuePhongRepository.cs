using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    public interface ThuePhongRepository
    {
        void ThuePhong(ThuePhong thuePhong, String masv, int idphong, int idnguoidung);
        List<ThuePhong> GetAllTinThuePhong();
        int LayMaThuePhongTheoIDSV(string masv);
    }
}
