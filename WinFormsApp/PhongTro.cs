using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using WinFormsApp;

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
        private static List<PhongTro> phongtroList = new List<PhongTro>();

        public static List<PhongTro> PhongTroList
        {
            get { return phongtroList; }
            set { phongtroList = value; }
        }

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
            Form form = new Form();
            
            form.ShowDialog();
        }

        public double GiaPhong()
        {
            return giaPhong;
        }

        public int SoPhong()
        {
            return soPhong;
        }
        public string[] GhiChu()
        {
            return ghiChu;
        }

        public NguoiChoThue NguoiChoThue()
        {
            return nguoiChoThue;
        }

        public void CapNhatTinhTrang(bool tinhTrang, int soNguoi, string[] ghiChu)
        {
            this.tinhTrang = tinhTrang;
            this.soNguoi = soNguoi;
            this.ghiChu = ghiChu;
            Console.WriteLine("Cập nhật thành công!");
            //Cập nhật thông tin trong file
        }

        public void CapNhatGiaDienNuocPhong(double giaDien, double giaNuoc, double giaPhong)
        {
            this.giaDien = giaDien;
            this.giaNuoc = giaNuoc;
            this.giaPhong = giaPhong;
            //Cập nhật thông tin trong file
        }

        public void CapNhatNoiThat(string[,] noiThat)
        {
            this.noiThat = noiThat;

            //Cập nhật thông tin trong file
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
            soDien = Inputter.GetDouble("Nhập số điện đã sử dụng: ","Vui lòng nhập đúng định dạng");
            Console.WriteLine("Nhập số nước đã sử dụng: ");
            soNuoc = Inputter.GetDouble("Nhập số nước đã sử dụng: ", "Vui lòng nhập đúng định dạng");
            double tienCanTT = TienCanThanhToan(soDien, soNuoc);

        ThanhToanLai:
            Console.WriteLine();
            soTienTT = Inputter.GetDouble("Nhập số tiền muốn thanh toán: ", "Vui lòng nhập đúng định dạng");

            if (tienCanTT > soTienTT)
            {
                if (soTienTT > nguoiThue.TienConNo())
                {
                    nguoiThue.XoaNo();
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
                nguoiThue.XoaNo();
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


        public static PhongTro[] DSPhongConTrong()
        {
            PhongTro[] dsPT = new PhongTro[100];
            int dem = 0;
            foreach(PhongTro pt in PhongTroList)
            {
                if (pt.tinhTrang == false)
                {
                    dsPT[dem] = pt;
                    dem++;
                }
            }
            return dsPT;
        }
    }
}
