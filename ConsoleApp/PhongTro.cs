using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class PhongTro
    {
        #region Field (14 item)
        private string idPhongTro = "";
        private string soPhong;
        private double dienTich;
        private string noiThat = "";
        private string diaChi = "";
        private int soNguoi;
        private double giaPhong;
        private string ghiChu = "";
        private string cccdNguoiChoThue = "";
        private string cccdNguoiThue = "";
        private bool tinhTrang; // true nếu có người
        private double giaDien; // VNĐ/kWh
        private double giaNuoc; // VNĐ/m^3
        private string review = "";
        #endregion

        #region Properties (14 item)
        public string IDPhongTro { get => idPhongTro; set => idPhongTro = value; }
        public string SoPhong { get => soPhong; set => soPhong = value; }
        public double DienTich { get => dienTich; set => dienTich = value; }
        public string NoiThat { get => noiThat; set => noiThat = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int SoNguoi { get => soNguoi; set => soNguoi = value; }
        public double GiaPhong { get => giaPhong; set => giaPhong = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public string CCCDNguoiChoThue { get => cccdNguoiChoThue; set => cccdNguoiChoThue = value; }
        public string CCCDNguoiThue { get => cccdNguoiThue; set => cccdNguoiThue = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public double GiaDien { get => giaDien; set => giaDien = value; }
        public double GiaNuoc { get => giaNuoc; set => giaNuoc = value; }
        public string PReview { get => review; set => review = value; }
        #endregion

        #region Temp Constructor
        public PhongTro(string soPhong, double dienTich, string[,] noiThat, string diaChi, int soNguoi, double giaPhong,
            string[] ghiChu, NguoiChoThue nguoiChoThue, bool tinhTrang, double giaDien, double giaNuoc)
        {
            // chuyển về kiểu dữ liệu nguyên thuỷ để lưu file.
            // IDPhongTro = Tools.RandomString(9);
            SoPhong = soPhong;
            DienTich = dienTich;
            for (int i = 0; i < noiThat.GetLength(0); i++)
            {
                NoiThat = String.Concat(string.Format("{0},{1},", noiThat[i, 0], noiThat[i, 1]));
            }
            DiaChi = diaChi;
            SoNguoi = soNguoi;
            GiaPhong = giaPhong;
            for (int i = 0; i < ghiChu.Length; i++)
            {
                GhiChu = String.Concat(string.Format("{0},", ghiChu[i]));
            }
            CCCDNguoiChoThue = nguoiChoThue.CCCD;
            TinhTrang = tinhTrang;
            GiaDien = giaDien;
            GiaNuoc = giaNuoc;
        }
        #endregion

        #region Copy Constructor
        public PhongTro(PhongTro phongTro, int soThuTuPhongTro)
        {
            IDPhongTro = Tools.RandomString(9);
            SoPhong = phongTro.SoPhong.Replace(phongTro.SoPhong.Last(), char.Parse(soThuTuPhongTro.ToString()));
            DienTich = phongTro.DienTich;
            NoiThat = phongTro.NoiThat;
            DiaChi = phongTro.DiaChi;
            SoNguoi = phongTro.SoNguoi;
            GiaPhong = phongTro.GiaPhong;
            GhiChu = phongTro.GhiChu;
            CCCDNguoiChoThue = phongTro.CCCDNguoiChoThue;
            //CCCDNguoiThue = phongTro.CCCDNguoiThue;
            TinhTrang = phongTro.TinhTrang;
            GiaDien = phongTro.GiaDien;
            GiaNuoc = phongTro.GiaNuoc;
            //PReview = phongTro.PReview;
        }
        #endregion

        public PhongTro() { }

        ~PhongTro() { }

        public void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin phòng trọ ---");
            Console.WriteLine("Phòng:               " + IDPhongTro);
            Console.WriteLine("Diện tích:           " + DienTich);
            Console.WriteLine("Địa chỉ:             " + DiaChi);
            Console.WriteLine("Số phòng:            " + SoPhong);
            Console.WriteLine("Giá phòng:           " + GiaPhong);
            Console.WriteLine("Tiền điện (VNĐ/kWh): " + GiaDien);
            Console.WriteLine("Tiền nước (VNĐ/m^3): " + GiaNuoc);
            Console.WriteLine("Nội thất   | Giá tiền");
            OutNoiThat(0);
            Console.WriteLine("Ghi chú: ");
            OutGhiChu(0);
            Console.WriteLine("Tình trạng:          " + (TinhTrang ? "đã được thuê" : "chưa được thuê"));
            if (TinhTrang)
            {
                Console.WriteLine("Người thuê:      " + string.Format("{0} {1}", 
                    NguoiThue().GioiTinh ? "Ông" : "Bà", NguoiThue().HoVaTen));
            }
            Console.WriteLine("Số người ở:          " + SoNguoi);
        }

        public dynamic OutNoiThat(int mode)
        {
            string[,] MangNoiThat = { { "" } };
            int count = 0;
            foreach (char ch in NoiThat)
            {
                if (ch == ',')
                {
                    count++;
                }
            }

            string[] temp = NoiThat.Split(',');
            for (int i = 0; i < count/2; i += 2)
            {
                MangNoiThat[i, 0] = temp[i];
                MangNoiThat[i, 1] = temp[i + 1];
            }

            switch (mode)
            {
                case 0: // mode 0: in ra danh sách nội thất
                    {
                        for (int i = 0; i < MangNoiThat.GetLength(0); i++)
                            Console.WriteLine("{0,-10} | {1}", MangNoiThat[i, 0], MangNoiThat[i, 1]);
                        return null;
                    }
                case 1: // mode 1: tính tổng tiền nội thất
                    {
                        double tongTien = 0;
                        for (int i = 0; i < MangNoiThat.GetLength(0); i++)
                            tongTien += double.Parse(MangNoiThat[i, 1]);
                        return tongTien;
                    }
                default: // mode gì cũng đc: trả về mảng string 2 chiều
                    {
                        return MangNoiThat;
                    }
            }
        }

        public dynamic OutGhiChu(int mode)
        {
            string[] MangGhiChu = { "" };
            int count = 0;
            foreach (char ch in NoiThat)
            {
                if (ch == ',')
                {
                    count++;
                }
            }

            string[] temp = GhiChu.Split(',');
            for (int i = 0; i < count; i++)
            {
                MangGhiChu[i] = temp[i];
            }
            switch (mode)
            {
                case 0: // in ra danh sách ghi chú
                    {
                        for (int i = 0; i < MangGhiChu.GetLength(0); i++)
                            Console.WriteLine("    - {0}", MangGhiChu[i]);
                        return null;
                    }
                default: // trả về mảng ghi chú
                    {
                        return MangGhiChu;
                    }
            }
        }

        public NguoiChoThue NguoiChoThue()
        {
            NguoiChoThue result = (NguoiChoThue)(from nguoiChoThue in QuanLyPhongTro.DSNguoiChoThue
                                                 where CCCDNguoiChoThue == nguoiChoThue.CCCD
                                                 select nguoiChoThue);
            return result;
        }

        public NguoiThue NguoiThue()
        {
            NguoiThue result = (NguoiThue)(from nguoiThue in QuanLyPhongTro.DSNguoiThue
                                           where CCCDNguoiThue == nguoiThue.CCCD
                                           select nguoiThue);
            return result;
        }

        public void CapNhatNguoiThue(NguoiThue nguoiThue, int soNguoi)
        {
            if (nguoiThue != null)
            {
                CCCDNguoiThue = nguoiThue.CCCD;
                SoNguoi = soNguoi;
            }
        }

        public void CapNhatTinhTrang(bool tinhTrang, int soNguoi, string[] ghiChu)
        {
            TinhTrang = tinhTrang;
            SoNguoi = soNguoi;
            for (int i = 0; i < ghiChu.Length; i++)
            {
                GhiChu = string.Concat(string.Format("{0},", ghiChu[i]));
            }
            Console.WriteLine("Cập nhật thành công!");
        }

        public void CapNhatGiaDienNuocPhong(double giaDien, double giaNuoc, double giaPhong)
        {
            GiaDien = giaDien;
            GiaNuoc = giaNuoc;
            GiaPhong = giaPhong;

        }

        public void CapNhatNoiThat(string[,] noiThat)
        {
            for (int i = 0; i < noiThat.GetLength(0); i++)
            {
                NoiThat = String.Concat(string.Format("{0},{1},", noiThat[i, 0], noiThat[i, 1]));
            };
        }

        public double TienCanThanhToan(double soDien, double soNuoc)
        {
            double result = soDien * GiaDien + soNuoc * GiaNuoc + GiaPhong + NguoiThue().TienNo;
            Console.WriteLine("Số tiền cần thanh toán là: " + result + " VNĐ (tiền nợ tháng trước: " + NguoiThue().TienNo + " VNĐ)");
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

        THANH_TOAN_LAI:
            Console.WriteLine();
            soTienTT = Inputter.GetDouble("Nhập số tiền muốn thanh toán: ", "Vui lòng nhập đúng định dạng");

            if (tienCanTT > soTienTT)
            {
                if (soTienTT > NguoiThue().TienNo)
                {
                    NguoiThue().XoaNo();
                    Console.WriteLine("Đã thanh toán:   " + soTienTT + " VNĐ");
                    Console.WriteLine("Tiền nợ còn lại: " + (tienCanTT - soTienTT) + "VNĐ");
                    NguoiThue().GhiNo(tienCanTT - soTienTT);
                }
                else
                {
                    Console.WriteLine("Vui lòng thanh toán hết tiền nợ tháng trước!");
                    goto THANH_TOAN_LAI;
                }
            }
            else
            {
                Console.WriteLine("Thanh toán thành công!");
                NguoiThue().XoaNo();
                if (soTienTT > tienCanTT)
                    Console.WriteLine("Tiền dư sau khi thanh toán: " + (soTienTT - tienCanTT) + "VNĐ");
            }
        }

        public void Review()
        {
            Console.WriteLine("Số phòng: " + SoPhong);
            Console.WriteLine("Review của khách hàng về phòng trọ (mỗi dòng review phân ra bằng dấu phẩy - ','): ");
            PReview = string.Concat(Console.ReadLine());
        }

        public static PhongTro[] DSPhongConTrong()
        {
            PhongTro[] dsPT = new PhongTro[100];
            int dem = 0;
            foreach (PhongTro pt in QuanLyPhongTro.DSPhongTro)
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
