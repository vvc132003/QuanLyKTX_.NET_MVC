using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa_MVC.Models
{
    public class TraPhong
    {
        public int id { get; set; }
        public string idsinhvien { get; set; }
        public int idnguoidung { get; set; }
        public int idphong { get; set; }
        public string lydo { get; set; }
        public DateTime ngaytra { get; set; }

        public void HienThiThongTinTraPhong()
        {
            Console.WriteLine($"|{id,13}|{idsinhvien,8}|{idphong,3}|{lydo,12}||{ngaytra,12}|");
        }

        public void HienThiTieuDeTraPhongg()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("| Ma Tra Phong |  Ma SV  | ID_P |  Ly Do  | Ngay Tra |");
            Console.WriteLine("--------------------------------------------------------");
        }

        public void NhapThongTinTraPhong()
        {

            Console.Write("Nhap ly do muon tra: ");
            lydo = Console.ReadLine();

            Console.Write("Ngay tra (MM/dd/yyyy): ");
            ngaytra = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        }
    }
}
