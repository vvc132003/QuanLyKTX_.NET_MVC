using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Repository;
using System.Data.SqlClient;
using System.Data;
using ketnoicsdllan1;

namespace QuanLyKyTucXa_MVC.Service
{
    public class ThuePhongService : ThuePhongRepository
    {
        public void ThuePhong(String masv, int idphong, int idnguoidung, DateTime ngaythue)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ThuePhongs", connection))
                {
                    ThuePhong thuePhong = new ThuePhong();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idnguoidung", thuePhong.idnguoidung);
                    command.Parameters.AddWithValue("@idphong", thuePhong.idphong);
                    command.Parameters.AddWithValue("@trangthai", thuePhong.trangthai);
                    command.Parameters.AddWithValue("@idsinhvien", thuePhong.idsinhvien);
                    command.Parameters.AddWithValue("@ngaythue", thuePhong.ngaythue);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ThuePhong> GetAllTinThuePhong()
        {
            List<ThuePhong> danhSachThuePhong = new List<ThuePhong>();

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAllThuePhong", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ThuePhong thuePhong = new ThuePhong
                            {
                                id = Convert.ToInt32(reader["id"]),
                                idsinhvien = reader["idsinhvien"].ToString(),
                                idphong = Convert.ToInt32(reader["idphong"]),
                                ngaythue = (DateTime)reader["ngaythue"],
                                trangthai = reader["trangthai"].ToString()
                            };
                            danhSachThuePhong.Add(thuePhong);
                        }
                    }
                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return danhSachThuePhong;
        }



        public int LayMaThuePhongTheoIDSV(string masv)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                List<ThuePhong> danhSachThuePhong = new List<ThuePhong>();

                connection.Open();

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "SELECT * FROM ThuePhong WHERE idsinhvien = @idsinhvien";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idsinhvien", masv);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (int)reader["id"];
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
        }
    }
}
