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
        private string idPhongTro;

        public double TienNo { get => tienNo; set => tienNo = value; }
        public string IdPhongTro { get => idPhongTro; set => idPhongTro = value; }

        public NguoiThue(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep, string diaChi, string matKhau)
                                : base(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, diaChi, matKhau)
        {
        }

        public NguoiThue() { }

        ~NguoiThue() { }

        public void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin người thuê ---");
            base.XuatThongTin();
            if(PhongTro != null)
            {
                Console.Write("Đã thuê phòng trọ: ");
                Console.Write(PhongTro().SoPhong + " của "
                    + string.Format("{0} {1}",
                    PhongTro().NguoiChoThue().GioiTinh ? "Ông" : "Bà", PhongTro().NguoiChoThue().HoVaTen));
            }
            else
            {
                Console.WriteLine("Chưa thuê phòng nào");
            }    
        }

        public PhongTro PhongTro()
        {
            PhongTro result = (PhongTro)(from PhongTro in QuanLyPhongTro.DSPhongTro
                                         where IdPhongTro == PhongTro.IDPhongTro
                                         select PhongTro);
            return result;
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
            if (PhongTro() == null)
            {
                Console.WriteLine("Bạn chưa đăng ký bất kỳ trọ nào");
                return;
            }
            PhongTro().ThanhToan();
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
            var phongTroConTrong = from phongTro in QuanLyPhongTro.DSPhongTro where !PhongTro().TinhTrang select phongTro;
            int i = 0;
            List<PhongTro> temp = new List<PhongTro>();
            foreach (var phongTro in phongTroConTrong)
            {
                temp.Add(phongTro);
                Console.WriteLine(i++);
                phongTro.XuatThongTin();             
            }
            int choice;
            while (true)
            {
                choice = Inputter.GetInteger("Nhập mã số phòng trọ bạn muốn thuê (Nhập 0 để thoát): ", 0, i);
                if (choice == 0)
                    return;
                IdPhongTro = temp[choice].IDPhongTro;
                int soNguoi = Inputter.GetInteger("Nhập số người ở: ");
                temp[choice].CapNhatNguoiThue(this, soNguoi);
                break;
            }
            Console.WriteLine("Hợp đồng của bạn có thời hạn 6 tháng kể từ ngày lập hợp đồng này");
            Console.WriteLine("Tiền cọc trọ của bạn là: " + PhongTro().GiaPhong * 2);
            HopDong hopDong = new HopDong(DateTime.Today.AddMonths(6), this, PhongTro().NguoiChoThue(), PhongTro());
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
