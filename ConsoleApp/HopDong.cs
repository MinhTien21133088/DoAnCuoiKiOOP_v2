using FileGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class HopDong
    {
        #region Fields
        private DateTime thoiHan;
        private double tienCoc;
        private NguoiThue nguoiThue;
        private NguoiChoThue nguoiChoThue;
        private string maSoHopDong = "";
        private PhongTro phongTro;
        private static List<HopDong> hopdongList = new List<HopDong>();
        #endregion

        #region Properties
        public DateTime ThoiHan { get => thoiHan; set => thoiHan = value; }
        public double TienCoc { get => tienCoc; set => tienCoc = value; }
        public NguoiThue NguoiThue { get => nguoiThue; set => nguoiThue = value; }
        public NguoiChoThue NguoiChoThue { get => nguoiChoThue; set => nguoiChoThue = value; }
        public string MaSoHopDong { get => maSoHopDong; set => maSoHopDong = value; }
        public PhongTro PhongTro { get => phongTro; set => phongTro = value; }
        public static List<HopDong> HopdongList { get => hopdongList; set => hopdongList = value; }
        #endregion

        public HopDong(DateTime thoiHan, NguoiThue nguoiThue, NguoiChoThue nguoiChoThue, PhongTro phongTro)
        {
            ThoiHan = thoiHan;
            NguoiThue = nguoiThue;
            NguoiChoThue = nguoiChoThue;
            TaoMaHopDong();
            PhongTro = phongTro;
            TienCoc = phongTro.GiaPhong * 2;
            //Save();
        }

        ~HopDong() { }

        public void XuatThongTin()
        {

        }

        public static bool Search(string maHD)
        {
            foreach (HopDong hd in HopdongList)
            {
                if (maHD == hd.MaSoHopDong)
                {
                    hd.XuatThongTin();
                    return true;
                }
            }
            Console.WriteLine("Không tìm thấy hợp đồng");
            return false;
        }

        public void TaoMaHopDong()
        {
            Random random = new Random();
            for (int i = 0; i < 6; ++i)
                MaSoHopDong += random.Next(0, 9).ToString();
        }

        public void HuyHopDong(bool over)
        {
            if (over)
                BoiThuongHopDong();

            // Xóa thông tin hợp đồng trong file và sửa thông tin trọ trong file

            PhongTro.CapNhatTinhTrang(false, 0, PhongTro.GhiChu);
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
