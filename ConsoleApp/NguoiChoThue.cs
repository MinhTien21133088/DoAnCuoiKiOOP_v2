using FileGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class NguoiChoThue : Nguoi
    {
        private PhongTro[] dsPhongTro = new PhongTro[100];
        private int slTro = 0;
        private static List<NguoiChoThue> chuList = new List<NguoiChoThue>();

        public PhongTro[] DsPhongTro { get => dsPhongTro; set => dsPhongTro = value; }
        public int SlTro { get => slTro; set => slTro = value; }
        public static List<NguoiChoThue> ChuList { get => chuList; set => chuList = value; }

        public NguoiChoThue(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep, string diaChi, string tenDangNhap, string matKhau) : base(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, diaChi, tenDangNhap, matKhau)
        {
        }

        public NguoiChoThue() { }

        ~NguoiChoThue() { }

        public void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin người cho thuê ---");
            base.XuatThongTin();
        }

        public static bool DangKy()
        {
            Program.InputUnicode();
            Console.WriteLine("--- Nhập thông tin cơ bản ---");
            string hoVaTen = Inputter.GetString("Họ và tên: ", "Tên không được bỏ trống");
            string cccd = Inputter.GetStringF("Số CCCD: ", "CCCD không hợp lệ", "^[0-9]{9}$|^[0-9]{12}$");
            string sdt = Inputter.GetStringF("Số điện thoại: ", "Số điện thoại không hợp lệ", "^0[0-9]{9}$");
            bool gioiTinh = Inputter.GetInteger("Giới tính ('1' - Nam|'0' - Nữ): ", "Không hợp lệ!", 0, 1) == 1 ? true : false;
            DateTime ngaySinh;
        NHAP_LAI_NGAY_SINH:
            try
            {
                ngaySinh = DateTime.ParseExact(
                    Inputter.GetStringF(
                        "Ngày tháng năm sinh (dd/MM/yyyy): ", "Ngày tháng năm sinh không hợp lệ",
                        "((0|1)[0-9]|2[0-9]|3[0-9])/(0[0-9]|1[0-2])/((19|20)[0-9][0-9])$"), "dd/MM/yyyy", null);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ngày tháng năm sinh không hợp lệ.");
                goto NHAP_LAI_NGAY_SINH;
            }
            string ngheNghiep = Inputter.GetString("Nghề nghiệp: ", "Nghề nghiệp không được bỏ trống");
            string diaChi = Inputter.GetString("Địa chỉ: ", "Địa chỉ không được bỏ trống");
            string tenDangNhap = Inputter.GetString("Tên đăng nhập: ", "Tên đăng nhập không được bỏ trống");
            string matKhau = Inputter.GetString("Mật khẩu: ", "Mật khẩu không được bỏ trống");

            ChuList.Add(new NguoiChoThue(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, diaChi, tenDangNhap, matKhau));
            return true;
        }

        public static NguoiChoThue DangNhap()
        {
            string ten = Inputter.GetString("Tên đăng nhập: ", "Tên đăng nhập không được bỏ trống");
            string mK = Inputter.GetString("Mật khẩu: ", "Mật khẩu không được bỏ trống");
            foreach (NguoiChoThue nguoi in ChuList)
            {
                if (ten == nguoi.TenDangNhap && mK == nguoi.MatKhau)
                    return nguoi;
            }
            Console.WriteLine("Tên đăng nhập hoặc mật khẩu không hợp lệ");
            return null;
        }

        public void ThemPhongTro()
        {
            Program.InputUnicode();
            double dienTich = Inputter.GetDouble("Nhập diện tích của phòng trọ: ", "Vui lòng nhập đúng định dạng");
            int slNoiThat = Inputter.GetInteger("Nhập số lượng nội thất: ", "Vui lòng nhập đúng định dạng");
            string[,] noiThat = new string[100, 100];
            for (int i = 0; i < slNoiThat; ++i)
            {
                noiThat[i, 0] = Inputter.GetString("Nhập nội thất: ", "Vui lòng không bỏ trống");
                noiThat[i, 1] = Inputter.GetInteger("Nhập giá trị nội thất: ", "Vui lòng nhập đúng định dạng").ToString();
            }
            string diaChi = Inputter.GetString("Nhập địa chỉ: ", "Vui lòng không bỏ trống");
            int soPhong = Inputter.GetInteger("Nhập số phòng: ", "Vui lòng nhập đúng định dạng");
            double giaPhong = Inputter.GetDouble("Nhập giá phòng: ", "Vui lòng nhập đúng định dạng");
            int slGhiChu = Inputter.GetInteger("Nhập số lượng ghi chú: ", "Vui lòng nhập đúng định dạng");
            string[] ghiChu = { "" };
            for (int i = 0; i < slGhiChu; ++i)
            {
                ghiChu[i] = Inputter.GetString("Nhập ghi chú " + (i + 1) + ": ", "Vui lòng không bỏ trống");
            }
            double giaDien = Inputter.GetDouble("Nhập giá điện (VNĐ/kWh): ", "Vui lòng nhập đúng định dạng");
            double giaNuoc = Inputter.GetDouble("Nhập giá nước (VNĐ/m^3): ", "Vui lòng nhập đúng định dạng");
            PhongTro temp = new PhongTro(dienTich, noiThat, diaChi, soPhong, 0, giaPhong, ghiChu, this, null, false, giaDien, giaNuoc, null);
            DsPhongTro[SlTro++] = temp;
            PhongTro.PhongTroList.Add(temp);
        }

        public void XuatThongTinDSPhongTro()
        {
            foreach (PhongTro pt in DsPhongTro)
            {
                if (pt != null)
                {
                    pt.XuatThongTin();
                    Console.WriteLine("------------------------");
                }
            }
        }

        public override void HeThong()
        {
            Menu menu = new Menu("Người Cho Thuê");
            menu.AddNewOption("Xuất thông tin cá nhân");
            menu.AddNewOption("Thêm phòng trọ");
            menu.AddNewOption("Xuất thông tin các trọ đang sở hữu");
            menu.AddNewOption("Thoát");

            int choice;

            while (true)
            {
                menu.PrintMenu();
                choice = menu.GetChoice();

                switch (choice)
                {
                    case 1:
                        {
                            XuatThongTin();
                            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            ThemPhongTro();
                            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            XuatThongTinDSPhongTro();
                            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            return;
                        }
                }
            }
        }

        public void Save()
        {
            DocGhi<NguoiChoThue>.Write(chuList, "nguoichothue.csv");
        }
    }
}
