using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace BTTH6
    /* bai1- BTH6:  Viết chương trình quản lí nhân sự và tính lương cho nhân viên trong công ty.
+ Quản lí thông tin nhân viên (Họ tên, ngày sinh, địa chỉ)
+ Tính lương cho nhân viên. Biết trong công ty có ba loại nhân viên và cách tính
lương như sau:
 Nhân viên sản xuất: số sản phẩm*20 000 đ
 Nhân viên công nhật: số ngày công*50 000 đ
 Nhân viên quản lí : hệ số lương * lương cơ bản. 
*/
{
    abstract class Nhanvien
    {
        protected string hoten, diachi;
        protected DateTime ngaysinh;
        public Nhanvien()
        {
            hoten = diachi = "";

            ngaysinh = DateTime.Now;
        }
        public Nhanvien(string hoten, string diachi, DateTime ngaysinh)
        {
            this.hoten = hoten;
            this.diachi = diachi;
            this.ngaysinh = ngaysinh;

        }
        public virtual void nhap()
        {
            Console.WriteLine("xin mời nhập họ tên");
            hoten = Console.ReadLine();
            Console.WriteLine("xin mời nhập địa chỉ");
            diachi = Console.ReadLine();
            Console.WriteLine(" xin mời nhập ngày sinh");
            ngaysinh = DateTime.Parse(Console.ReadLine());

        }
        public virtual void Hien()
        {
            Console.WriteLine("{0}\t1}\t{2}", hoten, diachi, ngaysinh);

        }
        public abstract double Tinhluong();
    }

}
public class NVSX : Nhanvien
{
    private int ssp;
    public NVSX() : base()
    { ssp = 0; }
    public NVSX(string hoten, string diachi, DateTime ngaysinh, int spp) :
        base(hoten, diachi, ngaysinh)
    { this.ssp = ssp; }
    public override void nhap()
    {
        Console.WriteLine("nhap thong tin cho nhan vien san xuat");
        base.nhap();
        Console.WriteLine("nhap so san pham:");
        ssp = int.Parse(Console.ReadLine());
        base.Hien();
        Console.WriteLine("so san pham" + ssp);
        Console.WriteLine("luong:" + Tinhluong());
    }
    public override double Tinhluong()
    {
        return ssp * 20;
    }
}
public class NVCN : Nhanvien
{
    private int snc;
    public NVCN() : base()
    {
        snc = 0;
    }
    public NVCN(string hoten, string diachi, DateTime ngaysinh, int snc) :
        base(hoten, diachi, ngaysinh)
    { this.snc = snc; }
    public override void nhap()
    {
        Console.WriteLine("nhap thong tin cho nhan cong cong nhat:");

        base.nhap();
        Console.WriteLine("nhap so ngay cong:");
        snc = int.Parse(Console.ReadLine());
    }
    public override void Hien()
    {
        Console.WriteLine("thong tin luong cua nhan cong nhat:");
        base.Hien();
        Console.WriteLine(" so nagy cong" + snc);
        Console.WriteLine("luong" + Tinhluong());
    }
    public override double Tinhluong()
    {
        return snc * 50;
    }
}
public class NVQL:Nhanvien
{
    private double hsl;
    private static int luongcoban = 1050;
    public NVQL(): base()
    {
        hsl = 2.34;
    }
    public NVQL(string hoten, string diachi, DateTime ngaysinh, int hsl);
    :base.nhap(hoten, diachi, ngaysinh)
    {
        this.hsl = hsl;
    }
    public static int Luongcoban()
    {
        get { return luongcoban; }
        set
        {
            if (value > 1050) luongcoban = value;
        }
    }

    public override void nhap()
    {
        Console.WriteLine("Nhap thong tin cho nhan vien quan ly");
        base.nhap();
        Console.Write("Nhap he so luong:");
        hsl = double.Parse(Console.ReadLine());
    }
    public override void Hien()
    {
        Console.WriteLine("Thong tin luong cua nhan vien quan ly");
        base.Hien();
        Console.WriteLine("He so luong" + hsl);
        Console.WriteLine("Luong:" + Tinhluong());
    }
    public override double Tinhluong()
    {
        return hsl * luongcoban;
    }
}
class QuanLy
{
    private Nhanvien[] ds;
    private int snv;
    public void Nhap()
    {
        Console.Write("Nhap so nhan vien:");
        snv = int.Parse(Console.ReadLine());
        ds = new Nhanvien[snv];
        for (int i = 0; i < snv; ++i)
        {
            Console.Write("Ban muon nhap thong tin cho nhan vien quan ly(Q), cong nhat(C), san xuat(S)");
            char ch = char.Parse(Console.ReadLine());
            switch (char.ToUpper(ch))
            {
                case 'Q': ds[i] = new NVQL(); ds[i].Nhap(); break;
                case 'C': ds[i] = new NVCN(); ds[i].Nhap(); break;
                case 'S': ds[i] = new NVSX(); ds[i].Nhap(); break;
            }
        }
    }
    public void Hien()
    {
        for (int i = 0; i < snv; ++i)
            ds[i].Hien();
    }
}
class App
{
    static void Main()
    {
        QuanLy t = new QuanLy();
        t.Nhap();
        t.Hien();
        Console.ReadKey();
    }
}




