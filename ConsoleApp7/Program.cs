//Tran Bao Quan - 21810310025

using System;
using System.Collections.Generic;

namespace ThuongMaiDienTu
{
    // Lop cha SanPham
    class SanPham
    {
        public string Ten { get; set; }
        public double Gia { get; set; }
        public string MoTa { get; set; }
        public int SoLuong { get; set; }

        public SanPham(string ten, double gia, string mota, int soluong)
        {
            Ten = ten;
            Gia = gia;
            MoTa = mota;
            SoLuong = soluong;
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Ten san pham: {Ten}, Gia: {Gia} VND, Mo ta: {MoTa}, So luong: {SoLuong}");
        }
    }

    // Lop con DienTu
    class DienTu : SanPham
    {
        public int BaoHanh { get; set; } // So thang bao hanh

        public DienTu(string ten, double gia, string mota, int soluong, int baohanh)
            : base(ten, gia, mota, soluong)
        {
            BaoHanh = baohanh;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Bao hanh: {BaoHanh} thang");
        }
    }

    // Lop con QuanAo
    class QuanAo : SanPham
    {
        public string KichThuoc { get; set; }
        public string MauSac { get; set; }

        public QuanAo(string ten, double gia, string mota, int soluong, string kichthuoc, string mausac)
            : base(ten, gia, mota, soluong)
        {
            KichThuoc = kichthuoc;
            MauSac = mausac;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Kich thuoc: {KichThuoc}, Mau sac: {MauSac}");
        }
    }

    // Lop con ThucPham
    class ThucPham : SanPham
    {
        public DateTime NgayHetHan { get; set; }

        public ThucPham(string ten, double gia, string mota, int soluong, DateTime ngayhethan)
            : base(ten, gia, mota, soluong)
        {
            NgayHetHan = ngayhethan;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Ngay het han: {NgayHetHan.ToShortDateString()}");
        }
    }

    // Lop GioHang
    class GioHang
    {
        public List<SanPham> DanhSachSanPham { get; private set; }

        public GioHang()
        {
            DanhSachSanPham = new List<SanPham>();
        }

        public void ThemSanPham(SanPham sanpham)
        {
            DanhSachSanPham.Add(sanpham);
            Console.WriteLine($"{sanpham.Ten} da duoc them vao gio hang.");
        }

        public void XoaSanPham(SanPham sanpham)
        {
            DanhSachSanPham.Remove(sanpham);
            Console.WriteLine($"{sanpham.Ten} da duoc xoa khoi gio hang.");
        }

        public void HienThiDanhSachSanPham()
        {
            Console.WriteLine("\nDanh sach san pham trong gio hang:");
            foreach (var sanpham in DanhSachSanPham)
            {
                sanpham.HienThiThongTin();
                Console.WriteLine();
            }
        }

        public double TinhTongGiaTri()
        {
            double tong = 0;
            foreach (var sanpham in DanhSachSanPham)
            {
                tong += sanpham.Gia * sanpham.SoLuong;
            }
            return tong;
        }
    }

    // Chuong trinh chinh
    class Program
    {
        static void Main(string[] args)
        {
            // Tao mot so san pham mau
            var dientu1 = new DienTu("Laptop", 15000000, "Laptop Dell", 1, 12);
            var quanao1 = new QuanAo("Ao thun", 200000, "Ao thun cotton", 2, "L", "Den");
            var thucpham1 = new ThucPham("Tao", 50000, "Tao do My", 5, new DateTime(2024, 12, 1));

            // Tao gio hang
            var giohang = new GioHang();

            // Them san pham vao gio hang
            giohang.ThemSanPham(dientu1);
            giohang.ThemSanPham(quanao1);
            giohang.ThemSanPham(thucpham1);

            // Hien thi san pham trong gio hang
            giohang.HienThiDanhSachSanPham();

            // Tinh tong gia tri don hang
            double tongGiaTri = giohang.TinhTongGiaTri();
            Console.WriteLine($"Tong gia tri don hang: {tongGiaTri} VND");

            // Xoa san pham khoi gio hang (tuy chon)
            giohang.XoaSanPham(quanao1);

            // Hien thi lai gio hang va tinh toan lai tong gia tri
            giohang.HienThiDanhSachSanPham();
            tongGiaTri = giohang.TinhTongGiaTri();
            Console.WriteLine($"Tong gia tri don hang sau khi xoa san pham: {tongGiaTri} VND");
        }
    }
}

