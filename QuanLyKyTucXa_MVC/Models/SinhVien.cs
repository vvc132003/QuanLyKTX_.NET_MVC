using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa_MVC.Models
{
    internal class SinhVien
    {
        public string id { get; set; }
        public string tensinhvien { get; set; }
        public string khoahoc { get; set; }
        public string nganhhoc { get; set; }
        public string email { get; set; }
        public string sodienthoai { get; set; }
        public int idphong { get; set; }
        public string gioitinh { get; set; }
        public string quequan { get; set; }
        public string trang_thai { get; set; }
        public int solanvipham { get; set; }
        public DateTime ngayvao { get; set; }
        public DateTime ngaysinh { get; set; }

        public void NhapThongTinSinhVien()
        {
            SinhVien sinhVien = new SinhVien();

            Console.WriteLine("Nhập thông tin sinh viên:");


            Console.Write("Mã sinh viên: ");
            id = Console.ReadLine();

            Console.Write("Tên sinh viên: ");
            tensinhvien = Console.ReadLine();

            Console.Write("Khoa học: ");
            khoahoc = Console.ReadLine();

            Console.Write("Ngành học: ");
            nganhhoc = Console.ReadLine();

            Console.Write("Email: ");
            email = Console.ReadLine();

            Console.Write("Số điện thoại: ");
            sodienthoai = Console.ReadLine();

            Console.Write("Giới tính: ");
            gioitinh = Console.ReadLine();

            Console.Write("Quê quán: ");
            quequan = Console.ReadLine();

            Console.Write("Ngày sinh (MM/dd/yyyy): ");
            ngaysinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);


            Console.Write("Ngay vao (MM/dd/yyyy): ");
            ngayvao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public void HienThiThongTinSinhVien()
        {
            Console.WriteLine($"|{id,-8}|{tensinhvien,-15}|{khoahoc,-11}|{nganhhoc,-20}|{email,-25}|{sodienthoai,-17}|{idphong,-11}|{gioitinh,-13}|{quequan,-16}|{trang_thai,-19}|{solanvipham,-21}|{ngayvao:d,-19}|{ngaysinh:d,-17}|");
        }
        public void HienThiTieuDeSinhVien()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|    ID    |       Ten       |  Khoa Hoc  |     Nganh Hoc     |          Email          |   So Đien Thoai   |  ID Phong  |  Gioi Tinh  |    Que Quan    |     Trang Thai     |   So Lan Vi Pham   |   Ngay Nhap Hoc   |    Ngay Sinh    |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }
}
