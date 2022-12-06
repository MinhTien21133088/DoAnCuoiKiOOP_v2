using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class NguoiMoiGioi : Nguoi
    {
        private string tenCongTyMoiGioi;
        private string maMoi; // mã mời hay mã giới thiệu, là cách mà phòng trọ được môi giới

        public string TenCongTyMoiGioi { get => tenCongTyMoiGioi; set => tenCongTyMoiGioi = value; }
        public string MaMoi { get => maMoi; set => maMoi = value; }

        public NguoiMoiGioi(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep,string diaChi, /*string tenDangNhap,*/ string matKhau, CongTyMoiGioi congTyMoiGioi) : base(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep,diaChi, /*tenDangNhap,*/ matKhau)
        {
            TenCongTyMoiGioi = congTyMoiGioi.Ten;
            MaMoi = (string)CCCD.TakeLast(4); // lấy 4 số cccd cuối làm mã mời
        }

        public NguoiMoiGioi() { }

        ~NguoiMoiGioi() { }

        public void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin người môi giới ---");
            base.XuatThongTin();
            //Console.WriteLine("Đến từ công ty môi giới " + TenCongTyMoiGioi);
            //congTyMoiGioi.XuatThongTin(1);
            Console.WriteLine("Mã mời: " + MaMoi);
        }

    }
}
