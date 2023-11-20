using ketnoicsdllan1;
using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Repository;
using System.Data.SqlClient;

namespace QuanLyKyTucXa_MVC.Service
{
    public class ThongTinKhenThuongService : ThongTinKhenThuongRepository
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public List<ThongTinKhenThuong> GetAllKhenThuong()
        {
            List<ThongTinKhenThuong> khenThuongList = new List<ThongTinKhenThuong>();
            string selectQuery = "SELECT * FROM ThongTinKhenThuong";
            connection.Open();
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ThongTinKhenThuong khenThuong = new ThongTinKhenThuong
                        {
                            id = Convert.ToInt32(reader["id"]),
                            idsinhvien = reader["idsinhvien"].ToString(),
                            idnguoidung = Convert.ToInt32(reader["idnguoidung"]),
                            lydo = reader["lydo"].ToString(),
                            ngaykhen = Convert.ToDateTime(reader["ngaykhen"])
                        };

                        khenThuongList.Add(khenThuong);
                    }
                }
            }
            connection.Close();
            return khenThuongList;
        }

        public List<ThongTinKhenThuong> GetAllKhenThuongID(int id)
        {
            List<ThongTinKhenThuong> khenThuongList = new List<ThongTinKhenThuong>();
            string selectQuery = "SELECT * FROM ThongTinKhenThuong WHERE id = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ThongTinKhenThuong khenThuong = new ThongTinKhenThuong
                        {
                            id = Convert.ToInt32(reader["id"]),
                            idsinhvien = reader["idsinhvien"].ToString(),
                            idnguoidung = Convert.ToInt32(reader["idnguoidung"]),
                            lydo = reader["lydo"].ToString(),
                            ngaykhen = Convert.ToDateTime(reader["ngaykhen"])
                        };
                        khenThuongList.Add(khenThuong);
                    }
                }
            }
            connection.Close();
            return khenThuongList;
        }

        public void SuaKhenThuong(ThongTinKhenThuong thongTinKhenThuong)
        {
            string updateQuery = "UPDATE ThongTinKhenThuong SET lydo = @LyDo WHERE id = @Id";
            connection.Open();
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@LyDo", "Lý do cập nhật");
                command.Parameters.AddWithValue("@Id", 1);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void ThemKhenThuong(ThongTinKhenThuong thongTinKhenThuong, string idsinhvien, int idnguoidung)
        {
            string insertQuery = "INSERT INTO ThongTinKhenThuong (idsinhvien, idnguoidung, lydo, ngaykhen) " +
                     "VALUES (@IdSinhVien, @IdNguoiDung, @LyDo, @NgayKhen)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@IdSinhVien", idsinhvien);
                command.Parameters.AddWithValue("@IdNguoiDung", idnguoidung);
                command.Parameters.AddWithValue("@LyDo", thongTinKhenThuong.lydo);
                command.Parameters.AddWithValue("@NgayKhen", thongTinKhenThuong.ngaykhen);

                command.ExecuteNonQuery();
            }
            connection.Close();

        }

        public void XoaKhenThuong(int id)
        {
            string deleteQuery = "DELETE FROM ThongTinKhenThuong WHERE id = @Id";
            connection.Open();

            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    
    }
}
