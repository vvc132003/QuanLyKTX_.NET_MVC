using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa_MVC.Models
{
    internal class DichVu
    {
        public int id { get; set; }
        public string tendichvu { get; set; }
        public string mota { get; set; }
        public string trangthai { get; set; }
        public int soluongcon { get; set; }
        public DateTime ngaythem { get; set; }
        public float giatien { get; set; }
        public void HienThiThongTinDichVu()
        {
            Console.WriteLine($"|{id,13}|{tendichvu,8}|{mota,13}|{trangthai,13}|{soluongcon,12}|{ngaythem,12}|{giatien,12}|");
        }

        public void HienThiTieuDedichvu()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| ID |  TEN DICH VU  |           MO TA             |  TRANG THAI  | SO LUONG CON |       NGAY THEM       |       GIA TIEN        ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
        }

        public void NhapThongTinDichVu()
        {
            Console.Write("Nhap ten dich vu:");
            tendichvu = Console.ReadLine();
            Console.Write("Nhap mo ta:");
            mota = Console.ReadLine();
            Console.Write("Nhap so luong con: ");
            soluongcon = int.Parse(Console.ReadLine());
            Console.Write("Nhap gia tien:");
            giatien = float.Parse(Console.ReadLine());  
            Console.Write("Ngay them (MM/dd/yyyy): ");
            ngaythem = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
