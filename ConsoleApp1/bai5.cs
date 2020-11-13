using System;
using System.Collections.Generic;
using System.Text;
/* BÀI 5- BTH6:THUÊ PHÒNG KHÁCH SẠN
 */
abstract class Phong
{
    protected int songay;
    public Phong(int songay)
    {
        this.songay = songay;
    }
    public abstract double TinhTien();
    public abstract void Hien();
}
class PhongA : Phong
{
    protected int tiendv;
    public PhongA(int songay)
        : base(songay)
    {
        Console.Write("Nhap tien dv:"); tiendv = int.Parse(Console.ReadLine());
    }

    public override double TinhTien()
    {
        if (songay < 5) return songay * 80 + tiendv;
        else return 5 * 80 * +(songay - 5) * 80 * 0.9 + tiendv;
    }
    public override void Hien()
    {
        Console.WriteLine("Dich vu phong A");
        Console.WriteLine("Tien dich vu:" + tiendv);
        Console.WriteLine("Tien phong:" + TinhTien());
    }
}
class PhongB : Phong
{
    public PhongB(int songay)
        : base(songay) { }
    public override double TinhTien()
    {
        if (songay < 5) return songay * 60;
        else return 5 * 60 * +(songay - 5) * 60 * 0.9;
    }
    public override void Hien()
    {
        Console.WriteLine("Dich vu phong B");
        Console.WriteLine("Tien phong:" + TinhTien());
    }
}
class PhongC : Phong
{
    public PhongC(int songay)
        : base(songay) { }
    public override double TinhTien()
    {
        return songay * 40;
    }
    public override void Hien()
    {
        Console.WriteLine("Dich vu phong C");
        Console.WriteLine("Tien phong:" + TinhTien());
    }
}
class HoaDoanKhach
{
    private string tenkhach;
    private int songay;
    private Phong loaiphong;
    public void Nhap()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Nhập thông tin hóa đơn khách hàng");
        Console.Write("Họ tên:"); tenkhach = Console.ReadLine();
        Console.Write("Số ngày ở:"); songay = int.Parse(Console.ReadLine());
        Console.WriteLine("Cho biết loại phòng ở A, B, C?");
        char ch = char.Parse(Console.ReadLine());
        switch (char.ToUpper(ch))
        {
            case 'A': loaiphong = new PhongA(songay); break;
            case 'B': loaiphong = new PhongB(songay); break;
            case 'C': loaiphong = new PhongB(songay); break;
        }
    }
    public void Hien()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Thông tin hóa đơn khách hàng");
        Console.WriteLine("Họ tên khách hàng:" + tenkhach);
        Console.WriteLine("Số ngày:" + songay);
        Console.WriteLine("Khách hàng dự định:");
        loaiphong.Hien();
    }
}
class Tets
{
    static void Main5()
    {
        HoaDoanKhach t = new HoaDoanKhach();
        t.Nhap();
        Console.Clear();
        t.Hien();
        Console.ReadLine();
        Console.ReadKey();
    }
}

