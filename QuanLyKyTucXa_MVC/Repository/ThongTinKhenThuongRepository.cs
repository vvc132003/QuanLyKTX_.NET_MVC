using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    internal interface ThongTinKhenThuongRepository
    {
        List<ThongTinKhenThuong> GetAllKhenThuong();
        List<ThongTinKhenThuong> GetAllKhenThuongID(int id);
        void SuaKhenThuong(ThongTinKhenThuong thongTinKhenThuong);
        void ThemKhenThuong(ThongTinKhenThuong thongTinKhenThuong, string idsinhvien, int idnguoidung);
        void XoaKhenThuong(int id);
    }
}
