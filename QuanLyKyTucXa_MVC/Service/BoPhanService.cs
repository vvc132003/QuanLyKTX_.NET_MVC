using DocumentFormat.OpenXml.Office2010.Excel;
using ketnoicsdllan1;
using QuanLyKyTucXa_MVC.Models;
using System.Data.SqlClient;

namespace QuanLyKyTucXa_MVC.Service
{
    public class BoPhanService
    {
        public List<BoPhan> GetAllBoPhan()
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                List<BoPhan> boPhans = new List<BoPhan>();
                connection.Open();
                string sql = "SELECT * FROM BoPhan";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BoPhan boPhan = new BoPhan()
                            {
                                id = (int)reader["id"],
                                tenbophan = reader["tenbophan"].ToString(),
                                mota = reader["mota"].ToString(),
                                image = reader["image"].ToString()
                            };
                            boPhans.Add(boPhan);
                        }
                    }
                }
                return boPhans;
            }
        }
        public List<NhanVien> GetallNhanVientheoid(int idbophan)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                List<NhanVien> nhanViens = new List<NhanVien>();
                connection.Open();
                string sql = "SELECT * FROM NhanVien where idbophan = @idbophan";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idbophan", idbophan);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NhanVien nhanVien = new NhanVien()
                            {
                                id = (int)reader["id"],
                                hovaten = reader["hovaten"].ToString(),
                                sodienthoai = reader["sodienthoai"].ToString(),
                                image = reader["image"].ToString(),
                            };
                            nhanViens.Add(nhanVien);
                        }
                    }
                }
                return nhanViens;
            }
        }
    }
}
