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

        public NguoiChoThue(bool nhap) : base(nhap)
        {
            QuanLyPhongTro.ChuList.Add(this);
        }

        public NguoiChoThue DangNhap()
        {
            string ten = Inputter.GetString("Tên đăng nhập: ", "Tên đăng nhập không được bỏ trống");
            string mK = Inputter.GetString("Mật khẩu: ", "Mật khẩu không được bỏ trống");
            foreach (NguoiChoThue nguoi in QuanLyPhongTro.ChuList)
            {
                if (ten == nguoi.tenDangNhap && mK == nguoi.matKhau)
                    return nguoi;
            }
            Console.WriteLine("Tên đăng nhập hoặc mật khẩu không hợp lệ");
            return null;
        }

        public void ThemPhongTro()
        {
            dsPhongTro[slTro++] = new PhongTro(true);
        }

        public void XuatThongTinDSPhongTro()
        {
            foreach(PhongTro pt in dsPhongTro)
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

        
        
    }
}
