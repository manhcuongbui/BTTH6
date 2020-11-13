using System;
using System.Collections.Generic;
using System.Text;

namespace BTTH6
    /* bau2-BTH6:Xây dựng lớp Person */
    class Person
{

    private string hoten, quequan;
    private DateTime ngaysinh;
    public Person()
    {
        hoten = quequan = " ";
        ngaysinh = DateTime.Now;
    }
    public Person(string hoten, string quequan, DateTime ngaysinh)
    {
        this.hoten = hoten;
        this.quequan = quequan;
        this.ngaysinh = ngaysinh;
    }
    public virtual void Nhap()
    {
        Console.Write("Nhap ho va ten:");
        hoten = Console.ReadLine();
        Console.Write("Nhap que quan:");
        quequan = Console.ReadLine();
        Console.Write("Nhap ngay sinh:");
        ngaysinh = DateTime.Parse(Console.ReadLine());
    }
    public virtual void Hien()
    {
        Console.WriteLine("Ho ten:{0}\tNgay sinh:{1}\tQue quan:{2}", hoten, quequan, ngaysinh);
    }
}

//--------------------------------------------------------------------------------------------------------------------
class Sinhvien : Person
{
    private string masv, lop;
    public Sinhvien() : base()
    {
        masv = lop = " ";
    }
    public Sinhvien(string hoten, string diachi, DateTime ngaysinh, string masv, string lop) : base(hoten, diachi, ngaysinh)
    {
        this.masv = masv;
        this.lop = lop;
    }
    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap ma sinh vien:");
        masv = Console.ReadLine();
        Console.Write("Nhap lop:");
        lop = Console.ReadLine();
    }
    public override void Hien()
    {
        base.Hien();
        Console.WriteLine("Ma sinh vien:{0}\t Lop:{1}", masv, lop);
    }

}

//------------------------------------------------------------------------------------------------------------
// test
 class test
{
    static void Main2()
    {


    }
}