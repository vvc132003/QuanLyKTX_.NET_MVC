using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    internal interface DichVuRepository
    {
        void ThemDichVu(DichVu dichVu);
        List<DichVu> GetAllDichVu();
        void SuaDichVu(DichVu dichVu);
        void XoaDichVu(int id);
        DichVu LayDichVuTheoTen(string tendichvu);
        void CapNhatSoLuongConChoDV(int iddv, int soluongcon);
    }
}
