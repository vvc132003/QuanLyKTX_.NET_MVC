using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    public interface NguoiDungRepository
    {
        NguoiDung CheckThongTinDangNhap(string matkhau, string tendangnhap);
        int LayIDNguoiDung(string tendangnhap);
        void CapNhatMatKhau(string tendangnhap, string matkhaumoi);
    }
}
