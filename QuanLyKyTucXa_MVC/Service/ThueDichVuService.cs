using ketnoicsdllan1;
using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Repository;
using System.Data.SqlClient;

namespace QuanLyKyTucXa_MVC.Service
{
    public class ThueDichVuService : ThueDichVuRepository
    {
        public void ThemThueDichVu(ThueDichVu thueDichVu, int idNguoiDung, int idThuePhong, int idDichVu, double thanhTien, string idSinhVien)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                string query = "INSERT INTO ThueDichVu (idnguoidung, idthuephong, iddichvu, soluongthue, thanhtien, idsinhvien, trangthai, ngaythue) " +
                               "VALUES (@IdNguoiDung, @IdThuePhong, @IdDichVu, @SoLuongThue, @ThanhTien, @IdSinhVien, @TrangThai, @NgayThue)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdNguoiDung", idNguoiDung);
                    command.Parameters.AddWithValue("@IdThuePhong", idThuePhong);
                    command.Parameters.AddWithValue("@IdDichVu", idDichVu);
                    command.Parameters.AddWithValue("@SoLuongThue", thueDichVu.soluongthue);
                    command.Parameters.AddWithValue("@ThanhTien", thanhTien);
                    command.Parameters.AddWithValue("@IdSinhVien", idSinhVien);
                    command.Parameters.AddWithValue("@TrangThai", thueDichVu.trangthai);
                    command.Parameters.AddWithValue("@NgayThue", thueDichVu.ngaythue);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
