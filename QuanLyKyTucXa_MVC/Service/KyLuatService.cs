using ketnoicsdllan1;
using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Repository;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKyTucXa_MVC.Service
{
    public class KyLuatService : KyLuatRepository
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public void ThemKyLuat(KyLuat kyLuat, string idSinhVien)
        {
            connection.Open();
            string query = "INSERT INTO KyLuat (loaivipham, mota, phuongphapxuphat, idnguoidung, idsinhvien, ngayvipham) " +
                              "VALUES (@loaivipham, @mota, @phuongphapxuphat, @idnguoidung, @idsinhvien, @ngayvipham)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@loaivipham", kyLuat.loaivipham);
                command.Parameters.AddWithValue("@mota", kyLuat.mota);
                command.Parameters.AddWithValue("@phuongphapxuphat", kyLuat.phuongphapxuphat);
                command.Parameters.AddWithValue("@idnguoidung", kyLuat.idnguoidung);
                command.Parameters.AddWithValue("@idsinhvien", idSinhVien);
                command.Parameters.AddWithValue("@ngayvipham", kyLuat.ngayvipham);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public List<KyLuat> GetAllKyLuat()
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                List<KyLuat> kyLuats = new List<KyLuat>();
                connection.Open();
                string sql = "select * from KyLuat ORDER BY id DESC";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KyLuat kyLuat = new KyLuat()
                            {
                                id = (int)reader["id"],
                                loaivipham = reader["loaivipham"].ToString(),
                                mota = reader["mota"].ToString(),
                                phuongphapxuphat = reader["phuongphapxuphat"].ToString(),
                                idsinhvien = reader["idsinhvien"].ToString(),
                                idnguoidung = (int)reader["idnguoidung"],
                                ngayvipham = (DateTime)reader["ngayvipham"],
                            };
                            kyLuats.Add(kyLuat);
                        }
                    }
                }
                return kyLuats;
            }
        }
        public void HuyKyLuat(int id)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                string query = "DELETE FROM KyLuat WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public KyLuat KyLuatGetID(int id)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                string query = "SELECT * FROM KyLuat WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            KyLuat kyLuat = new KyLuat()
                            {
                                id = (int)reader["id"],
                                loaivipham = reader["loaivipham"].ToString(),
                                phuongphapxuphat = reader["phuongphapxuphat"].ToString(),
                                mota = reader["mota"].ToString(),
                                idnguoidung = (int)reader["idnguoidung"],
                                idsinhvien = reader["idsinhvien"].ToString(),
                                ngayvipham = (DateTime)reader["ngayvipham"],
                            };
                            return kyLuat;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }


    }
}
