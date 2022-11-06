using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class PhongTro
    {
        private double dienTich;
        private string[,] noiThat = { { "" } };
        private string diaChi = "";
        private int soPhong;
        private int soNguoi;
        private double giaPhong;
        private string[] ghiChu = {""};
        private NguoiChoThue nguoiChoThue;
        private NguoiThue nguoiThue;
        private bool tinhTrang; // true nếu có người
        private double giaDien; // Tien/kWh
        private double giaNuoc; // Tien/m^3
        private string[] review = {""};

        public PhongTro(double dienTich, string[,] noiThat, string diaChi, int soPhong, int soNguoi, double giaPhong, string[] ghiChu, NguoiChoThue nguoiChoThue, NguoiThue nguoiThue, bool tinhTrang, double giaDien, double giaNuoc, string[] review)
        {
            this.dienTich = dienTich;
            this.noiThat = noiThat;
            this.diaChi = diaChi;
            this.soPhong = soPhong;
            this.soNguoi = soNguoi;
            this.giaPhong = giaPhong;
            this.ghiChu = ghiChu;
            this.nguoiChoThue = nguoiChoThue;
            this.nguoiThue = nguoiThue;
            this.tinhTrang = tinhTrang;
            this.giaDien = giaDien;
            this.giaNuoc = giaNuoc;
            this.review = review;
        }

        public void XuatThongTin()
        {
            Console.WriteLine("Thong tin phong tro");
            Console.WriteLine("So phong: " + soPhong);
            Console.WriteLine("Dien tich: " + dienTich);
            Console.WriteLine("Dia chi: " + diaChi);
            Console.WriteLine("Gia phong: " + giaPhong);
            Console.WriteLine("Gia tien dien (d/kWh): " + giaDien);
            Console.WriteLine("Gia tien nuoc (d/m^3): " + giaNuoc);
            Console.WriteLine("Ghi chu: ");
            for(int i =0;i <ghiChu.Length;i++)
                Console.WriteLine(ghiChu[i]);
            Console.WriteLine("Noi that: ");
            for(int i = 0; i < noiThat.Length;++i)
                Console.WriteLine(noiThat[i,0] + ": " + noiThat[i,1]);
            Console.WriteLine("Tinh trang: " + (tinhTrang ? "co nguoi" : "khong co nguoi"));
            Console.WriteLine("So nguoi: " + soNguoi);
        }

        public void CapNhatTinhTrang(bool tinhTrang,int soNguoi, string[] ghiChu)
        {
            this.tinhTrang = tinhTrang;
            this.soNguoi = soNguoi;
            this.ghiChu = ghiChu;
            Console.WriteLine("Cap nhat thanh cong!");
        }

        public void CapNhatGiaDienNuocPhong(double giaDien, double giaNuoc, double giaPhong)
        {
            this.giaDien = giaDien;
            this.giaNuoc = giaNuoc;
            this.giaPhong = giaPhong;
        }

        public void CapNhatNoiThat(string[,]noiThat )
        {
            this.noiThat = noiThat;
        }

        public double TienCanThanhToan(double soDien, double soNuoc)
        {
            double result = soDien * giaDien + soNuoc * giaNuoc + giaPhong + nguoiThue.TienConNo();
            Console.WriteLine("So tien can thanh toan la: " + result + " ( trong do tien no thang truoc la: " + nguoiThue.TienConNo() + " )");
            return result;
        }

        public void ThanhToan() 
        {
            double soTienTT;
            double soDien, soNuoc;
            Console.WriteLine("Nhap so dien da su dung: ");
            soDien = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhap so nuoc da su dung: ");
            soNuoc = Convert.ToDouble(Console.ReadLine());
            double tienCanTT = TienCanThanhToan(soDien,soNuoc);
            
            ThanhToanLai:
            Console.WriteLine("Nhap so tien muon thanh toan: ");
            soTienTT= Convert.ToDouble(Console.ReadLine());

            if(tienCanTT > soTienTT)
            {
                if (soTienTT > nguoiThue.TienConNo())
                {
                    nguoiThue.ThanhToanNo();
                    Console.WriteLine("Ban da thanh toan " + soTienTT + " va con no lai " + (tienCanTT - soTienTT));
                    nguoiThue.ghiNo(tienCanTT - soTienTT);
                }
                else
                {
                    Console.WriteLine("Ban vui long thanh toan het no thang truoc!");
                    goto ThanhToanLai;
                }
            }
            else
            {
                Console.WriteLine("Ban da thanh toan thanh cong!");
                nguoiThue.ThanhToanNo();
                if (soTienTT > tienCanTT)
                    Console.WriteLine("So tien du sau khi thanh toan: " +(soTienTT-tienCanTT));
            }
        }

        public void Review()
        {
            Console.WriteLine("So phong: " + soPhong);
            Console.WriteLine("Nhap review cua ban ve phong tro nay: ");
            review[review.Length - 1] = Console.ReadLine();
        }

        public void Save()
        {
             // Luu thong tin Phong Tro vao file PhongTro.txt hoac cham gi do
        }
    }
}