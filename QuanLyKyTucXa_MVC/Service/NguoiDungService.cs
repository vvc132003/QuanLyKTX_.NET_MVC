using ketnoicsdllan1;
using QuanLyKyTucXa_MVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyKyTucXa_MVC.Service
{
    public class NguoiDungService
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public NguoiDung CheckThongTinDangNhap(string matkhau, string tendangnhap)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            using (SqlCommand command = new SqlCommand("CheckThongTinDangNhap", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                command.Parameters.AddWithValue("@matkhau", matkhau);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NguoiDung
                        {
                            tendangnhap = reader["tendangnhap"].ToString()
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public int LayIDNguoiDung(string tendangnhap)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            using (SqlCommand command = new SqlCommand("LayIDNguoiDung", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tendangnhap", tendangnhap);
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
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void CapNhatMatKhau(string tendangnhap, string matkhaumoi)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            using (SqlCommand command = new SqlCommand("CapNhatMatKhau", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@matkhau", matkhaumoi);
                command.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
