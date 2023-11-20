using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa_MVC.Models
{
    internal class ThueDichVu
    {
        public int id { get; set; }
        public int idnguoidung { get; set; }
        public int idthuephong { get; set; }
        public int iddichvu { get; set; }
        public int soluongthue { get; set; }
        public float thanhtien { get; set; }
        public string idsinhvien { get; set; }
        public string trangthai { get; set; }
        public DateTime ngaythue { get; set; }


        public void HienThiThongTinThueDichVu()
        {
            Console.WriteLine($"|{id,13}|{idnguoidung,8}|{idthuephong,3}|{iddichvu,13}|{soluongthue,12}|{thanhtien,12}||{idsinhvien,12}|{trangthai,12}|{ngaythue,12}");
        }

        public void HienThiTieuDeThueDichVu()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("| ID |  ID_ND  | ID_THUEP |  ID_DV  |   SL_THUE   |  THANHTIEN  |  ID_SV  |  TRANGTHAI  |  NGAYTHUE  |");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }

        public void NhapThongTinThueDichVu()
        {
            Console.Write("Nhap so luong thue: ");
            soluongthue = int.Parse(Console.ReadLine());
            Console.Write("Ngay thue (dd/MM/yyyy): ");
            ngaythue = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

    }
}
