using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class HopDong
    {
        private DateTime thoiHan;
        private double tienCoc;
        private string cccdNguoiThue; // dùng cccd của người thuê để tìm hợp đồng.
        private string cccdNguoiChoThue;
        private string idPhongTro;

        public DateTime ThoiHan { get => thoiHan; set => thoiHan = value; }
        public double TienCoc { get => tienCoc; set => tienCoc = value; }
        public string CCCDNguoiThue { get => cccdNguoiThue; set => cccdNguoiThue = value; }
        public string CCCDNguoiChoThue { get => cccdNguoiChoThue; set => cccdNguoiChoThue = value; }
        public string IDPhongTro { get => idPhongTro; set => idPhongTro = value; }

        public HopDong(DateTime thoiHan, NguoiThue nguoiThue, NguoiChoThue nguoiChoThue, PhongTro phongTro)
        {
            this.ThoiHan = thoiHan;
            CCCDNguoiThue = nguoiThue.CCCD;
            CCCDNguoiChoThue = nguoiChoThue.CCCD;
            IDPhongTro = phongTro.IDPhongTro;
            TienCoc = phongTro.GiaPhong * 2;
            QuanLyPhongTro.DSHopDong.Add(this);
            XuLyFileCSV<HopDong>.Write(QuanLyPhongTro.DSHopDong, "hopdong.csv");
        }

        public HopDong() { }

        ~HopDong() { }

        public void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin người cho thuê ---");
            NguoiChoThue().XuatThongTin();
            Console.WriteLine("--- Thông tin người thuê ---");
            NguoiThue().XuatThongTin();
            Console.WriteLine("--- Thông tin phòng trọ ---");
            PhongTro().XuatThongTin();
        }

        public NguoiChoThue NguoiChoThue()
        {
            NguoiChoThue result = (NguoiChoThue)(from nguoiChoThue in QuanLyPhongTro.DSNguoiChoThue
                                                 where CCCDNguoiChoThue == nguoiChoThue.CCCD
                                                 select nguoiChoThue);
            return result;
        }

        public NguoiThue NguoiThue()
        {
            NguoiThue result = (NguoiThue)(from nguoiThue in QuanLyPhongTro.DSNguoiThue
                                           where CCCDNguoiThue == nguoiThue.CCCD
                                           select nguoiThue);
            return result;
        }

        public PhongTro PhongTro()
        {
            PhongTro result = (PhongTro)(from PhongTro in QuanLyPhongTro.DSPhongTro
                                         where IDPhongTro == PhongTro.IDPhongTro
                                         select PhongTro);
            return result;
        }

        public static bool Search(string cccdNguoiThue)
        {
            foreach(HopDong hopDong in QuanLyPhongTro.DSHopDong)
            {
                if(cccdNguoiThue == hopDong.CCCDNguoiThue)
                {
                    hopDong.XuatThongTin();
                    return true;
                }
            }
            Console.WriteLine("Không tìm thấy hợp đồng");
            return false;
        }

        public void HuyHopDong(bool hetHan)
        {
            if (hetHan)
                BoiThuongHopDong();
            string[] ghiChu = { "" };
            PhongTro().CapNhatTinhTrang(false, 0, ghiChu); // ghi chú ở đây là sao?
            Console.WriteLine("Bạn đã hủy hợp đồng thành công");
        }

        public void BoiThuongHopDong() // chua toi thoi han nhung huy hop dong thi mat tien coc
        {
            Console.WriteLine("Bạn sẽ mất tiền cọc vì hủy hợp đồng trước hạn");
        }

        public void GiaHanHopDong()
        {
            ThoiHan = ThoiHan.AddMonths(6);
            Console.WriteLine("Bạn đã gia hạn hợp đồng thành công");
        }

        public void KiemTraHopDong()
        {
            DateTime toDay = DateTime.Today;
            if (ThoiHan < toDay)
            {
                Console.WriteLine("Hợp đồng này đã hết hạn!");
                int choice = Inputter.GetInteger("Bạn có muốn gia hạn hợp đồng hay không? (1: có; 0: không)", "Vui lòng nhập đúng định dạng", 0, 1);
                if (choice == 1)
                {
                    GiaHanHopDong();
                }
                else
                {
                    HuyHopDong(true);
                }
            }
            else
            {
                Console.WriteLine("Hợp đồng của bạn vẫn còn thời hạn");
                int choice = Inputter.GetInteger("Bạn có muốn hủy hợp đồng hay không? (1: có; 0: không)", "Vui lòng nhập đúng định dạng", 0, 1);
                {
                    if (choice == 1)
                        HuyHopDong(false);
                    else
                    {
                        Console.WriteLine("Ấn phím bất kỳ để tiếp tục");
                        Console.ReadKey();
                    }
                }
            }

        }    
    }
}
