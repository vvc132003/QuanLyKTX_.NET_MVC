using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Repository;
using System.Data.SqlClient;
using System.Data;
using ketnoicsdllan1;

namespace QuanLyKyTucXa_MVC.Service
{
    public class SinhVienService : SinhVienRepository
    {
        private SqlConnection connection = DBUtils.GetDBConnection();
        public List<SinhVien> GetAllStudents()
        {
            List<SinhVien> students = new List<SinhVien>();
            connection.Open();
            using (SqlCommand command = new SqlCommand("GetAllStudents", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SinhVien student = new SinhVien()
                        {
                            id = reader["id"].ToString(),
                            tensinhvien = reader["tensinhvien"].ToString(),
                            khoahoc = reader["khoahoc"].ToString(),
                            nganhhoc = reader["nganhhoc"].ToString(),
                            email = reader["email"].ToString(),
                            sodienthoai = reader["sodienthoai"].ToString(),
                            idphong = (int)reader["idphong"],
                            gioitinh = reader["gioitinh"].ToString(),
                            tinh = reader["tinh"].ToString(),
                            quan = reader["tinh"].ToString(),
                            phuong = reader["tinh"].ToString(),
                            trang_thai = reader["trang_thai"].ToString(),
                            solanvipham = (int)reader["solanvipham"],
                            ngayvao = (DateTime)reader["ngayvao"],
                            ngaysinh = (DateTime)reader["ngaysinh"]
                        };
                        students.Add(student);
                    }
                }
            }
            connection.Close();
            return students;
        }

        public bool KiemTraTonTaiMaSinhVien(string masv)
        {
            bool tonTai = false;
            connection.Open();
            string query = "SELECT COUNT(*) FROM SinhVien WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", masv);
                int count = (int)command.ExecuteScalar();
                tonTai = (count > 0);
            }
            connection.Close();
            return tonTai;
        }

        public void ThemSinhVien(SinhVien sinhVien)
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("ThemSinhVienS", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", sinhVien.id);
                command.Parameters.AddWithValue("@tensinhvien", sinhVien.tensinhvien);
                command.Parameters.AddWithValue("@khoahoc", sinhVien.khoahoc);
                command.Parameters.AddWithValue("@nganhhoc", sinhVien.nganhhoc);
                command.Parameters.AddWithValue("@email", sinhVien.email);
                command.Parameters.AddWithValue("@sodienthoai", sinhVien.sodienthoai);
                command.Parameters.AddWithValue("@idphong", sinhVien.idphong);
                command.Parameters.AddWithValue("@gioitinh", sinhVien.gioitinh);
                command.Parameters.AddWithValue("@tinh", sinhVien.tinh);
                command.Parameters.AddWithValue("@quan", sinhVien.quan);
                command.Parameters.AddWithValue("@phuong", sinhVien.phuong);
                command.Parameters.AddWithValue("@trang_thai", sinhVien.trang_thai);
                command.Parameters.AddWithValue("@solanvipham", sinhVien.solanvipham);
                command.Parameters.AddWithValue("@ngayvao", sinhVien.ngayvao);
                command.Parameters.AddWithValue("@ngaysinh", sinhVien.ngaysinh);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }


        public void UpdateSinhVien(SinhVien sinhVien)
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("UpdateSinhViens", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tensinhvien", sinhVien.tensinhvien);
                command.Parameters.AddWithValue("@khoahoc", sinhVien.khoahoc);
                command.Parameters.AddWithValue("@nganhhoc", sinhVien.nganhhoc);
                command.Parameters.AddWithValue("@email", sinhVien.email);
                command.Parameters.AddWithValue("@sodienthoai", sinhVien.sodienthoai);
                command.Parameters.AddWithValue("@idphong", sinhVien.idphong);
                command.Parameters.AddWithValue("@gioitinh", sinhVien.gioitinh);
                command.Parameters.AddWithValue("@tinh", sinhVien.tinh);
                command.Parameters.AddWithValue("@quan", sinhVien.quan);
                command.Parameters.AddWithValue("@phuong", sinhVien.phuong);
                command.Parameters.AddWithValue("@ngayvao", sinhVien.ngayvao);
                command.Parameters.AddWithValue("@ngaysinh", sinhVien.ngaysinh);
                command.Parameters.AddWithValue("@id", sinhVien.id);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void UpdateTrangThaiStudent(SinhVien student)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateTrangThaiStudents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@trang_thai", student.trang_thai);
                    command.Parameters.AddWithValue("@id", student.id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public SinhVien SinhVienGteById(string id)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                string query = "SELECT id,idphong,ngayvao,gioitinh,solanvipham,tensinhvien FROM SinhVien WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SinhVien sinhVien = new SinhVien
                            {
                                id = reader["id"].ToString(),
                                idphong = (int)reader["idphong"],
                                ngayvao = (DateTime)reader["ngayvao"],
                                gioitinh = reader["gioitinh"].ToString(),
                                solanvipham = (int)reader["solanvipham"],
                                tensinhvien = reader["tensinhvien"].ToString(),
                            };
                            return sinhVien;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
       
        public void CapNhatPhongChoSinhVien(string id, int idphong)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                string updateQuery = "UPDATE SinhVien SET idphong = @idphong WHERE id = @id";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@idphong", idphong);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();

                }
            }
        }

        public void CapNhatSoLanViPhamChoSinhVien(string id, int solanvipham)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                string updateQuery = "UPDATE SinhVien SET solanvipham  = @solanvipham  WHERE id = @id";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@solanvipham ", solanvipham);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    


        public List<SinhVien> TimKiemSinhVienTheoTen(string tensinhvien)
        {
            connection.Open();
            List<SinhVien> sinhVienlist = new List<SinhVien>();
            string query = "SELECT * FROM SinhVien WHERE tensinhvien LIKE @tensinhvien AND trang_thai LIKE 'Ðã thuê'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@tensinhvien", "%" + tensinhvien + "%");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    SinhVien sinhvien = new SinhVien
                    {
                        id = reader["id"].ToString(),
                        tensinhvien = reader["tensinhvien"].ToString(),
                        khoahoc = reader["khoahoc"].ToString(),
                        nganhhoc = reader["nganhhoc"].ToString(),
                        email = reader["email"].ToString(),
                        sodienthoai = reader["sodienthoai"].ToString(),
                        idphong = (int)reader["idphong"],
                        gioitinh = reader["gioitinh"].ToString(),
                        tinh = reader["tinh"].ToString(),
                        quan = reader["quan"].ToString(),
                        phuong = reader["phuong"].ToString(),
                        trang_thai = reader["trang_thai"].ToString(),
                        solanvipham = (int)reader["solanvipham"],
                        ngayvao = (DateTime)reader["ngayvao"],
                        ngaysinh = (DateTime)reader["ngaysinh"]
                    };
                    sinhVienlist.Add(sinhvien);
                }
            }
            connection.Close();
            return sinhVienlist;
        }


        public List<SinhVien> SapXepSinhVienGiamDanTheoTen()
        {
            List<SinhVien> sinhviens = new List<SinhVien>();
            connection.Open();
            using (SqlCommand command = new SqlCommand("SapXepSinhVienGiamDanTheoTen", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SinhVien student = new SinhVien
                        {
                            id = reader["id"].ToString(),
                            tensinhvien = reader["tensinhvien"].ToString(),
                            khoahoc = reader["khoahoc"].ToString(),
                            nganhhoc = reader["nganhhoc"].ToString(),
                            email = reader["email"].ToString(),
                            sodienthoai = reader["sodienthoai"].ToString(),
                            idphong = (int)reader["idphong"],
                            gioitinh = reader["gioitinh"].ToString(),
                            tinh = reader["tinh"].ToString(),
                            quan = reader["quan"].ToString(),
                            phuong = reader["phuong"].ToString(),
                            trang_thai = reader["trang_thai"].ToString(),
                            solanvipham = (int)reader["solanvipham"],
                            ngayvao = (DateTime)reader["ngayvao"],
                            ngaysinh = (DateTime)reader["ngaysinh"]
                        };
                        sinhviens.Add(student);
                    }
                }
            }
            connection.Close();
            return sinhviens;
        }
        public List<SinhVien> SapXepSinhVienTangDanTheoTen()
        {
            List<SinhVien> sinhviens = new List<SinhVien>();
            connection.Open();
            using (SqlCommand command = new SqlCommand("SapXepSinhVienTangDanTheoTen", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SinhVien student = new SinhVien
                        {
                            id = reader["id"].ToString(),
                            tensinhvien = reader["tensinhvien"].ToString(),
                            khoahoc = reader["khoahoc"].ToString(),
                            nganhhoc = reader["nganhhoc"].ToString(),
                            email = reader["email"].ToString(),
                            sodienthoai = reader["sodienthoai"].ToString(),
                            idphong = (int)reader["idphong"],
                            gioitinh = reader["gioitinh"].ToString(),
                            tinh = reader["tinh"].ToString(),
                            quan = reader["quan"].ToString(),
                            phuong = reader["phuong"].ToString(),
                            trang_thai = reader["trang_thai"].ToString(),
                            solanvipham = (int)reader["solanvipham"],
                            ngayvao = (DateTime)reader["ngayvao"],
                            ngaysinh = (DateTime)reader["ngaysinh"]
                        };
                        sinhviens.Add(student);
                    }
                }
            }
            connection.Close();
            return sinhviens;
        }

        public List<SinhVien> SapXepSinhVienTangDanTheoMaPhong()
        {
            List<SinhVien> sinhviens = new List<SinhVien>();
            connection.Open();
            using (SqlCommand command = new SqlCommand("SapXepSinhVienTangDanTheoMaPhong", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SinhVien student = new SinhVien
                        {
                            id = reader["id"].ToString(),
                            tensinhvien = reader["tensinhvien"].ToString(),
                            khoahoc = reader["khoahoc"].ToString(),
                            nganhhoc = reader["nganhhoc"].ToString(),
                            email = reader["email"].ToString(),
                            sodienthoai = reader["sodienthoai"].ToString(),
                            idphong = (int)reader["idphong"],
                            gioitinh = reader["gioitinh"].ToString(),
                            tinh = reader["tinh"].ToString(),
                            quan = reader["quan"].ToString(),
                            phuong = reader["phuong"].ToString(),
                            trang_thai = reader["trang_thai"].ToString(),
                            solanvipham = (int)reader["solanvipham"],
                            ngayvao = (DateTime)reader["ngayvao"],
                            ngaysinh = (DateTime)reader["ngaysinh"]
                        };
                        sinhviens.Add(student);
                    }
                }
            }
            connection.Close();
            return sinhviens;
        }










        public List<SinhVien> GetAllStudentsIDPhong(int id)
        {
            List<SinhVien> students = new List<SinhVien>();
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM SinhVien WHERE trang_thai=N'Đã thuê' and  idphong = @idPhong";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idPhong", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SinhVien student = new SinhVien()
                            {
                                id = reader["id"].ToString(),
                                tensinhvien = reader["tensinhvien"].ToString(),
                                khoahoc = reader["khoahoc"].ToString(),
                                nganhhoc = reader["nganhhoc"].ToString(),
                                email = reader["email"].ToString(),
                                sodienthoai = reader["sodienthoai"].ToString(),
                                idphong = (int)reader["idphong"],
                                gioitinh = reader["gioitinh"].ToString(),
                                tinh = reader["tinh"].ToString(),
                                quan = reader["quan"].ToString(),
                                phuong = reader["phuong"].ToString(),
                                trang_thai = reader["trang_thai"].ToString(),
                                solanvipham = (int)reader["solanvipham"],
                                ngayvao = (DateTime)reader["ngayvao"],
                                ngaysinh = (DateTime)reader["ngaysinh"]
                            };
                            students.Add(student);
                        }
                    }
                }
            }
            return students;
        }


       
    }
}
