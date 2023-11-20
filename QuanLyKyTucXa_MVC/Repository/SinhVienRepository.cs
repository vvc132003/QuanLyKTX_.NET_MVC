using QuanLyKyTucXa_MVC.Models;

namespace QuanLyKyTucXa_MVC.Repository
{
    internal interface SinhVienRepository
    {
        List<SinhVien> GetAllStudents();
        bool KiemTraTonTaiMaSinhVien(string masv);
        void ThemSinhVien(SinhVien sinhVien);
        void UpdateSinhVien(SinhVien sinhVien);
        void UpdateTrangThaiStudent(SinhVien student, string masv);
        Tuple<int, DateTime, string, int> LayThongTinPhongVaNgayThue(string idsv);
        void CapNhatPhongChoSinhVien(string id, int idphong);
        void CapNhatSoLanViPhamChoSinhVien(string id, int solanvipham);
        List<SinhVien> TimKiemSinhVienTheoTen(string tensinhvien);
        List<SinhVien> SapXepSinhVienGiamDanTheoTen();
        List<SinhVien> SapXepSinhVienTangDanTheoTen();
        List<SinhVien> SapXepSinhVienTangDanTheoMaPhong();
    }
}
