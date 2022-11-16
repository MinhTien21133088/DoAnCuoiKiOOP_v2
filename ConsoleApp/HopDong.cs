using FileGeneric;
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
        private NguoiThue nguoiThue;
        private NguoiChoThue nguoiChoThue;
        private string maSoHopDong = "";
        private PhongTro phongTro;
        private List<HopDong> hopdongList = new List<HopDong>();

        public HopDong(DateTime thoiHan, NguoiThue nguoiThue, NguoiChoThue nguoiChoThue, PhongTro phongTro)
        {
            this.thoiHan = thoiHan;
            this.nguoiThue = nguoiThue;
            this.nguoiChoThue = nguoiChoThue;
            TaoMaHopDong();
            this.phongTro = phongTro;
            tienCoc = phongTro.GiaPhong() * 2;
            //Save();
        }

        ~HopDong() { }

        public void XuatThongTin()
        {
            
        }

        public static bool Search(string maHD)
        {
            // Tìm kiếm thấy
            //XuatThongTin();

            return true;
            Console.WriteLine("Không tìm thấy hợp đồng");
            // ngược lại
            return false;
        }

        public void TaoMaHopDong()
        {
            Random random = new Random();
            for(int i =0; i < 6; ++i)
                maSoHopDong += random.Next(0, 9).ToString();
        }

        public void HuyHopDong(bool over)
        {
            if (over)
                BoiThuongHopDong();

            // Xóa thông tin hợp đồng trong file và sửa thông tin trọ trong file

            phongTro.CapNhatTinhTrang(false, 0, phongTro.GhiChu());
            Console.WriteLine("Bạn đã hủy hợp đồng thành công");
        }

        public void BoiThuongHopDong() // chua toi thoi han nhung huy hop dong thi mat tien coc
        {
            Console.WriteLine("Bạn sẽ mất tiền cọc vì hủy hợp đồng trước hạn");
        }

        public void GiaHanHopDong()
        {
            thoiHan = thoiHan.AddMonths(6);
            Console.WriteLine("Bạn đã gia hạn hợp đồng thành công");
        }

        public void KiemTraHopDong()
        {
            DateTime toDay = DateTime.Today;
            if (thoiHan < toDay)
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

        /*public void Save()
        {
            DocGhi<HopDong>.Write(hopdongList, "hopdong.csv");
            var dsHopDong = DocGhi<HopDong>.Read("dong.csv");
            foreach (var hopdong in dsHopDong)
            {
                hopdong.XuatThongTin();
            }
        }*/
    }
}
