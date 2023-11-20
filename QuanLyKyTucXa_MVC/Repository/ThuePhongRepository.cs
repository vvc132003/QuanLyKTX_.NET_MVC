using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    public interface ThuePhongRepository
    {
        void ThuePhong(ThuePhong thuePhong);
        List<ThuePhong> GetAllTinThuePhong();
        int LayMaThuePhongTheoIDSV(string masv);
    }
}
