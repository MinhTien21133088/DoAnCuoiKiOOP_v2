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

        public NguoiThue()
        {

        }

        public NguoiThue DangKy()
        {
            base.DangKy();
            return this;
        }

        public double TienConNo()
        {
            return tienNo;
        }

        public void ThanhToanNo()
        {
            tienNo = 0;
            return;
        }

        public void ghiNo(double soTienNo)
        {
            tienNo += soTienNo;
            return;
        }

        public void ThanhToanTro()
        {
            phongTro.ThanhToan();
        }
    }
}