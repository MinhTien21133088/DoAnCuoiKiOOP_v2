using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQtoCSV;

namespace DoAnCuoiKiOOP_v2
{
    
    public class NguoiThue : Nguoi
    {
        private double tienNo;
        private PhongTro phongTro;
        

        public double TienNo { get => tienNo; set => tienNo = value; }

        public NguoiThue(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep, string diaChi, string tenDangNhap, string matKhau) : base(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, diaChi, tenDangNhap, matKhau)
        {
        }
        

        public NguoiThue() { }

       
        
        ~NguoiThue() { }

        public static void GhiFile(List<NguoiThue> ThueList)
        {
            string separator = ",";
            StringBuilder output = new StringBuilder();
            foreach (NguoiThue nguoi in ThueList)
            {
                String[] newLine = { nguoi.hoVaTen,nguoi.cccd, nguoi.sdt,nguoi.gioiTinh.ToString(),
                    nguoi.ngaySinh.ToString(),nguoi.diaChi,nguoi.ngheNghiep,nguoi.tenDangNhap,nguoi.matKhau,nguoi.tienNo.ToString(),nguoi.phongTro == null ? 0.ToString() : nguoi.phongTro.SoPhong.ToString()};
                output.AppendLine(string.Join(separator, newLine));
            }
            try
            {
                File.AppendAllText("NguoiThue.txt", output.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể ghi File. " + ex);
            }
        }


        public NguoiThue(bool nhap):base(nhap)
        {
            QuanLyPhongTro.ThueList.Add(this);
        }


        public NguoiThue DangNhap()
        {
            string ten = Inputter.GetString("Tên đăng nhập: ", "Tên đăng nhập không được bỏ trống");
            string mK = Inputter.GetString("Mật khẩu: ", "Mật khẩu không được bỏ trống");
            foreach (NguoiThue nguoi in QuanLyPhongTro.ThueList)
            {
                if (ten == nguoi.tenDangNhap && mK == nguoi.matKhau)
                  return nguoi;
            }
            Console.WriteLine("Tên đăng nhập hoặc mật khẩu không hợp lệ");
            return null;
        }

        public void XoaNo()
        {
            TienNo = 0;
            return;
        }

        public void GhiNo(double soTienNo)
        {
            TienNo += soTienNo;
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
            Console.WriteLine("Nợ hiện tại của bạn: " + TienNo);
            int temp = Inputter.GetInteger("Nhập số tiền muốn thanh toán: ", "Vui lòng nhập đúng định dạng");
            if (temp >= TienNo)
            {
                Console.WriteLine("Thanh toán nợ thành công!");
                Console.WriteLine("Số tiền dư ra: " + (temp - TienNo));
                TienNo = 0;
                return;
            }
            else
            {
                TienNo -= temp;
                Console.WriteLine("Thanh toán nợ thành công!");
                Console.WriteLine("Số tiền nợ còn lại: " + TienNo);
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
            HopDong hd = new HopDong(DateTime.Today.AddMonths(6), this, phongTro.NguoiChoThue(), phongTro);
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
