using FileGeneric;
using System;

namespace DoAnCuoiKiOOP_v2
{
    class Program
    {
        

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Công ty môi giới và người môi giới
            CongTyMoiGioi CTMG = new CongTyMoiGioi("vài thành viên số 19", "Lớp OOP_9", "2111019");
            NguoiMoiGioi nguoiMG = new NguoiMoiGioi("Nguyễn Minh Bảo Bách", "2111039", "0923023332", true, new DateTime(2003, 09, 19), "Người môi giới", "Thủ Đức", "100001", "100001", CTMG);
            //////////////

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
                Console.WriteLine();
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
                                            NguoiChoThue nguoiChoThue = new NguoiChoThue();
                                            nguoiChoThue.DangKy();
                                            break;
                                        }
                                    case 2:
                                        {
                                            NguoiThue nguoiThue = new NguoiThue();
                                            nguoiThue.DangKy();
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
                                            NguoiChoThue nguoiChoThue = new NguoiChoThue();
                                            if (nguoiChoThue.DangNhap())
                                                nguoiChoThue.HeThong();
                                            else
                                                Console.WriteLine("Đăng nhập thất bại");
                                            break;

                                        }
                                    case 2:
                                        {
                                            NguoiThue nguoiThue = new NguoiThue();
                                            if (nguoiThue.DangNhap())
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
                            //break;
                        }
                    case 3:
                        {
                            nguoiMG.XuatThongTin();
                            Console.WriteLine("Bấm phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            CTMG.XuatThongTin(0);
                            Console.WriteLine("Bấm phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            string maHD = Inputter.GetString("Nhập mã số hợp đồng: ", "Vui lòng nhập đúng định dạng");
                            HopDong.Search(maHD);
                            Console.WriteLine("Bấm phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            break;
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

            /*var chuList = new List<NguoiChoThue>
            {
                new NguoiChoThue()
            };
            DocGhi<NguoiChoThue>.Write(chuList, "nguoichothue.csv");
            var dsNguoiChu = DocGhi<NguoiChoThue>.Read("nguoichothue.csv");
            foreach (var chu in dsNguoiChu)
            {
                chu.XuatThongTin();
            }

            var thueList = new List<NguoiThue>
            {
                new NguoiThue()
            };
            DocGhi<NguoiThue>.Write(thueList, "nguoithue.csv");
            var dsNguoiThue = DocGhi<NguoiThue>.Read("nguoithue.csv");
            foreach (var thue in dsNguoiThue)
            {
                thue.DangNhap();
            }*/

            //var mogioiList = new List<NguoiMoiGioi>
            //{
            //    new NguoiMoiGioi()
            //};
            //DocGhi<NguoiMoiGioi>.Write(moigioiList, "nguoithue.csv");
            //var dsNguoiMoiGioi = DocGhi<NguoiMoiGioi>.Read("nguoithue.csv");
            //foreach (var moigioi in dsNguoiThue)
            //{
            //    moigioi.XuatThongTin();
            //}

            //var phongtroList = new List<DayPhongTro>
            //{
            //    new DayPhongTro()
            //};
            
        }
    }
}