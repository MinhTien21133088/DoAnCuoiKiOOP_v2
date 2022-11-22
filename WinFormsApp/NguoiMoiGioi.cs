using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class NguoiMoiGioi : Nguoi
    {
        private CongTyMoiGioi congTyMoiGioi;

        public NguoiMoiGioi(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep,string diaChi, string tenDangNhap, string matKhau, CongTyMoiGioi congTyMoiGioi) : base(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep,diaChi, tenDangNhap, matKhau)
        {
            this.congTyMoiGioi = congTyMoiGioi;
        }

        ~NguoiMoiGioi() { }

        public void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin người môi giới ---");
            base.XuatThongTin();
            Console.WriteLine("Đến từ công ty môi giới " + congTyMoiGioi.ten);
            congTyMoiGioi.XuatThongTin(1);
        }

    }
}
