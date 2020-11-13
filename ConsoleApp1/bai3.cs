
using System;
abstract class Nhanvien
{
    protected string hoten;
    protected string diachi;
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
    public virtual void Nhap()
    {
        Console.Write("Nhap ho ten:");
        hoten = Console.ReadLine();
        Console.Write("Nhap dia chi:");
        diachi = Console.ReadLine();
        ngaysinh = DateTime.Parse(Console.ReadLine());
    }
    public virtual void Hien()
    {
        Console.WriteLine("{0}\t{1}\t{2}", hoten, diachi, ngaysinh);
    }
    public abstract double Tinhluong();
}
public class NVSX : Nhanvien
{
    private int ssp;
    public NVSX() : base() { ssp = 0; }
    public NVSX(string hoten, string diachi, DateTime ngaysinh, int ssp)
        : base(hoten, diachi, ngaysinh) { this.ssp = ssp; }
    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin cho nhan vien san xuat");
        base.Nhap();
        Console.Write("Nhap so san pham:");
        ssp = int.Parse(Console.ReadLine());
    }
    public override void Hien()
    {
        Console.WriteLine("Thong tin luong cua nhan vien san xuat");
        base.Hien();
        Console.WriteLine("So san pham" + ssp);
        Console.WriteLine("Luong:" + Tinhluong());
    }
    public override double Tinhluong()
    {
        return ssp * 20;
    }
}
public class NVCN : Nhanvien
{
    private int snc;
    public NVCN() : base() { snc = 0; }
    public NVCN(string hoten, string diachi, DateTime ngaysinh, int snc)
        : base(hoten, diachi, ngaysinh) { this.snc = snc; }
    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin cho nhan vien cong nhat");
        base.Nhap();
        Console.Write("Nhap so ngay cong:");
        snc = int.Parse(Console.ReadLine());
    }
    public override void Hien()
    {
        Console.WriteLine("Thong tin luong cua nhan vien cong nhat");
        base.Hien();
        Console.WriteLine("So ngay cong" + snc);
        Console.WriteLine("Luong:" + Tinhluong());
    }
    public override double Tinhluong()
    {
        return snc * 50;
    }
}
public class NVQL : Nhanvien
{
    private double hsl;
    private static int luongcoban = 1050;
    public NVQL() : base() { hsl = 2.34; }
    public NVQL(string hoten, string diachi, DateTime ngaysinh, int hsl)
        : base(hoten, diachi, ngaysinh) { this.hsl = hsl; }
    public static int Luongcoban
    {
        get { return luongcoban; }
        set
        {
            if (value > 1050) luongcoban = value;
        }
    }

    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin cho nhan vien quan ly");
        base.Nhap();
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
class test
{
    static void Main1()
    {
        QuanLy t = new QuanLy();
        t.Nhap();
        t.Hien();
        Console.ReadKey();
    }
}


