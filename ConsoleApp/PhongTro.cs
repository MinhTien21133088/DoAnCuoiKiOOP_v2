using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class PhongTro
    {
        #region Fields
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
        private static List<PhongTro> phongTroList = new List<PhongTro>();
        #endregion

        #region Properties
        public double DienTich { get => dienTich; set => dienTich = value; }
        public string[,] NoiThat { get => noiThat; set => noiThat = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int SoPhong { get => soPhong; set => soPhong = value; }
        public int SoNguoi { get => soNguoi; set => soNguoi = value; }
        public double GiaPhong { get => giaPhong; set => giaPhong = value; }
        public string[] GhiChu { get => ghiChu; set => ghiChu = value; }
        public NguoiChoThue NguoiChoThue { get => nguoiChoThue; set => nguoiChoThue = value; }
        public NguoiThue NguoiThue { get => nguoiThue; set => nguoiThue = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public double GiaDien { get => giaDien; set => giaDien = value; }
        public double GiaNuoc { get => giaNuoc; set => giaNuoc = value; }
        public string[] Review1 { get => review; set => review = value; }
        public static List<PhongTro> PhongTroList { get => phongTroList; set => phongTroList = value; }
        #endregion

        public PhongTro(double dienTich, string[,] noiThat, string diaChi, int soPhong, int soNguoi, double giaPhong, string[] ghiChu, NguoiChoThue nguoiChoThue, NguoiThue nguoiThue, bool tinhTrang, double giaDien, double giaNuoc, string[] review)
        {
            DienTich = dienTich;
            NoiThat = noiThat;
            DiaChi = diaChi;
            SoPhong = soPhong;
            SoNguoi = soNguoi;
            GiaPhong = giaPhong;
            GhiChu = ghiChu;
            NguoiChoThue = nguoiChoThue;
            NguoiThue = nguoiThue;
            TinhTrang = tinhTrang;
            GiaDien = giaDien;
            GiaNuoc = giaNuoc;
            Review1 = review;
        }
        public PhongTro() { }

        ~PhongTro() { }

        public void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin phòng trọ ---");
            Console.WriteLine("Số phòng:            " + SoPhong);
            Console.WriteLine("Diện tích:           " + DienTich);
            Console.WriteLine("Địa chỉ:             " + DiaChi);
            Console.WriteLine("Giá phòng:           " + GiaPhong);
            Console.WriteLine("Tiền điện (VNĐ/kWh): " + GiaDien);
            Console.WriteLine("Tiền nước (VNĐ/m^3): " + GiaNuoc);
            Console.WriteLine("Ghi chú: ");
            for (int i = 0; i < GhiChu.Length; i++)
                Console.WriteLine(GhiChu[i]);
            Console.WriteLine("Nội thất (đếm số ô có thể) | Giá tiền");
            for (int i = 0; i < NoiThat.GetLength(0); i++)
                Console.WriteLine("{0,-(10)} | {1} ", NoiThat[i, 0], NoiThat[i, 1]);
            Console.WriteLine("Tình trạng:          " + (TinhTrang ? "đã được thuê" : "chưa được thuê"));
            Console.WriteLine("Số người ở:          " + SoNguoi);
        }

        public void CapNhatTinhTrang(bool tinhTrang, int soNguoi, string[] ghiChu)
        {
            TinhTrang = tinhTrang;
            SoNguoi = soNguoi;
            GhiChu = ghiChu;
            Console.WriteLine("Cập nhật thành công!");
            //Cập nhật thông tin trong file
        }

        public void CapNhatGiaDienNuocPhong(double giaDien, double giaNuoc, double giaPhong)
        {
            GiaDien = giaDien;
            GiaNuoc = giaNuoc;
            GiaPhong = giaPhong;
            //Cập nhật thông tin trong file
        }

        public void CapNhatNoiThat(string[,] noiThat)
        {
            NoiThat = noiThat;

            //Cập nhật thông tin trong file
        }

        public double TienCanThanhToan(double soDien, double soNuoc)
        {
            double result = soDien * GiaDien + soNuoc * GiaNuoc + GiaPhong + NguoiThue.TienConNo();
            Console.WriteLine("Số tiền cần thanh toán là: " + result + " (tiền nợ tháng trước: " + NguoiThue.TienConNo() + " VNĐ)");
            return result;
        }

        public void ThanhToan()
        {
            double soTienTT;
            double soDien, soNuoc;
            soDien = Inputter.GetDouble("Nhập số điện đã sử dụng: ", "Vui lòng nhập đúng định dạng");
            Console.WriteLine("Nhập số nước đã sử dụng: ");
            soNuoc = Inputter.GetDouble("Nhập số nước đã sử dụng: ", "Vui lòng nhập đúng định dạng");
            double tienCanTT = TienCanThanhToan(soDien, soNuoc);

        ThanhToanLai:
            Console.WriteLine();
            soTienTT = Inputter.GetDouble("Nhập số tiền muốn thanh toán: ", "Vui lòng nhập đúng định dạng");

            if (tienCanTT > soTienTT)
            {
                if (soTienTT > NguoiThue.TienConNo())
                {
                    NguoiThue.XoaNo();
                    Console.WriteLine("Đã thanh toán:   " + soTienTT + " VNĐ");
                    Console.WriteLine("Tiền nợ còn lại: " + (tienCanTT - soTienTT) + "VNĐ");
                    NguoiThue.GhiNo(tienCanTT - soTienTT);
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
                NguoiThue.XoaNo();
                if (soTienTT > tienCanTT)
                    Console.WriteLine("Tiền dư sau khi thanh toán: " + (soTienTT - tienCanTT) + "VNĐ");
            }
        }

        public void Review()
        {
            Console.WriteLine("Số phòng: " + SoPhong);
            Console.WriteLine("Review của khách hàng về phòng trọ: ");
            Review1[Review1.Length - 1] = Console.ReadLine();
        }

        public static PhongTro[] DSPhongConTrong()
        {
            PhongTro[] dsPT = new PhongTro[100];
            int dem = 0;
            foreach (PhongTro pt in PhongTroList)
            {
                if (pt.TinhTrang == false)
                {
                    dsPT[dem] = pt;
                    dem++;
                }
            }
            return dsPT;
        }
    }
}
