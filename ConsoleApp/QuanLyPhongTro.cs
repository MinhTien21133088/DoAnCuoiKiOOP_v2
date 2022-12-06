using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKiOOP_v2
{
    public class QuanLyPhongTro
    {
        private static List<NguoiThue> dsNguoiThue = new List<NguoiThue>();
        private static List<NguoiChoThue> dsNguoiChoThue = new List<NguoiChoThue>();
        private static List<HopDong> dsHopDong = new List<HopDong>();
        private static List<PhongTro> dsPhongTro = new List<PhongTro>();
        private static List<CongTyMoiGioi> dsCongTyMoiGioi = new List<CongTyMoiGioi>();
        private static List<NguoiMoiGioi> dsNguoiMoiGioi = new List<NguoiMoiGioi>();

        public static List<NguoiThue> DSNguoiThue { get => dsNguoiThue; set => dsNguoiThue = value; }
        public static List<NguoiChoThue> DSNguoiChoThue { get => dsNguoiChoThue; set => dsNguoiChoThue = value; }
        public static List<HopDong> DSHopDong { get => dsHopDong; set => dsHopDong = value; }
        public static List<PhongTro> DSPhongTro { get => dsPhongTro; set => dsPhongTro = value; }
        public static List<CongTyMoiGioi> DSCongTyMoiGioi { get => dsCongTyMoiGioi; set => dsCongTyMoiGioi = value; }
        public static List<NguoiMoiGioi> DSNguoiMoiGioi { get => dsNguoiMoiGioi; set => dsNguoiMoiGioi = value; }

        public static void DangKy(int mode)
        {
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
                    Inputter.GetStringF("Ngày tháng năm sinh (dd/MM/yyyy): ", "Ngày tháng năm sinh không hợp lệ",
                        "((0|1)[0-9]|2[0-9]|3[0-9])/(0[0-9]|1[0-2])/((19|20)[0-9][0-9])$"), "dd/MM/yyyy", null);
            }
            catch /*(Exception ex)*/
            {
                Console.WriteLine("Ngày tháng năm sinh không hợp lệ.");
                goto NHAP_LAI_NGAY_SINH;
            }
            string ngheNghiep = Inputter.GetString("Nghề nghiệp: ", "Nghề nghiệp không được bỏ trống");
            string diaChi = Inputter.GetString("Địa chỉ: ", "Địa chỉ không được bỏ trống");
            //tenDangNhap = Inputter.GetString("Tên đăng nhập: ", "Tên đăng nhập không được bỏ trống");
            string matKhau = Inputter.GetString("Mật khẩu: ", "Mật khẩu không được bỏ trống");
            switch (mode)
            {
                case 0:
                    {
                        for (int i = 0; i <= DSCongTyMoiGioi.Count; i++)
                        {
                            Console.WriteLine("{0}. {1}", i + 1, DSCongTyMoiGioi[i].Ten);
                        }
                        int choice = Inputter.GetInteger("Vui lòng chọn công ty mô giới mà chương trình hỗ trợ: ", 1, DSCongTyMoiGioi.Count);
                        NguoiMoiGioi nguoiMoiGioi = new(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, diaChi, matKhau, DSCongTyMoiGioi[choice]);
                        DSNguoiMoiGioi.Add(nguoiMoiGioi);
                        XuLyFileCSV<NguoiMoiGioi>.Write(DSNguoiMoiGioi, "nguoimoigioi.csv");
                        break;
                    }
                case 1:
                    {
                        NguoiChoThue nguoiChoThue = new(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, diaChi, matKhau);
                        DSNguoiChoThue.Add(nguoiChoThue);
                        XuLyFileCSV<NguoiChoThue>.Write(DSNguoiChoThue, "nguoichothue.csv");
                        break;
                    }
                case 2:
                    {
                        NguoiThue nguoiThue = new(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, diaChi, matKhau);
                        DSNguoiThue.Add(nguoiThue);
                        XuLyFileCSV<NguoiThue>.Write(DSNguoiThue, "nguoithue.csv");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("mode nhập sai nha, vô code coi lại đi :v");
                        Environment.Exit(0);
                        break;
                    }
            }
        }

        public static void DangNhap(int mode)
        {
            string cccd = Inputter.GetString("Số CCCD: ", "Tên đăng nhập không được bỏ trống");
            string matKhau = Inputter.GetString("Mật khẩu: ", "Mật khẩu không được bỏ trống");
            switch (mode)
            {
                case 0:
                    {
                        foreach (NguoiMoiGioi nguoi in DSNguoiMoiGioi)
                        {
                            if (nguoi.DangNhapThanhCong(cccd, matKhau))
                                nguoi.XuatThongTin();
                        }
                        Console.WriteLine("Đăng nhập thất bại.");
                        Console.WriteLine();
                        string choice = Inputter.GetStringF("Bạn muốn tiếp tục? ('Y'/'N') ", "y|n|Y|N");
                        if (choice == "Y" || choice == "y")
                            DangNhap(0);
                        break;
                    }
                case 1:
                    {
                        foreach (NguoiChoThue nguoi in DSNguoiChoThue)
                        {
                            if (nguoi.DangNhapThanhCong(cccd, matKhau))
                                nguoi.HeThong();
                            else
                            {
                                Console.WriteLine("Đăng nhập thất bại.");
                                break;
                            }
                        }
                        Console.WriteLine();
                        string choice = Inputter.GetStringF("Bạn muốn tiếp tục? ('Y'/'N') ", "y|n|Y|N");
                        if (choice == "Y" || choice == "y")
                            DangNhap(1);
                        break;
                    }
                case 2:
                    {
                        foreach (NguoiThue nguoi in DSNguoiThue)
                        {
                            if (nguoi.DangNhapThanhCong(cccd, matKhau))
                                nguoi.HeThong();
                        }
                        Console.WriteLine("Đăng nhập thất bại.");
                        Console.WriteLine();
                        string choice = Inputter.GetStringF("Bạn muốn tiếp tục? ('Y'/'N') ", "y|n|Y|N");
                        if (choice == "Y" || choice == "y")
                            DangNhap(2);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("mode nhập sai nha, vô code coi lại đi :v");
                        Environment.Exit(0);
                        break;
                    }
            }
        }

        public static void ThemPhongTro(NguoiChoThue nguoiChoThue)
        {
            Program.InputUnicode();
            string soPhong = Inputter.GetString("Nhập số phòng đầu tiên (các số phòng sau đó sẽ theo thứ tự mà tăng dần: ", "Vui lòng không bỏ trống");
            double dienTich = Inputter.GetDouble("Nhập diện tích của phòng trọ: ", "Vui lòng nhập đúng định dạng");
            int slNoiThat = Inputter.GetInteger("Nhập số lượng nội thất: ", "Vui lòng nhập đúng định dạng");
            string[,] noiThat = new string[slNoiThat, 2];
            for (int i = 0; i < slNoiThat; ++i)
            {
                noiThat[i, 0] = Inputter.GetString("Nhập nội thất: ", "Vui lòng không bỏ trống");
                noiThat[i, 1] = Inputter.GetInteger("Nhập giá trị nội thất: ", "Vui lòng nhập đúng định dạng").ToString();
            }
            string diaChi = Inputter.GetString("Nhập địa chỉ: ", "Vui lòng không bỏ trống");
            double giaPhong = Inputter.GetDouble("Nhập giá phòng: ", "Vui lòng nhập đúng định dạng");
            int slGhiChu = Inputter.GetInteger("Nhập số lượng ghi chú: ", "Vui lòng nhập đúng định dạng");
            string[] ghiChu = new string[slGhiChu];
            for (int i = 0; i < slGhiChu; ++i)
            {
                ghiChu[i] = Inputter.GetString("Nhập ghi chú " + (i + 1) + ": ", "Vui lòng không bỏ trống");
            }
            double giaDien = Inputter.GetDouble("Nhập giá điện (VNĐ/kWh): ", "Vui lòng nhập đúng định dạng");
            double giaNuoc = Inputter.GetDouble("Nhập giá nước (VNĐ/m^3): ", "Vui lòng nhập đúng định dạng");
            PhongTro phongTroNew = new(soPhong, dienTich, noiThat, diaChi, 0, giaPhong, ghiChu, nguoiChoThue, false, giaDien, giaNuoc);
            int soPhongTro = Inputter.GetInteger("Có bao nhiêu phòng trọ giống phòng bạn vừa nhập? ");
            for (int i = 0; i < soPhongTro; i++)
            {
                PhongTro phongTroNews = new(phongTroNew, i + 1);
                DSPhongTro.Add(phongTroNews);
                XuLyFileCSV<PhongTro>.Write(DSPhongTro, "phongtro.csv");
            }
        }

        public static void HeThong()
        {
            Menu Welcome = new("QUẢN LÝ PHÒNG TRỌ");
            Welcome.AddNewOption("Đăng ký");
            Welcome.AddNewOption("Đăng nhập");
            Welcome.AddNewOption("Người môi giới");
            Welcome.AddNewOption("Danh sách các công ty môi giới");
            Welcome.AddNewOption("Tra cứu hợp đồng");
            Welcome.AddNewOption("Thoát");

            int choice;

        TRO_LAI_MENU_CHINH:
            // Welcome
            while (true)
            {
                Welcome.PrintMenu();
                choice = Welcome.GetChoice();

                switch (choice)
                {
                    case 1:
                        {
                            Menu MenuDangKy = new("ĐĂNG KÝ");
                            MenuDangKy.AddNewOption("Người cho thuê");
                            MenuDangKy.AddNewOption("Người thuê");
                            MenuDangKy.AddNewOption("Trở lại");
                            // Đăng ký
                            while (true)
                            {
                                MenuDangKy.PrintMenu();
                                choice = MenuDangKy.GetChoice();
                                Console.WriteLine();
                                switch (choice)
                                {
                                    case 1:
                                        {
                                            DangKy(1);
                                            break;
                                        }
                                    case 2:
                                        {
                                            DangKy(2);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("--------------------------");
                                            Console.WriteLine("Bấm phím bất kỳ để trở lại");
                                            Console.ReadKey();
                                            goto TRO_LAI_MENU_CHINH;
                                        }
                                }
                            }
                            //break;
                        }
                    case 2:
                        {
                            Menu MenuDangNhap = new("ĐĂNG NHẬP");
                            MenuDangNhap.AddNewOption("Người cho thuê");
                            MenuDangNhap.AddNewOption("Người thuê");
                            MenuDangNhap.AddNewOption("Trở lại");
                            // Đăng nhập
                            while (true)
                            {
                                MenuDangNhap.PrintMenu();
                                choice = MenuDangNhap.GetChoice();
                                Console.WriteLine();
                                switch (choice)
                                {
                                    case 1:
                                        {
                                            DangNhap(1);
                                            break;

                                        }
                                    case 2:
                                        {
                                            DangNhap(2);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Bấm phím bất kỳ để trở lại");
                                            Console.ReadKey();
                                            goto TRO_LAI_MENU_CHINH;
                                        }
                                }
                            }
                        }
                    case 3:
                        {
                            Menu MenuNguoiMoiGioi = new("NGƯỜI MÔI GIỚI");
                            MenuNguoiMoiGioi.AddNewOption("Đăng ký");
                            MenuNguoiMoiGioi.AddNewOption("Đăng nhập");
                            MenuNguoiMoiGioi.AddNewOption("Trở lại");
                            while (true)
                            {
                                MenuNguoiMoiGioi.PrintMenu();
                                choice = MenuNguoiMoiGioi.GetChoice();
                                Console.WriteLine();
                                switch (choice)
                                {
                                    case 1:
                                        {
                                            DangKy(0);
                                            break;

                                        }
                                    case 2:
                                        {
                                            DangNhap(0);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Bấm phím bất kỳ để trở lại");
                                            Console.ReadKey();
                                            goto TRO_LAI_MENU_CHINH;
                                        }
                                }
                            }
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("DANH SÁCH CÔNG TY MÔI GIỚI HỖ TRỢ");
                            int i = 0;
                            foreach (CongTyMoiGioi cTMG in DSCongTyMoiGioi)
                            {
                                Console.Write(i + 1 + ". ");
                                cTMG.XuatThongTin(0);
                                Console.WriteLine();
                            }
                            Console.WriteLine("Bấm phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            goto TRO_LAI_MENU_CHINH;
                        }
                    case 5:
                        {
                            string maHD = Inputter.GetString("Nhập mã số hợp đồng: ", "Vui lòng nhập đúng định dạng");
                            HopDong.Search(maHD);
                            Console.WriteLine("Bấm phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            goto TRO_LAI_MENU_CHINH;
                        }
                    case 6:
                        {
                            Console.WriteLine("Xin cảm ơn và hẹn gặp lại!");
                            Console.ReadKey();
                            break;
                        }
                }
                break;
            }
        }

    }
}
