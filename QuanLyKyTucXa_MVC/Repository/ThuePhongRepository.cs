using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    internal interface ThuePhongRepository
    {
        void ThuePhong(ThuePhong thuePhong);
        List<ThuePhong> GetAllTinThuePhong();
        int LayMaThuePhongTheoIDSV(string masv);
    }
}
