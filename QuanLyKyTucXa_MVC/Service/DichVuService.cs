using ketnoicsdllan1;
using QuanLyKyTucXa_MVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyKyTucXa_MVC.Service
{
    public class DichVuService
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public void ThemDichVu(DichVu dichVu)
        {
            connection.Open();
            string sql = "INSERT INTO DichVu (tendichvu , mota , giatien , soluongcon , trangthai,ngaythem)" +
                "   VALUES (@tendichvu , @mota , @giatien , @soluongcon , @trangthai,@ngaythem)";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@tendichvu", dichVu.tendichvu);
                command.Parameters.AddWithValue("@mota", dichVu.mota);
                command.Parameters.AddWithValue("@giatien", dichVu.giatien);
                command.Parameters.AddWithValue("@soluongcon", dichVu.soluongcon);
                command.Parameters.AddWithValue("@trangthai", dichVu.trangthai);
                command.Parameters.AddWithValue("@ngaythem", dichVu.ngaythem);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public List<DichVu> GetAllDichVu()
        {
            List<DichVu> dichVus = new List<DichVu>();
            connection.Open();
            string sql = "SELECT * FROM DichVu";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DichVu dichVu = new DichVu()
                        {
                            id = (int)reader["id"],
                            tendichvu = reader["tendichvu"].ToString(),
                            mota = reader["mota"].ToString(),
                            giatien = Convert.ToSingle(reader["giatien"]),
                            trangthai = reader["trangthai"].ToString(),
                            soluongcon = (int)reader["soluongcon"],
                            ngaythem = (DateTime)reader["ngaythem"],
                        };
                        dichVus.Add(dichVu);
                    }
                }
            }
            connection.Close();
            return dichVus;
        }

        public void SuaDichVu(DichVu dichVu)
        {
            connection.Open();
            string query = "UPDATE DichVu SET tendichvu = @tendichvu, mota = @mota, " +
                " soluongcon = @soluongcon, ngaythem = @ngaythem, giatien = @giatien WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tendichvu", dichVu.tendichvu);
                command.Parameters.AddWithValue("@mota", dichVu.mota);
                command.Parameters.AddWithValue("@soluongcon", dichVu.soluongcon);
                command.Parameters.AddWithValue("@ngaythem", dichVu.ngaythem);
                command.Parameters.AddWithValue("@giatien", dichVu.giatien);
                command.Parameters.AddWithValue("@id", dichVu.id);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public void XoaDichVu(int id)
        {
            connection.Open();
            string query = "DELETE FROM DichVu WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public DichVu LayDichVuTheoTen(string tendichvu)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string query = "SELECT * FROM DichVu WHERE tendichvu = @tendichvu";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tendichvu", tendichvu);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            return new DichVu
                            {
                                id = Convert.ToInt32(reader["id"]),
                                tendichvu = reader["tendichvu"].ToString(),
                                mota = reader["mota"].ToString(),
                                trangthai = reader["trangthai"].ToString(),
                                soluongcon = Convert.ToInt32(reader["soluongcon"]),
                                ngaythem = Convert.ToDateTime(reader["ngaythem"]),
                                giatien = Convert.ToSingle(reader["giatien"])
                            };
                        }
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }

        public void CapNhatSoLuongConChoDV(int iddv, int soluongcon)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = "UPDATE DichVu SET soluongcon = @soluongcon WHERE id = @id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@soluongcon", soluongcon);
                command.Parameters.AddWithValue("@id", iddv);
                command.ExecuteNonQuery();
            }
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
}
