using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa_MVC.Models
{
    internal class NguoiDung
    {
        public int id { get; set; }
        public string hoten { get; set; }
        public string sodienthoai { get; set; }
        public string diachi { get; set; }
        public string chucvu { get; set; }
        public string matkhau { get; set; }
        public string tendangnhap { get; set; }
    

    public void NhapThongTinDangNhap()
    {
        Console.WriteLine("Nhap thong tin dang nhap:");
        Console.Write("Ten dang nhap: ");
        tendangnhap = Console.ReadLine();
        Console.Write("Mat khau: ");
        matkhau = Console.ReadLine();
        
    }

    public void HienThiThongTinNguoiDung()
    {
        Console.WriteLine($"|{id,-7}|{hoten,-15}|{sodienthoai,-11}|{diachi,-18}|{chucvu,-25}|");
    }

    public void HienThiTieuDeNguoiDung()
    {
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|   ID   |   Ho Ten   |   So Dien Thoai   |   Dia chi   |   Chuc Vu   |");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    }
    }
}
