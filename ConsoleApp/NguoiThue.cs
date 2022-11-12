using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class NguoiThue : Nguoi
    {
        private double tienNo;
        private PhongTro phongTro;

        public NguoiThue(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep,string diaChi, string tenDangNhap, string matKhau) : base(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, diaChi, tenDangNhap, matKhau)
        {
        }

        public NguoiThue() { }

        ~NguoiThue() { }


        public NguoiThue DangKy()
        {
            base.DangKy();
            return this;
        }

        public override bool DangNhap()
        {
            return base.DangNhap();
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
            if(phongTro == null)
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
            if(temp >= tienNo)
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
            //PhongTro dsPT[100];
            //dsPT = PhongTro.DSPhongConTrong();
            int choice = Inputter.GetInteger("Nhập phòng trọ bạn muốn thuê: ", "Vui lòng nhập đúng định dạng");
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

            while(true)
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
