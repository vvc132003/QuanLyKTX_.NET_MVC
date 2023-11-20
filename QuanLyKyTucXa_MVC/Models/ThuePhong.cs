using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa_MVC.Models
{
    internal class ThuePhong
    {
        public int id { get; set; }
        public int idnguoidung { get; set; }
        public int idphong { get; set; }
        public string trangthai { get; set; }
        public string idsinhvien { get; set; }
        public DateTime ngaythue { get; set; }

        public void HienThiThongTinThuePhong()
        {
            Console.WriteLine($"|{id,13}|{idsinhvien,8}|{idphong,3}|{ngaythue,13}|{trangthai,12}|");
        }

        public void HienThiTieuDeThuePhong()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("| Ma Thue Phong |  Ma SV  | ID_P |  Ngay Thue  | TRANG THAI |");
            Console.WriteLine("--------------------------------------------------------");
        }

        public void NhapThongTinThuePhong()
        {
            Console.Write("Mã phòng: ");
            int maPhong = int.Parse(Console.ReadLine());

            
        }

    }
}
