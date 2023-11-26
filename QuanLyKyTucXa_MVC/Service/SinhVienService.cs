using QuanLyKyTucXa_MVC.Models;
using QuanLyKyTucXa_MVC.Repository;
using System.Data.SqlClient;
using System.Data;
using ketnoicsdllan1;
using System.Net.Mail;
using System.Net;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

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



        public void Xuatexcel()
        {
            List<SinhVien> sinhviens = GetAllStudents();
            string filePath = "C:\\Users\\vvc13\\OneDrive\\Documents\\sinhvien.xlsx";

            IWorkbook workbook = new XSSFWorkbook();
            ISheet worksheet = workbook.CreateSheet("DanhSachSinhVien");

            IRow headerRow = worksheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Id");
            headerRow.CreateCell(1).SetCellValue("Tên sinh viên");
            headerRow.CreateCell(2).SetCellValue("Khóa học");
            headerRow.CreateCell(3).SetCellValue("Ngành học");
            headerRow.CreateCell(4).SetCellValue("Email");
            headerRow.CreateCell(5).SetCellValue("Số điện thoại");
            headerRow.CreateCell(6).SetCellValue("Id phòng");
            headerRow.CreateCell(7).SetCellValue("Giới tính");
            headerRow.CreateCell(8).SetCellValue("Tỉnh");
            headerRow.CreateCell(8).SetCellValue("Quận");
            headerRow.CreateCell(8).SetCellValue("Phường");
            headerRow.CreateCell(9).SetCellValue("Trạng thái");
            headerRow.CreateCell(10).SetCellValue("Số lần vi phạm");
            headerRow.CreateCell(11).SetCellValue("Ngày vào");
            headerRow.CreateCell(12).SetCellValue("Ngày sinh");


            int rowIndex = 1;
            foreach (var sinhvien in sinhviens)
            {
                IRow dataRow = worksheet.CreateRow(rowIndex);
                dataRow.CreateCell(0).SetCellValue(sinhvien.id);
                dataRow.CreateCell(1).SetCellValue(sinhvien.tensinhvien);
                dataRow.CreateCell(2).SetCellValue(sinhvien.khoahoc);
                dataRow.CreateCell(3).SetCellValue(sinhvien.nganhhoc);
                dataRow.CreateCell(4).SetCellValue(sinhvien.email);
                dataRow.CreateCell(5).SetCellValue(sinhvien.sodienthoai);
                dataRow.CreateCell(6).SetCellValue(sinhvien.idphong); 
                dataRow.CreateCell(7).SetCellValue(sinhvien.gioitinh);
                dataRow.CreateCell(8).SetCellValue(sinhvien.tinh);
                dataRow.CreateCell(8).SetCellValue(sinhvien.quan);
                dataRow.CreateCell(8).SetCellValue(sinhvien.phuong);
                dataRow.CreateCell(9).SetCellValue(sinhvien.trang_thai);
                dataRow.CreateCell(10).SetCellValue(sinhvien.solanvipham); 
                dataRow.CreateCell(11).SetCellValue(sinhvien.ngayvao.ToString("yyyy-MM-dd")); 
                dataRow.CreateCell(12).SetCellValue(sinhvien.ngaysinh.ToString("yyyy-MM-dd")); 
                rowIndex++;
            }

            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(file);
            }
        }



        public void GuiEmail(SinhVien sinhvien, DateTime ngaythue)
        {
            try
            {
                string fromEmail = "vvc132003@gmail.com";
                string password = "qyqgwwjbbajzrrex";
                string toEmail = sinhvien.email;
                MailMessage message = new MailMessage(fromEmail, toEmail);
                message.Subject = "Ban da thue phong thanh cong";
                StringBuilder bodyBuilder = new StringBuilder();
                bodyBuilder.AppendLine($"Mã sinh viên: {sinhvien.id}");
                bodyBuilder.AppendLine($"Tên sinh viên: {sinhvien.tensinhvien}");
                bodyBuilder.AppendLine($"Số phòng: {sinhvien.idphong}");
                bodyBuilder.AppendLine($"Ngày vào: {sinhvien.ngayvao}");
                bodyBuilder.AppendLine($"Ngày thuê: {ngaythue}");
                message.Body = bodyBuilder.ToString();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromEmail, password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
        }

    }
}
