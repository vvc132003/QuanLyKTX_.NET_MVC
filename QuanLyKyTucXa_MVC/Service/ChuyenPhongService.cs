using ketnoicsdllan1;
using  QuanLyKyTucXa_MVC.Models;
using System.Data.SqlClient;
using System.Data;
using QuanLyKyTucXa_MVC.Repository;

namespace QuanLyKyTucXa_MVC.Service
{
    public class ChuyenPhongService : ChuyenPhongRepository
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public void ChuyenPhong(ChuyenPhong chuyenPhong, int idphongcu, int idphongmoi, string masv, int idnguoidung)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ChuyenPhongs", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsinhvien", masv);
                    command.Parameters.AddWithValue("@idnguoidung", idnguoidung);
                    command.Parameters.AddWithValue("@idphongcu", idphongcu);
                    command.Parameters.AddWithValue("@idphongmoi", idphongmoi);
                    command.Parameters.AddWithValue("@lydo", chuyenPhong.lydo);
                    command.Parameters.AddWithValue("@ngaychuyen", chuyenPhong.ngaychuyen);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
