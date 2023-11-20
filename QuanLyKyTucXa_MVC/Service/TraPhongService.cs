using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Repository;
using System.Data.SqlClient;
using System.Data;
using ketnoicsdllan1;

namespace QuanLyKyTucXa_MVC.Service
{
    public class TraPhongService : TraPhongRepository
    {
        public List<TraPhong> GetAllTinTraPhong()
        {
            List<TraPhong> danhSachTraPhong = new List<TraPhong>();

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAllTinTraPhong", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TraPhong traPhong = new TraPhong
                            {
                                id = Convert.ToInt32(reader["id"]),
                                idsinhvien = reader["idsinhvien"].ToString(),
                                idphong = Convert.ToInt32(reader["idphong"]),
                                ngaytra = (DateTime)reader["ngaytra"],
                                lydo = reader["lydo"].ToString(),
                            };
                            danhSachTraPhong.Add(traPhong);
                        }
                    }
                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return danhSachTraPhong;
        }


        public void TraPhong(TraPhong traPhong, int idphong, string masv, int idnguoidung)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("TraPhongs", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsinhvien", masv);
                    command.Parameters.AddWithValue("@idnguoidung", idnguoidung);
                    command.Parameters.AddWithValue("@idphong", idphong);
                    command.Parameters.AddWithValue("@lydo", traPhong.lydo);
                    command.Parameters.AddWithValue("@ngaytra", traPhong.ngaytra);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
