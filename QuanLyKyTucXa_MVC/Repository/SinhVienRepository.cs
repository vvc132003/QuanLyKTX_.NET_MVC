using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    public interface SinhVienRepository
    {
        List<SinhVien> GetAllStudents();
        List<SinhVien> GetAllStudentsIDPhong(int id);
        bool KiemTraTonTaiMaSinhVien(string masv);
        void ThemSinhVien(SinhVien sinhVien);
        void UpdateSinhVien(SinhVien sinhVien);
        void UpdateTrangThaiStudent(SinhVien student);
        void CapNhatPhongChoSinhVien(string id, int idphong);
        void CapNhatSoLanViPhamChoSinhVien(string id, int solanvipham);
        List<SinhVien> TimKiemSinhVienTheoTen(string tensinhvien);
        List<SinhVien> SapXepSinhVienGiamDanTheoTen();
        List<SinhVien> SapXepSinhVienTangDanTheoTen();
        List<SinhVien> SapXepSinhVienTangDanTheoMaPhong();
        SinhVien SinhVienGteById(string id);

    }
}
