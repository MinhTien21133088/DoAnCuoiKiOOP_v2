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
        private int giaPhong;
        private string[] ghiChu = {""};
        private NguoiChoThue nguoiChoThue;
        private NguoiThue nguoiThue;
        private bool tinhTrang; // true nếu có người
        private double giaDien; // Tien/kWh
        private double giaNuoc; // Tien/m^3

        public void XuatThongTin()
        {

        }

        public void CapNhat()
        {

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
    }
}