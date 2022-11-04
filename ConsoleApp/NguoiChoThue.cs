﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKiOOP_v2
{
    public class NguoiChoThue : Nguoi
    {
        public NguoiChoThue(string hoVaTen, string cccd, string sdt, bool gioiTinh, DateTime ngaySinh, string ngheNghiep, string tenDangNhap, string matKhau) : base(hoVaTen, cccd, sdt, gioiTinh, ngaySinh, ngheNghiep, tenDangNhap, matKhau)
        {
        }

        public void XuatThongTin()
        {
            Console.WriteLine("--- Thông tin người cho thuê ---");
            base.XuatThongTin();
        }

        public NguoiChoThue DangKy()
        {
            base.DangKy();
            
        }
    }
}