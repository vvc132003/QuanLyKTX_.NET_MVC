using System;

namespace QuanLyKyTucXa_MVC.Models
{
    public class Phong
    {
        public int id { get; set; }
        public string loaiphong { get; set; }
        public int sogiuong { get; set; }
        public int songuoio { get; set; }
        public float giaphong { get; set; }

        public void NhapThongTinPhong()
        {
            Console.WriteLine("Nhập thông tin phòng:");
            Console.Write("Loại phòng: ");
            loaiphong = Console.ReadLine();

            Console.Write("Số giường: ");
            sogiuong = int.Parse(Console.ReadLine());

            
        }

        public void HienThiThongTinPhong()
        {
            Console.WriteLine($"|{id,-7}|{loaiphong,-15}|{sogiuong,-11}|{songuoio,-18}|{giaphong,-25}|");
        }
        
        public void HienThiTieuDePhong()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|   ID   |   Loại Phòng   |   Số Giường   |   Số Người Ở   |   Giá Phòng   |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        }

    }
}
