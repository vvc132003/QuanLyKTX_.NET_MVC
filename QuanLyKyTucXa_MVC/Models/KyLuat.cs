using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa_MVC.Models
{
    internal class KyLuat
    {
        public int id { get; set; }
        public string loaivipham { get; set; }
        public string mota { get; set; }
        public string phuongphapxuphat { get; set; }
        public int idnguoidung { get; set; }
        public string idsinhvien { get; set; }
        public DateTime ngayvipham { get; set; }

        public void HienThiThongTinKyLuat()
        {
            Console.WriteLine($"|{id,13}|{loaivipham,15}|{mota,30}|{phuongphapxuphat,20}|{idnguoidung,10}|{idsinhvien,15}|{ngayvipham.ToString("MM/dd/yyyy"),15}|");
        }

        public void HienThiTieuDeKyLuat()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Ma Ky Luat |   Loai Vi Pham   |            Mo Ta            |  Phuong Phap Xu Phat | ID Nguoi Dung | ID Sinh Vien | Ngay Vi Pham |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
        }

        public void NhapThongTinKyLuat()
        {
            
            Console.Write("Mo Ta: ");
            mota = Console.ReadLine();

            Console.Write("Phuong Phap Xu Phat: ");
            phuongphapxuphat = Console.ReadLine();

            Console.Write("Ngay Vi Pham (MM/dd/yyyy): ");
            ngayvipham = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}

