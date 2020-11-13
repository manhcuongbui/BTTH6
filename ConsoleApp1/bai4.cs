using System;
using System.Collections.Generic;
using System.Text;

namespace BTH6 /* bài4-BTH5: Phân tích, thiết kế và hiện thực theo hướng đối tượng chương trình tình tiền hóa
đơn sử dụng các dịch vụ tại một khách sạn, thông tin Hóa đơn: makh(mã khách hàng),
tenkh(họ tên khách hàng), và các dịch vụ mà khách hàng đã sử dụng, trigia(trị giá hóa
đơn). Hiện giờ khách sạn chỉ có hai dịch vụ: Giặt tẩy và Thuê xe. Mỗi dịch vụ có cách
tính tiền khác nhau
+ Dịch vụ giặt tẩy: tiền giặt tẩy tính theo số kilogam quần áo, đơn giá/kg. Nếu số
kg trên 10kg thì giảm 5%
+ Dịch vụ thuê xe: tiền thuê xe được tính theo số giờ, đơn giá/giờ. Nếu thuê quá
7giờ giảm 10% */
abstract class Xe
{
    protected double sogio;
    public Xe(double sogio)
    {
        this.sogio = sogio;
    }
    public abstract double TinhTien();
    public abstract void Hien();
}
class XeDL : Xe
{
    public XeDL(double sogio) : base(sogio) { }
    public override double TinhTien()
    {
        if (sogio <= 1) return 250;
        else
            return 250 + (sogio - 1) * 75;
    }
    public override void Hien()
    {
        Console.WriteLine("Xe du lich");
    }
}
class XeTai : Xe
{
    public XeTai(double sogio) : base(sogio) { }
    public override double TinhTien()
    {
        if (sogio <= 1) return 220;
        else
            return 220 + (sogio - 1) * 85;
    }
    public override void Hien()
    {
        Console.WriteLine("Xu xe tai");
    }
}
class Khach
{
    private string hoten, quequan;
    private DateTime ngaysinh;
    private double sogio;
    private Xe loaixe;
    public void Nhap()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Thông tin khách thuê xe:");
        Console.Write("Ho ten:"); hoten = Console.ReadLine();
        Console.Write("Que quan:"); quequan = Console.ReadLine();
        Console.Write("Ngay sinh:"); ngaysinh = DateTime.Parse(Console.ReadLine());
        Console.Write("So gio:"); sogio = double.Parse(Console.ReadLine());
        Console.Write("Khach hang muon thue loai xe nao XeDL(L) hay XeTai(T)?");
        char ch = char.Parse(Console.ReadLine());
        switch (char.ToUpper(ch))
        {
            case 'L':
                loaixe = new XeDL(sogio);
                Console.WriteLine("Khách vừa thuê xe:"); loaixe.Hien();
                break;
            case 'T':
                loaixe = new XeTai(sogio);
                Console.WriteLine("Khách hàng vừa thuê xe:"); loaixe.Hien();
                break;
        }
    }
    public void Hien()
    {
        Console.WriteLine("Thong tin khach hang thue xe");
        Console.WriteLine("Ho ten:" + hoten);
        Console.WriteLine("Que quan:" + quequan);
        Console.WriteLine("Ngay sinh:" + ngaysinh.ToString("dd/MM/yyyy"));
        Console.WriteLine("So gio thue:" + sogio);
        Console.WriteLine("Dich vu xe khach hang da thue:");
        loaixe.Hien();
        Console.WriteLine("Tien thue xe:" + loaixe.TinhTien());
    }
}
class QL
{
    private Khach[] ds;
    private int sck;
    public void Nhap()
    {
        Console.Write("so khach hang:"); sck = int.Parse(Console.ReadLine());
        ds = new Khach[sck];
        for (int i = 0; i < sck; ++i)
        {
            ds[i] = new Khach();
            ds[i].Nhap();
        }
    }

    public void Hien()
    {
        Console.WriteLine("Thong tin cac khach hang da thue xe ");
        for (int i = 0; i < sck; ++i)
        {
            Console.WriteLine("-----------------------");
            ds[i].Hien();
        }
    }
}


class test1
{
    static void Main()
    {
        QL t = new QL();
        t.Nhap();
        Console.Clear();
        t.Hien();
        Console.ReadKey();
    }
} }



