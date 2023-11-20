using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa_MVC.Models
{
    public class ChuyenPhong
    {
        public int id { get; set; }
        public string idsinhvien { get; set; }
        public int idnguoidung { get; set; }
        public int idphongcu { get; set; }
        public int idphongmoi { get; set; }
        public string lydo { get; set; }
        public DateTime ngaychuyen { get; set; }


        public void HienThiThongTinChuyenPhong()
        {
            Console.WriteLine($"|{id,13}|{idsinhvien,8}|{idphongcu,3}|{idphongmoi,13}|{lydo,12}||{ngaychuyen,12}|");
        }

        public void HienThiTieuDeChuyenPhong()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("| Ma Chuyen Phong |  Ma SV  | ID_P Cu |  ID_P Moi  |    Ly Do    |  Ngay Chuyen  |");
            Console.WriteLine("--------------------------------------------------------");
        }

        public void NhapThongTinChuyenPhong()
        {
            Console.Write("Ly Do: ");
            lydo = Console.ReadLine();

            Console.Write("Ngay Chuyen (MM/dd/yyyy): ");
            ngaychuyen = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        }


    }
}
