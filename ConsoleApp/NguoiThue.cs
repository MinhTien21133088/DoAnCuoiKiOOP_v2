﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class NguoiThue : Nguoi
    {
        private double tienNo;
        private PhongTro? phongTro;
        static List<NguoiThue> dsNguoiThue = new List<NguoiThue>();

        public NguoiThue(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep, string diaChi, string tenDangNhap, string matKhau) : base(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, diaChi, tenDangNhap, matKhau)
        {
        }
        
        public NguoiThue() { }
        
        ~NguoiThue() { }

        public new void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin người thuê ---");
            base.XuatThongTin();
        }

        public static void DangKy()
        {
            dsNguoiThue.Add((NguoiThue)DangKy(1));
        }

        public static new NguoiThue? DangNhap()
        {
            string[] thongTinDangNhap = Nguoi.DangNhap().Split(',');
            /*
             * thongTinDangNhap[0] mang thông tin tenDangNhap của đối tượng
             * thongTinDangNhap[1] mang thông tin matKhau của đối tượng
             */
            foreach (NguoiThue nguoiThue in dsNguoiThue)
            {
                if (nguoiThue.tenDangNhap == thongTinDangNhap[0] && nguoiThue.matKhau == thongTinDangNhap[1])
                    return nguoiThue;
            }
            return null;
        }

        public double TienConNo()
        {
            return tienNo;
        }

        public void XoaNo()
        {
            tienNo = 0;
            return;
        }

        public void GhiNo(double soTienNo)
        {
            tienNo += soTienNo;
            return;
        }

        public void ThanhToanTro()
        {
            if (phongTro == null)
            {
                Console.WriteLine("Bạn chưa đăng ký bất kỳ trọ nào");
                return;
            }
            phongTro.ThanhToan();
        }

        public void ThanhToanNo()
        {
            Console.WriteLine("Nợ hiện tại của bạn: " + tienNo);
            int temp = Inputter.GetInteger("Nhập số tiền muốn thanh toán: ", "Vui lòng nhập đúng định dạng");
            if (temp >= tienNo)
            {
                Console.WriteLine("Thanh toán nợ thành công!");
                Console.WriteLine("Số tiền dư ra: " + (temp - tienNo));
                tienNo = 0;
                return;
            }
            else
            {
                tienNo -= temp;
                Console.WriteLine("Thanh toán nợ thành công!");
                Console.WriteLine("Số tiền nợ còn lại: " + tienNo);
                return;
            }
        }

        public void LapHopDong()
        {
            PhongTro[] dsPT;
            dsPT = PhongTro.DSPhongConTrong();
            foreach (PhongTro pT in dsPT)
            {
                pT.XuatThongTin();
            }
            int choice;
            while (true)
            {
                choice = Inputter.GetInteger("Nhập mã số phòng trọ bạn muốn thuê (Nhập 0 để thoát): ", "Vui lòng nhập đúng định dạng");
                if (choice == 0)
                    return;
                foreach (PhongTro pT in dsPT)
                {
                    if (pT.SoPhong == choice)
                    {
                        phongTro = pT;
                        break;
                    }
                }
                Console.WriteLine("Không có phòng trọ có mã số này!");
                break;
            }
            Console.WriteLine("Hợp đồng của bạn có thời hạn 6 tháng kể từ ngày lập hợp đồng này");
            Console.WriteLine("Tiền cọc trọ của bạn là: " + phongTro.GiaPhong * 2);
            HopDong hd = new HopDong(DateTime.Today.AddMonths(6), this, phongTro.NguoiChoThue, phongTro);
        }



        public override void HeThong() // Nếu đăng nhập thành công sẽ chạy vào hàm hệ thống  
        {
            Menu menu = new Menu("Người Thuê");
            menu.AddNewOption("Xuất thông tin cá nhân");
            menu.AddNewOption("Thanh toán trọ");
            menu.AddNewOption("Thanh toán nợ");
            menu.AddNewOption("Lập hợp đồng thuê trọ");
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
                            ThanhToanTro();
                            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            ThanhToanNo();
                            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            LapHopDong();
                            return;
                        }
                }
            }
        }

    }
}
