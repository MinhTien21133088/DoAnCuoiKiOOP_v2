using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class NguoiChoThue : Nguoi
    {
        public NguoiChoThue(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep, string diaChi, string matKhau)
                                   : base(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, diaChi, matKhau)
        {
        }

        public NguoiChoThue() { }

        ~NguoiChoThue() { }

        public void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin người cho thuê ---");
            base.XuatThongTin();
        }

        public void XuatThongTinDSPhongTro()
        {
            var result = from phongTro in QuanLyPhongTro.DSPhongTro
                         where phongTro.CCCDNguoiChoThue == CCCD
                         select phongTro;
            foreach (PhongTro phongTro in result)
            {
                phongTro.XuatThongTin();
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
                            QuanLyPhongTro.ThemPhongTro(this);
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
