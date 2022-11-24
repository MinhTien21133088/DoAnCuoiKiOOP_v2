using System;

namespace DoAnCuoiKiOOP_v2
{
    public static class Program
    {
        public static void Main(string[] agrs)
        {
            // Lưu ý:
            // Định dạng tiền nhập vào sẽ là 10000 - tương đương với 10k VNĐ
            InputUnicode();
            OutputUnicode();

            // Công ty môi giới và người môi giới
            CongTyMoiGioi CTMG = new CongTyMoiGioi("Nhóm 19", "OOPR230279_22_1_09", "230279");
            NguoiMoiGioi nguoiMoiGioi = new NguoiMoiGioi("Bách Hậu Tiến An", "379434088365", "2111021133", true, new DateTime(2003, 09, 19), "Người môi giới", "HCMUTE", "0000MG", "0000", CTMG);
            //////////////

            // Code Bách
            // Đọc file ghi vào list

            int choice;

            Menu Welcome = new("QUẢN LÝ PHÒNG TRỌ");
            Welcome.AddNewOption("Đăng ký");
            Welcome.AddNewOption("Đăng nhập");
            Welcome.AddNewOption("Thông tin người môi giới");
            Welcome.AddNewOption("Thông tin công ty môi giới");
            Welcome.AddNewOption("Tra cứu hợp đồng");
            Welcome.AddNewOption("Thoát");

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
                                            NguoiChoThue.DangKy();
                                            break;
                                        }
                                    case 2:
                                        {
                                            NguoiThue.DangKy();
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
                                            NguoiChoThue nguoiChoThue = NguoiChoThue.DangNhap();
                                            if (nguoiChoThue != null)
                                                nguoiChoThue.HeThong();
                                            else
                                                Console.WriteLine("Đăng nhập thất bại");
                                            break;

                                        }
                                    case 2:
                                        {
                                            NguoiThue nguoiThue = NguoiThue.DangNhap();
                                            if (nguoiThue != null)
                                                nguoiThue.HeThong();
                                            else
                                                Console.WriteLine("Đăng nhập thất bại");
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
                            //goto TRO_LAI_MENU_CHINH;
                            //break;
                        }
                    case 3:
                        {
                            nguoiMoiGioi.XuatThongTin();
                            Console.WriteLine("Bấm phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            goto TRO_LAI_MENU_CHINH;
                            //break;
                        }
                    case 4:
                        {
                            CTMG.XuatThongTin(0);
                            Console.WriteLine("Bấm phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            goto TRO_LAI_MENU_CHINH;
                            //break;
                        }
                    case 5:
                        {
                            string maHD = Inputter.GetString("Nhập mã số hợp đồng: ", "Vui lòng nhập đúng định dạng");
                            HopDong.Search(maHD);
                            Console.WriteLine("Bấm phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            goto TRO_LAI_MENU_CHINH;
                            //break;
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

            // Code Bách
            // Ghi file ghi vào list

        }

        public static void InputUnicode()
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
        }

        public static void OutputUnicode()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }
    }
}
