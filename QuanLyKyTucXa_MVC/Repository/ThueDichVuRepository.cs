using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    internal interface ThueDichVuRepository
    {
        void ThemThueDichVu(ThueDichVu thueDichVu, int idNguoiDung, int idThuePhong, int idDichVu, double thanhTien, string idSinhVien);
    }
}
