using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    public interface DichVuRepository
    {
        void ThemDichVu(DichVu dichVu);
        List<DichVu> GetAllDichVu();
        void SuaDichVu(DichVu dichVu);
        void XoaDichVu(DichVu dichVu,int id);
        DichVu LayDichVuTheoTen(string tendichvu);
        void CapNhatSoLuongConChoDV(int iddv, int soluongcon);
    }
}
