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
        private string[] ghiChu = { "" };
        private NguoiChoThue nguoiChoThue;
        private NguoiThue nguoiThue;
        private bool tinhTrang; // true nếu có người
        private double giaDien; // Tien/kWh
        private double giaNuoc; // Tien/m^3
        private string[] review = { "" };

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

        ~PhongTro() { }

        public void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin phòng trọ ---");
            Console.WriteLine("Số phòng:            " + soPhong);
            Console.WriteLine("Diện tích:           " + dienTich);
            Console.WriteLine("Địa chỉ:             " + diaChi);
            Console.WriteLine("Giá phòng:           " + giaPhong);
            Console.WriteLine("Tiền điện (VNĐ/kWh): " + giaDien);
            Console.WriteLine("Tiền nước (VNĐ/m^3): " + giaNuoc);
            Console.WriteLine("Ghi chú: ");
            for (int i = 0; i < ghiChu.Length; i++)
                Console.WriteLine(ghiChu[i]);
            Console.WriteLine("Noi that: ");
            for (int i = 0; i < noiThat.Length; ++i)
                Console.WriteLine(noiThat[i, 0] + ": " + noiThat[i, 1]);
            Console.WriteLine("Tình trạng:          " + (tinhTrang ? "đã được thuê" : "chưa được thuê"));
            Console.WriteLine("Số người ở:          " + soNguoi);
        }

        public void CapNhatTinhTrang(bool tinhTrang, int soNguoi, string[] ghiChu)
        {
            this.tinhTrang = tinhTrang;
            this.soNguoi = soNguoi;
            this.ghiChu = ghiChu;
            Console.WriteLine("Cập nhật thành công!");
        }

        public void CapNhatGiaDienNuocPhong(double giaDien, double giaNuoc, double giaPhong)
        {
            this.giaDien = giaDien;
            this.giaNuoc = giaNuoc;
            this.giaPhong = giaPhong;
        }

        public void CapNhatNoiThat(string[,] noiThat)
        {
            this.noiThat = noiThat;
        }

        public double TienCanThanhToan(double soDien, double soNuoc)
        {
            double result = soDien * giaDien + soNuoc * giaNuoc + giaPhong + nguoiThue.TienConNo();
            Console.WriteLine("Số tiền cần thanh toán là: " + result + " (tiền nợ tháng trước: " + nguoiThue.TienConNo() + " VNĐ)");
            return result;
        }

        public void ThanhToan()
        {
            double soTienTT;
            double soDien, soNuoc;
            soDien = Inputter.GetDouble("Nhập số điện đã sử dụng: ");
            Console.WriteLine("Nhập số nước đã sử dụng: ");
            soNuoc = Inputter.GetDouble("Nhập số nước đã sử dụng: ");
            double tienCanTT = TienCanThanhToan(soDien, soNuoc);

        ThanhToanLai:
            Console.WriteLine();
            soTienTT = Inputter.GetDouble("Nhập số tiền muốn thanh toán: ");

            if (tienCanTT > soTienTT)
            {
                if (soTienTT > nguoiThue.TienConNo())
                {
                    nguoiThue.ThanhToanNo();
                    Console.WriteLine("Đã thanh toán:   " + soTienTT + " VNĐ");
                    Console.WriteLine("Tiền nợ còn lại: " + (tienCanTT - soTienTT) + "VNĐ");
                    nguoiThue.GhiNo(tienCanTT - soTienTT);
                }
                else
                {
                    Console.WriteLine("Vui lòng thanh toán hết tiền nợ tháng trước!");
                    goto ThanhToanLai;
                }
            }
            else
            {
                Console.WriteLine("Thanh toán thành công!");
                nguoiThue.ThanhToanNo();
                if (soTienTT > tienCanTT)
                    Console.WriteLine("Tiền dư sau khi thanh toán: " + (soTienTT - tienCanTT) + "VNĐ");
            }
        }

        public void Review()
        {
            Console.WriteLine("Số phòng: " + soPhong);
            Console.WriteLine("Review của khách hàng về phòng trọ: ");
            review[review.Length - 1] = Console.ReadLine();
        }

        public void Save()
        {
            // Luu thong tin Phong Tro vao file PhongTro.txt hoac cham gi do
        }

    }
}
